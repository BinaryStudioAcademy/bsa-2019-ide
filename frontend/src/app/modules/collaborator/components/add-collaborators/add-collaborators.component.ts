import { Component, OnInit } from '@angular/core';
import { UserNicknameDTO } from '../../../../models/DTO/User/userNicknameDTO';
import { UserService } from 'src/app/services/user.service/user.service';
import { CollaboratorDTO } from 'src/app/models/DTO/User/collaboratorDTO';
import { ProjectService } from 'src/app/services/project.service/project.service';
import { DynamicDialogRef, DynamicDialogConfig } from 'primeng/api';
import { ToastrService } from 'ngx-toastr';
import { HttpResponse } from '@angular/common/http';
import { RightsService } from 'src/app/services/rights.service/rights.service'
import { UpdateUserRightDTO } from 'src/app/models/DTO/User/updateUserRightDTO';
import { ActivatedRoute, Router } from '@angular/router';
import { DeleteCollaboratorRightDTO } from 'src/app/models/DTO/Common/deleteCollaboratorRightDTO';

@Component({
    selector: 'app-add-collaborators',
    templateUrl: './add-collaborators.component.html',
    styleUrls: ['./add-collaborators.component.sass']
})
export class AddCollaboratorsComponent implements OnInit {

    public collaborator: UserNicknameDTO;
    public filterCollaborators: UserNicknameDTO[];
    public newCollaborators: CollaboratorDTO[] = [];
    public isCollaboratorsSaved: boolean = true;
    public projectId: number = 11;
    public deleteCollaborators: CollaboratorDTO[] = [];

    private startCollaborators = [] as CollaboratorDTO[];

    constructor(private route: ActivatedRoute,
        private userService: UserService,
        private projectService: ProjectService,
        public config: DynamicDialogConfig,
        public ref: DynamicDialogRef,
        private router: Router,
        private rightService: RightsService,
        private toastService: ToastrService) { }

    public ngOnInit(): void {
        this.projectService.getProjectCollaborators(this.projectId)
            .subscribe(
                (resp) => {

                    this.SetCollaboratorsFromResponse(resp);
                    //this.isPageLoaded = true;
                },
                (error) => {
                    //this.isPageLoaded = true;
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
                id: item.id,
                access: item.access,
                nickName: item.nickName,
                projectId: this.projectId
            }
            console.log(deleteItem);
            this.rightService.deleteCollaborator(deleteItem)
                .subscribe(
                    (resp) => {
                        this.router.navigate([`workspace/${this.projectId}`]);
                    },
                    (error) => {
                        this.toastService.error('Can\'t delete collacortors access', 'Error Message');
                    }
                );
        });
        for (let i in this.newCollaborators) {
            const update: UpdateUserRightDTO =
            {
                projectId: this.projectId,
                access: this.newCollaborators[i].access,
                userId: this.newCollaborators[i].id
            }
            this.rightService.setUsersRigths(update)
                .subscribe(
                    (resp) => {
                        this.router.navigate([`workspace/${this.projectId}`]);
                        this.isCollaboratorsSaved = true;
                        this.toastService.success('New collacortors access have successfully saved!');
                    },
                    (error) => {
                        this.isCollaboratorsSaved = true;
                        this.toastService.error('Can\'t save new collacortors access', 'Error Message');
                    }
                );
        }
    }


    public IsNotCollaboratorsChange(): boolean {
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

    public addCollaborator(newCollaboratorsNickname: UserNicknameDTO) {
        const newCollaborators: CollaboratorDTO =
        {
            id: newCollaboratorsNickname.id,
            nickName: newCollaboratorsNickname.nickName,
            access: 0
        }
        this.newCollaborators.push(newCollaborators);
        this.collaborator = null;
    }

    private SetCollaboratorsFromResponse(resp: HttpResponse<CollaboratorDTO[]>): void {
        console.log(resp.body);
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

    public close(): void {
        this.ref.close();
    }

    public filterCollarator(event): void {
        const query = event.query;
        this.userService.getUsersNickName().subscribe(collaborator => {
            this.filterCollaborators = this.filter(query, collaborator.body);
        });
    }

    public checkCollaborator(collaborator: UserNicknameDTO): void {
        this.collaborator = null;
        console.log(collaborator);
        //this.router.navigate([`/project/${project.id}`]);
    }

    public filter(query, collaborators: UserNicknameDTO[]): UserNicknameDTO[] {
        const filtered: UserNicknameDTO[] = [];
        for (let i = 0; i < collaborators.length; i++) {
            const collaborator = collaborators[i];
            if (collaborator.nickName.toLowerCase().indexOf(query.toLowerCase()) !== -1) {
                filtered.push(collaborator);
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
}