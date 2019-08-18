import { HttpResponse } from '@angular/common/http';
import { ProjectUpdateDTO } from './../../../../models/DTO/Project/projectUpdateDTO';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import { ProjectService } from 'src/app/services/project.service/project.service';
import { takeUntil } from 'rxjs/operators';
import { FormBuilder, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { CollaboratorDTO } from 'src/app/models/DTO/User/collaboratorDTO';
import { RightsService } from 'src/app/services/rights.service/rights.service'
import { UpdateUserRightDTO } from 'src/app/models/DTO/User/updateUserRightDTO';
import { DeleteCollaboratorRightDTO } from 'src/app/models/DTO/Common/deleteCollaboratorRightDTO';
import { UserNicknameDTO } from 'src/app/models/DTO/User/userNicknameDTO';

@Component({
    selector: 'app-project-settings',
    templateUrl: './project-settings.component.html',
    styleUrls: ['./project-settings.component.sass']
})
export class ProjectSettingsComponent implements OnInit, OnDestroy {
    public projectId: number;
    public project: ProjectUpdateDTO;
    public projectStartState = {} as ProjectUpdateDTO;
    public isPageLoaded = false;
    public isDetailsSaved = true;
    public access: any;
    public collaborators: CollaboratorDTO[];
    public deleteCollaborators: CollaboratorDTO[] = [];

    private unsubscribe$ = new Subject<void>();
    private startCollaborators = [] as CollaboratorDTO[];

    public projectForm = this.fb.group({
        name: ['', Validators.required],
        description: ['', Validators.required],
        countOfSaveBuilds: ['', [Validators.required, Validators.max(10)]],
        countOfBuildAttempts: ['', [Validators.required, Validators.max(10)]],
        access: ['', Validators.required]
    });

    constructor(
        private fb: FormBuilder,
        private route: ActivatedRoute,
        private projectService: ProjectService,
        private toastService: ToastrService,
        private router: Router,
        private rightService: RightsService,
    ) { }

    ngOnInit() {
        this.projectId = Number(this.route.snapshot.paramMap.get('id'));
        if (!this.projectId) {
            console.error('Id in URL is not a number!');
            return;
        }
        this.projectService.getProjectById(this.projectId)
            .subscribe(
                (resp) => {
                    this.SetProjectObjectsFromResponse(resp);
                },
                (error) => {
                    this.toastService.error('Can\'t load project details.', 'Error Message:');
                    console.error(error.message);
                }
            );
        this.projectService.getProjectCollaborators(this.projectId)
            .subscribe(
                (resp) => {
                    this.SetCollaboratorsFromResponse(resp);
                    this.isPageLoaded = true;
                },
                (error) => {
                    this.isPageLoaded = true;
                    this.toastService.error("'Can\'t load project collaborators.', 'Error Message:'");
                }
            );

        this.access = [
            { label: 'Public', value: 0 },
            { label: 'Private', value: 1 }
        ];
    }

    public delete(collaboratorId: number): void {
        const deleteCollaborator = this.collaborators.find(item => item.id == collaboratorId);
        this.deleteCollaborators.push(deleteCollaborator);
        const index: number = this.collaborators.indexOf(deleteCollaborator);
        if (index !== -1) {
            this.collaborators.splice(index, 1);
        }
    }

    public projectItemIsNotChange(): boolean {
        return this.IsProjectNotChange()
            && this.IsCollaboratorChange();
    }

    public onChanged(increase: CollaboratorDTO[]) {
        this.collaborators = increase;
    }

    public IsProjectNotChange(): boolean {
        return this.projectForm.get('name').value === this.projectStartState.name
            && this.projectForm.get('description').value === this.projectStartState.description
            && Number(this.projectForm.get('countOfSaveBuilds').value) === this.projectStartState.countOfSaveBuilds
            && Number(this.projectForm.get('countOfBuildAttempts').value) === this.projectStartState.countOfBuildAttempts
            && this.project.accessModifier === this.projectStartState.accessModifier;
    }

    public IsCollaboratorChange(): boolean {
        if(this.deleteCollaborators.length!=0)
        {
            return false;
        }
        for (let i in this.collaborators) {
            if (this.collaborators[i].access !== this.startCollaborators[i].access) {
                return false;
            }
        }
        return true;
    }

    ngOnDestroy() {
        takeUntil(this.unsubscribe$);
    }

    private IsSelected(collaborator: UserNicknameDTO): boolean {
        let result: boolean = false;
        this.collaborators.forEach(element => {
            if (element.id === collaborator.id) {
                result = true;
            }
        });
        return result;
    }

    onSubmit() {
        this.isDetailsSaved = false;
        if (!this.IsCollaboratorChange()) {
            this.deleteCollaborators.forEach(item => {
                const deleteItem: DeleteCollaboratorRightDTO =
                {
                    id: item.id,
                    access: item.access,
                    nickName: item.nickName,
                    projectId: this.projectId
                }
                if (!this.IsSelected(deleteItem)) {
                    this.rightService.deleteCollaborator(deleteItem)
                        .subscribe(
                            (error) => {
                                this.toastService.error('Can\'t delete collacortors access', 'Error Message');
                            }
                        );
                }
            });
            for (let i in this.collaborators) {
                if (this.collaborators[i].access !== this.startCollaborators[i].access) {
                    const update: UpdateUserRightDTO=
                    {
                        projectId:this.project.id,
                        access: this.collaborators[i].access,
                        userId: this.collaborators[i].id
                    }
                    this.rightService.setUsersRigths(update)
                    .subscribe(
                        (resp) => {
                            this.router.navigate([`project/${this.projectId}`]);
                            this.isDetailsSaved = true;
                            this.toastService.success('New collacortors access have successfully saved!');
                        },
                        (error) => {
                            this.isDetailsSaved = true;
                            this.toastService.error('Can\'t save new collacortors access', 'Error Message');
                        }
                    );
                }
            }
        }
        if (this.IsProjectNotChange())
        {
        this.projectService.updateProject(this.project)
            .subscribe(
                (resp) => {
                    this.router.navigate([`project/${this.projectId}`]);
                    this.isDetailsSaved = true;
                    this.toastService.success('New details have successfully saved!');
                },
                (error) => {
                    this.isDetailsSaved = true;
                    this.toastService.error('Can\'t save new project details', 'Error Message');
                    console.error(error.message);
                }
            );
        }
    }

    public getErrorMessage(field: string): string {
        const control = this.projectForm.get(field);
        const isMaxError: boolean = !!control.errors && !!control.errors.max;
        return control.hasError('required')
            ? 'Value is required!'
            : (isMaxError)
                ? `Quantity must be less than ${control.errors.max.max}!`
                : 'validation error';
    }

    private SetProjectObjectsFromResponse(resp: HttpResponse<ProjectUpdateDTO>): void {
        this.project = resp.body;
        this.projectStartState.name = this.project.name;
        this.projectStartState.description = this.project.description;
        this.projectStartState.countOfSaveBuilds = this.project.countOfSaveBuilds;
        this.projectStartState.countOfBuildAttempts = this.project.countOfBuildAttempts;
        this.projectStartState.accessModifier = this.project.accessModifier;
    }

    private SetCollaboratorsFromResponse(resp: HttpResponse<CollaboratorDTO[]>): void {
        this.collaborators = resp.body;
        this.collaborators.forEach(element => {
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
