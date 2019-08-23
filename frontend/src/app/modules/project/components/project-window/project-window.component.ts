import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { ProjectService } from 'src/app/services/project.service/project.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { DynamicDialogRef, DynamicDialogConfig } from 'primeng/api';
import { ProjectType } from '../../models/project-type';
import { HttpResponse } from '@angular/common/http';
import { ProjectInfoDTO } from 'src/app/models/DTO/Project/projectInfoDTO';
import { ProjectCreateDTO } from 'src/app/models/DTO/Project/projectCreateDTO';
import { ProjectUpdateDTO } from 'src/app/models/DTO/Project/projectUpdateDTO';
import { CollaboratorDTO } from 'src/app/models/DTO/User/collaboratorDTO';
import { RightsService } from 'src/app/services/rights.service/rights.service';
import { UserNicknameDTO } from 'src/app/models/DTO/User/userNicknameDTO';
import { DeleteCollaboratorRightDTO } from 'src/app/models/DTO/Common/deleteCollaboratorRightDTO';
import { UpdateUserRightDTO } from 'src/app/models/DTO/User/updateUserRightDTO';
import { ProjectDescriptionDTO } from 'src/app/models/DTO/Project/projectDescriptionDTO';
import { ProjDialogDataService } from 'src/app/services/proj-dialog-data.service/proj-dialog-data.service';
import { SignalRService } from 'src/app/services/signalr.service/signal-r.service';
import { TokenService } from 'src/app/services/token.service/token.service';

@Component({
  selector: 'app-project-window',
  templateUrl: './project-window.component.html',
  styleUrls: ['./project-window.component.sass']
})
export class ProjectWindowComponent implements OnInit {
    @ViewChild("uploadElement", {static: false})
    uploadElement: ElementRef | any;
    
    public title: string;
    public languages: any;
    public projectTypes: any;
    public compilerTypes: any;
    public colors: any;
    public access: any;
    public projectForm: FormGroup;
    public area: string;
    public isFileSelected: boolean = false; 

    public isPageLoaded: boolean = false;
    public hasDetailsSaveResponse: boolean = true;

    public projectCreate: ProjectCreateDTO;
    public projectUpdate: ProjectUpdateDTO;

    public collaborators: CollaboratorDTO[];
    public deleteCollaborators: CollaboratorDTO[] = [];
    
    private startCollaborators = [] as CollaboratorDTO[];
    private projectUpdateStartState: ProjectUpdateDTO;
    private projectType: ProjectType;
    private projectId: number;

    constructor(private ref: DynamicDialogRef,
                private config: DynamicDialogConfig,
                private fb: FormBuilder,
                private projectService: ProjectService,
                private toastrService: ToastrService,
                private rightService: RightsService,
                private router: Router,
                private dialogService: ProjDialogDataService,
                private signalRservice: SignalRService,
                private tokenService: TokenService) { }

    ngOnInit(): void { 
        this.projectType = this.config.data.projectType;
        this.title = this.projectType === ProjectType.Create ? 'Create project' : 'Edit project';

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

        this.languages = [
            { label: 'C#', value: 0 },
            { label: 'TypeScript', value: 1 },
            { label: 'JavaScript', value: 2 },
            { label: 'Go', value: 3}
        ];

        this.access = [
            { label: 'Public', value: 0 },
            { label: 'Private', value: 1 }
        ];

        if (this.isCreateForm()) {
            this.isPageLoaded = true;
            this.projectForm = this.fb.group({
                name: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(32)]],
                description: ['', Validators.required],
                language: ['', Validators.required],
                projectType: ['', Validators.required],
                compilerType: ['', Validators.required],
                countOfSavedBuilds: ['', [Validators.required, Validators.max(10)]],
                countOfBuildAttempts: ['', [Validators.required, Validators.max(10)]],
                access: ['', Validators.required],
                color: ['', Validators.required]
            });
            this.projectForm.get('access').setValue(0);
        } else {
            this.projectForm = this.fb.group({
                name: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(32)]],
                description: ['', Validators.required],
                countOfSavedBuilds: ['', [Validators.required, Validators.max(10)]],
                countOfBuildAttempts: ['', [Validators.required, Validators.max(10)]],
                access: ['', Validators.required],
                color: ['', Validators.required]
            });
        }

        if (!this.isCreateForm()) {
            this.area = "projectSettings";
            this.projectId = this.config.data.projectId;
            this.projectService.getProjectById(this.projectId)
                .subscribe(
                    (resp) => {
                        this.InitializeProject(resp);
                        this.title = 'Edit project \"' + resp.body.name + '\"';
                        this.isPageLoaded = true;
                    },
                    (error) => {
                        this.toastrService.error('Can\'t load project details.', 'Error Message:');
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
                        this.toastrService.error("'Can\'t load project collaborators.', 'Error Message:'");
                        console.error(error.message);
                    }
                );
        }
    }
    public resetSelection(){
        this.uploadElement.clear();
        this.isFileSelected = false;
    }
    public selectHandler(){
        this.isFileSelected = true;
    }
    
    public projectItemIsNotChange(): boolean {
        return this.IsProjectNotChange()
            && this.IsCollaboratorChange();
    }

    public IsProjectNotChange(): boolean {
        return this.projectForm.get('name').value === this.projectUpdateStartState.name
        && this.projectForm.get('description').value === this.projectUpdateStartState.description
        && this.projectForm.get('countOfSavedBuilds').value === this.projectUpdateStartState.countOfSaveBuilds
        && this.projectForm.get('countOfBuildAttempts').value === this.projectUpdateStartState.countOfBuildAttempts
        && this.projectForm.get('color').value === this.projectUpdateStartState.color;
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

    public isCreateForm() {
        return this.projectType === ProjectType.Create;
    }

    public delete(collaboratorId: number): void {
        const deleteCollaborator = this.collaborators.find(item => item.id == collaboratorId);
        this.deleteCollaborators.push(deleteCollaborator);
        const index: number = this.collaborators.indexOf(deleteCollaborator);
        if (index !== -1) {
            this.collaborators.splice(index, 1);
        }
    }

    public onSubmit() {
        if(this.isCreateForm()) {
            this.getValuesForProjectCreate();
            const formData = new FormData();

            for (let [key, value] of Object.entries(this.projectCreate)) {
                formData.append(key, value.toString());                
            }

            if (this.isFileSelected){
                formData.append(this.uploadElement.files[0].name, this.uploadElement.files[0]);                
            }

            this.projectService.addProject(formData)
                .subscribe(res => {
                        this.toastrService.success("Project created");
                        let projectId = res.body;
                        this.hasDetailsSaveResponse = true;
                        this.close();
                        const userId=this.tokenService.getUserId();
                        this.signalRservice.addToGroup(userId);
                        this.router.navigate([`/project/${projectId}`]);   
                    },
                    error => {
                        this.toastrService.error('error');                        
                        this.hasDetailsSaveResponse = true;
                    })
        } else {
            this.hasDetailsSaveResponse = false;
            if (!this.IsProjectNotChange()) {
                this.getValuesForProjectUpdate();
                this.projectService.updateProject(this.projectUpdate)
                .subscribe(
                    (resp) => {
                        this.hasDetailsSaveResponse = true;
                        this.toastrService.success('New details have successfully saved!');
                        this.dialogService.addProject(this.projectInfoToProjectDesc(resp.body));
                        this.close();
                    },
                    (error) => {
                        this.hasDetailsSaveResponse = true;
                        this.toastrService.error('Can\'t save new project details', 'Error Message');
                        console.error(error.message);
                    }
                );
            }
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
                                    this.toastrService.error('Can\'t delete collacortors access', 'Error Message');
                                }
                            );
                    }
                });
                for (let i in this.collaborators) {
                    if (this.collaborators[i].access !== this.startCollaborators[i].access) {
                        const update: UpdateUserRightDTO =
                        {
                            projectId:this.projectId,
                            access: this.collaborators[i].access,
                            userId: this.collaborators[i].id
                        }
                        this.rightService.setUsersRigths(update)
                        .subscribe(
                            (resp) => {
                                this.router.navigate([`project/${this.projectId}`]);
                                this.hasDetailsSaveResponse = true;
                                this.toastrService.success('New collacortors access have successfully saved!');
                            },
                            (error) => {
                                this.hasDetailsSaveResponse = true;
                                this.toastrService.error('Can\'t save new collacortors access', 'Error Message');
                            }
                        );
                    }
                }
            }
        }
    }

    private projectInfoToProjectDesc(project: ProjectInfoDTO): ProjectDescriptionDTO {
        return {
            color: project.color,
            creatorId: project.authorId,
            id: project.id,
            created: project.createdAt,
            creator: project.authorName,
            favourite: true,
            title: project.name
        }
    }    

    public changeLanguage(e: number) {
        switch(e){
            case 0:{
                this.compilerTypes = [
                    { label: 'CoreCLR', value: 0 },
                    { label: 'Roslyn', value: 1 }
                ];
                this.projectTypes = [
                    { label: 'Console App', value: 0 },
                    { label: 'Web App', value: 1 },
                    { label: 'Library', value: 2 }
                ];
                break;
            }
            case 1:{
                this.compilerTypes = [
                    { label: 'V8', value: 2 }
                ];
                this.projectTypes = [
                    { label: 'Console App', value: 0 },
                ];
                break;
            }
            case 2:{
                this.compilerTypes = [
                    { label: 'V8', value: 2 }
                ];
                this.projectTypes = [
                    { label: 'Console App', value: 0 },
                ];
                break;
            }
            case 3:{
                this.compilerTypes = [
                    { label: 'Gc', value: 3 }
                ];
                this.projectTypes = [
                    { label: 'Console App', value: 0 },
                ];
                break;
            }
        }
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

    public close() {
        this.ref.close();
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

    private InitializeProject(resp: HttpResponse<ProjectInfoDTO>) {
        this.projectUpdateStartState = resp.body;
        this.projectForm.setValue({ 
            name: this.projectUpdateStartState.name,
            description: this.projectUpdateStartState.description,
            countOfSavedBuilds: this.projectUpdateStartState.countOfSaveBuilds,
            countOfBuildAttempts: this.projectUpdateStartState.countOfBuildAttempts,
            color: this.projectUpdateStartState.color,
            access: this.projectUpdateStartState.accessModifier
        });
    }

    private getValuesForProjectUpdate() {
        this.projectUpdate = {
            accessModifier: this.projectForm.get('access').value,
            color: this.projectForm.get('color').value,
            countOfBuildAttempts: this.projectForm.get('countOfBuildAttempts').value,
            countOfSaveBuilds: this.projectForm.get('countOfSavedBuilds').value,
            description: this.projectForm.get('description').value,
            id: this.projectId,
            name: this.projectForm.get('name').value
        }
    }

    private getValuesForProjectCreate() {
        this.projectCreate = {
            name: this.projectForm.get('name').value,
            description: this.projectForm.get('description').value,
            access: this.projectForm.get('access').value,
            color: this.projectForm.get('color').value,
            compilerType: this.projectForm.get('compilerType').value,
            countOfBuildAttempts: this.projectForm.get('countOfBuildAttempts').value,
            countOfSaveBuilds: this.projectForm.get('countOfSavedBuilds').value,
            language: this.projectForm.get('language').value,
            projectType: this.projectForm.get('projectType').value
        }
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
