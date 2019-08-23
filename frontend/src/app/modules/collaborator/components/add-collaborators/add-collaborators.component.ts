import { Component, OnInit, Input } from '@angular/core';
import { UserNicknameDTO } from '../../../../models/DTO/User/userNicknameDTO';
import { UserService } from 'src/app/services/user.service/user.service';
import { CollaboratorDTO } from 'src/app/models/DTO/User/collaboratorDTO';
import { ProjectService } from 'src/app/services/project.service/project.service';
import { ToastrService } from 'ngx-toastr';
import { HttpResponse } from '@angular/common/http';
import { RightsService } from 'src/app/services/rights.service/rights.service'
import { UpdateUserRightDTO } from 'src/app/models/DTO/User/updateUserRightDTO';
import { ActivatedRoute, Router } from '@angular/router';
import { DeleteCollaboratorRightDTO } from 'src/app/models/DTO/Common/deleteCollaboratorRightDTO';
import { BlockUIModule } from 'primeng/primeng';
import { element } from 'protractor';
import { SignalRService } from 'src/app/services/signalr.service/signal-r.service';

@Component({
    selector: 'app-add-collaborators',
    templateUrl: './add-collaborators.component.html',
    styleUrls: ['./add-collaborators.component.sass']
})

export class AddCollaboratorsComponent implements OnInit {

    @Input() projectId: number

    public collaborator: UserNicknameDTO;
    public filterCollaborators: UserNicknameDTO[];
    public newCollaborators: CollaboratorDTO[] = [];
    public isCollaboratorsSaved: boolean = true;
    public deleteCollaborators: CollaboratorDTO[] = [];
    public area: string
    public isCollaboratorChange = false;

    private startCollaborators = [] as CollaboratorDTO[];


    constructor(private route: ActivatedRoute,
        private userService: UserService,
        private projectService: ProjectService,
        private router: Router,
        private rightService: RightsService,
        private toastService: ToastrService,
        private signalRService: SignalRService) { }

    public ngOnInit(): void {
        this.area = "workspace";
        this.projectService.getProjectCollaborators(this.projectId)
            .subscribe(
                (resp) => {
                    this.SetCollaboratorsFromResponse(resp);
                },
                (error) => {
                    this.toastService.error("'Can\'t load project collaborators.', 'Error Message:'");
                }
            );
    }

    public delete(collaboratorId: number): void {
        const deleteCollaborator = this.newCollaborators.find(item => item.id == collaboratorId);
        this.deleteCollaborators.push(deleteCollaborator);
        const index: number = this.newCollaborators.indexOf(deleteCollaborator);
        if (index !== -1) {
            this.newCollaborators.splice(index, 1);
        }
    }

    public save(): void {
        this.isCollaboratorsSaved = false;
        this.deleteCollaborators.forEach(item => {
            const deleteItem: DeleteCollaboratorRightDTO =
            {
                access: item.access,
                id: item.id,
                nickName: item.nickName,
                projectId: this.projectId
            }
            if (!this.IsSelected(deleteItem)) {
                this.rightService.deleteCollaborator(deleteItem)
                    .subscribe(
                        (resp) => {
                            //this.ref.close();
                        },
                        (error) => {
                            this.toastService.error('Can\'t delete collacortors access', 'Error Message');
                        }
                    );
            }
        });
        this.newCollaborators.forEach(item => {
            const update: UpdateUserRightDTO =
            {
                projectId: this.projectId,
                access: item.access,
                userId: item.id
            }
            this.rightService.setUsersRigths(update)
                .subscribe(
                    (resp) => {
                        this.deleteCollaborators = [];
                        this.startCollaborators = [];
                        this.newCollaborators.forEach(element => {
                            var colaborator: CollaboratorDTO = {
                                id: element.access,
                                nickName: element.nickName,
                                access: element.access
                            }
                            this.startCollaborators.push(colaborator);
                        })
                        this.isCollaboratorsSaved = true;
                        this.isCollaboratorChange = true;
                        this.toastService.success('New collacortors access have successfully saved!');
                    },
                    (error) => {
                        this.isCollaboratorsSaved = true;
                        this.toastService.error('Can\'t save new collacortors access', 'Error Message');
                    }
                );
        });
    }


    public IsNotCollaboratorsChange(): boolean {
        if (this.newCollaborators.length == 0 && this.startCollaborators.length == 0) {
            return true;
        }
        if (this.deleteCollaborators.length != 0) {
            return false;
        }

        if (this.newCollaborators.length != this.startCollaborators.length) {
            return false;
        }

        for (let i in this.newCollaborators) {
            if (this.newCollaborators[i].access !== this.startCollaborators[i].access) {
                return false;
            }
        }
        return true;

    }

    public addCollaborator(newCollaboratorsNickname: UserNicknameDTO): void {
        const newCollaborators: CollaboratorDTO =
        {
            access: 0,
            id: newCollaboratorsNickname.id,
            nickName: newCollaboratorsNickname.nickName,
        }
        this.newCollaborators.push(newCollaborators);
        this.collaborator = null;
    }

    public filterCollarator(event): void {
        const query = event.query;
        this.userService.getUsersNickName().subscribe(collaborator => {
            this.filterCollaborators = this.filter(query, collaborator.body);
        });
    }

    public checkCollaborator(collaborator: UserNicknameDTO): void {
        this.collaborator = null;
        this.router.navigate([`/workspace/${this.projectId}`]);
    }

    public filter(query, collaborators: UserNicknameDTO[]): UserNicknameDTO[] {
        const filtered: UserNicknameDTO[] = [];
        for (let i = 0; i < collaborators.length; i++) {
            const collaborator = collaborators[i];
            if (collaborator.nickName.toLowerCase().indexOf(query.toLowerCase()) !== -1) {
                console.log(this.IsSelected(collaborator));
                if (!this.IsSelected(collaborator)) {
                    filtered.push(collaborator);
                }
            }
        }
        if (filtered.length === 0) {
            const notFound: UserNicknameDTO = {
                id: 0,
                nickName: "We couldn’t find any project matching " + query
            }
            filtered.push(notFound);
        }
        return filtered;
    }

    private IsSelected(collaborator: UserNicknameDTO): boolean {
        let result: boolean = false;
        this.newCollaborators.forEach(element => {
            if (element.id === collaborator.id) {
                result = true;
            }
        });
        return result;
    }

    private SetCollaboratorsFromResponse(resp: HttpResponse<CollaboratorDTO[]>): void {
        this.newCollaborators = resp.body;
        this.newCollaborators.forEach(element => {
            let newElement: CollaboratorDTO =
            {
                id: element.id,
                access: element.access,
                nickName: element.nickName
            }
            this.startCollaborators.push(newElement);
        });
    }
}
