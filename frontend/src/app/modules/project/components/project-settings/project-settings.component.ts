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
import { TokenService } from 'src/app/services/token.service/token.service';

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
    public hasDetailsSaveResponse = true;
    public access: any;
    public collaborators: CollaboratorDTO[];
    public deleteCollaborators: CollaboratorDTO[] = [];
    public colors;

    private unsubscribe$ = new Subject<void>();
    private startCollaborators = [] as CollaboratorDTO[];
    private area:string;

    public projectForm = this.fb.group({
        name: ['', Validators.required],
        description: ['', Validators.required],
        countOfSaveBuilds: ['', [Validators.required, Validators.max(10)]],
        countOfBuildAttempts: ['', [Validators.required, Validators.max(10)]],
        access: ['', Validators.required],
        color: ['', Validators.required]
    });

    constructor(
        private fb: FormBuilder,
        private route: ActivatedRoute,
        private projectService: ProjectService,
        private toastService: ToastrService,
        private router: Router,
        private rightService: RightsService,
        private tokenService: TokenService
    ) { }

    ngOnInit() {
        this.area="projectSettings";
        this.projectId = Number(this.route.snapshot.paramMap.get('id'));
        const userId: number = this.tokenService.getUserId();
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

        this.colors = [
            { label: 'Red', value: '#ff0000' },
            { label: 'Black', value: '#000000' },
            { label: 'Blue', value: '#0080ff' },
            { label: 'Blueviolet', value: '#bf00ff'},
            { label: 'Aqua', value: '#00ffff' },
            { label: 'Dark Magenta', value: '#8b008b' },
            { label: 'Dark Orange', value: '#ff8c00' },
            { label: 'Gold', value: '#ffd700' },
            { label: 'Green', value: '#008000' },
            { label: 'Light Slate Grey', value: '#778899' },
        ]
    }

    public getErrorMessage(field: string): string {
        const control = this.projectForm.get(field);    

        let errorMessage: string;        
        if (control.hasError('required')) {
            errorMessage = 'Value is required!';
        }
        else if(control.hasError('max')) {
            errorMessage = `Quantity must be less than ${control.errors.max.max}!`;
        }
        else if (control.hasError('minlength')) {
            errorMessage = `The length must be at least ${control.errors.minlength.requiredLength} letters!`;
        }
        else if (control.hasError('maxlength')) {
            errorMessage = `The length should be no more than ${control.errors.maxlength.requiredLength} letters!`;
        }
        else {
            errorMessage = 'validation error';
        }

        return errorMessage;
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

    // public onChanged(increase: CollaboratorDTO[]) {
    //     this.collaborators = increase;
    // }

    public IsProjectNotChange(): boolean {
        return this.projectForm.get('name').value === this.projectStartState.name
            && this.projectForm.get('description').value === this.projectStartState.description
            && Number(this.projectForm.get('countOfSaveBuilds').value) === this.projectStartState.countOfSaveBuilds
            && Number(this.projectForm.get('countOfBuildAttempts').value) === this.projectStartState.countOfBuildAttempts
            && this.project.accessModifier === this.projectStartState.accessModifier
            && this.projectForm.get('color').value === this.projectStartState.color;
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
        this.hasDetailsSaveResponse = false;
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
                            (resp)=>
                            {
                            },
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
                            this.hasDetailsSaveResponse = true;
                            this.toastService.success('New collacortors access have successfully saved!');
                        },
                        (error) => {
                            this.hasDetailsSaveResponse = true;
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
                    this.hasDetailsSaveResponse = true;
                    this.toastService.success('New details have successfully saved!');
                },
                (error) => {
                    this.hasDetailsSaveResponse = true;
                    this.toastService.error('Can\'t save new project details', 'Error Message');
                    console.error(error.message);
                }
            );
        }
    }
    private SetProjectObjectsFromResponse(resp: HttpResponse<ProjectUpdateDTO>): void {
        this.project = resp.body;
        this.projectStartState.name = this.project.name;
        this.projectStartState.description = this.project.description;
        this.projectStartState.countOfSaveBuilds = this.project.countOfSaveBuilds;
        this.projectStartState.countOfBuildAttempts = this.project.countOfBuildAttempts;
        this.projectStartState.accessModifier = this.project.accessModifier;
        this.projectStartState.color = this.project.color;
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
