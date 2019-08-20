import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { ProjectService } from 'src/app/services/project.service/project.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { DynamicDialogRef, DynamicDialogConfig } from 'primeng/api';
import { ProjectType } from '../../models/project-type';
import { HttpResponse } from '@angular/common/http';
import { ProjectEditDTO } from 'src/app/models/DTO/Project/projectEditDTO';
import { ProjectInfoDTO } from 'src/app/models/DTO/Project/projectInfoDTO';
import { ProjectCreateDTO } from 'src/app/models/DTO/Project/projectCreateDTO';
import { ProjectUpdateDTO } from 'src/app/models/DTO/Project/projectUpdateDTO';

@Component({
  selector: 'app-project-window',
  templateUrl: './project-window.component.html',
  styleUrls: ['./project-window.component.sass']
})
export class ProjectWindowComponent implements OnInit {
    public title: string;
    public languages: any;
    public projectTypes: any;
    public compilerTypes: any;
    public colors: any;
    public projectForm: FormGroup;

    public isPageLoaded: boolean = false;
    public hasDetailsSaveResponse: boolean = true;

    public projectCreate: ProjectCreateDTO;
    public projectUpdate: ProjectUpdateDTO;

    private projectUpdateStartState: ProjectUpdateDTO;
    private projectType: ProjectType;
    private projectId: number;

    constructor(private ref: DynamicDialogRef,
                private config: DynamicDialogConfig,
                private fb: FormBuilder,
                private projectService: ProjectService,
                private toastrService: ToastrService,
                private router: Router) { }

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

        if (this.isCreateForm()) {
            this.projectForm = this.fb.group({
                name: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(32)]],
                description: ['', Validators.required],
                language: ['', Validators.required],
                projectType: ['', Validators.required],
                compilerType: ['', Validators.required],
                countOfSavedBuilds: ['', [Validators.required, Validators.max(10)]],
                countOfBuildAttempts: ['', [Validators.required, Validators.max(10)]],
                color: ['', Validators.required]
            });
        } else {
            this.projectForm = this.fb.group({
                name: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(32)]],
                description: ['', Validators.required],
                countOfSavedBuilds: ['', [Validators.required, Validators.max(10)]],
                countOfBuildAttempts: ['', [Validators.required, Validators.max(10)]],
                color: ['', Validators.required]
            });
            this.projectId = this.config.data.projectId;
            this.projectService.getProjectById(this.projectId)
                .subscribe(
                    (resp) => {
                        this.InitializeProject(resp);
                        this.title = 'Edit project \"' + resp.body.name + '\"';
                        this.isPageLoaded = true;
                    },
                    (error) => {
                        this.isPageLoaded = true;
                        this.toastrService.error('Can\'t load project details.', 'Error Message:');
                        console.error(error.message);
                    }
                );
        }

        if (this.isCreateForm()) {
            this.projectCreate = {
                color: null,
                compilerType: null,
                countOfBuildAttempts: null,
                countOfSaveBuilds: null,
                description: null,
                language: null,
                name: null,
                projectType: null
            }
        } else {
            this.projectUpdate = {
                color: null,
                countOfBuildAttempts: null,
                countOfSaveBuilds: null,
                description: null,
                name: null,
                accessModifier: null,
                id: null
            }
        }
    }

    public projectItemIsNotChange(): boolean {
        return this.projectForm.get('name').value === this.projectUpdateStartState.name
        && this.projectForm.get('description').value === this.projectUpdateStartState.description
        && this.projectForm.get('countOfSavedBuilds').value === this.projectUpdateStartState.countOfSaveBuilds
        && this.projectForm.get('countOfBuildAttempts').value === this.projectUpdateStartState.countOfBuildAttempts
        && this.projectForm.get('color').value === this.projectUpdateStartState.color;
    }

    public isCreateForm() {
        return this.projectType === ProjectType.Create;
    }

    public onSubmit() {
        if(this.isCreateForm()) {
            this.getValuesForProjectCreate();
            this.projectService.addProject(this.projectCreate)
                .subscribe(res => {
                        this.toastrService.success("Project created");
                        let projectId = res.body;
                        this.hasDetailsSaveResponse = true;
                        this.close();
                        this.router.navigate([`/project/${projectId}`]);   
                    },
                    error => {
                        this.toastrService.error('error');                        
                        this.hasDetailsSaveResponse = true;
                    })
        } else {
            this.getValuesForProjectUpdate();
            this.hasDetailsSaveResponse = false;
            this.projectService.updateProject(this.projectUpdate)
            .subscribe(
                (resp) => {
                    this.hasDetailsSaveResponse = true;
                    this.toastrService.success('New details have successfully saved!');
                    this.close();
                },
                (error) => {
                    this.hasDetailsSaveResponse = true;
                    this.toastrService.error('Can\'t save new project details', 'Error Message');
                    console.error(error.message);
                }
            );
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
        
    private InitializeProject(resp: HttpResponse<ProjectInfoDTO>) {
        this.projectUpdateStartState = resp.body;
        this.projectForm.setValue({ 
            name: this.projectUpdateStartState.name,
            description: this.projectUpdateStartState.description,
            countOfSavedBuilds: this.projectUpdateStartState.countOfSaveBuilds,
            countOfBuildAttempts: this.projectUpdateStartState.countOfBuildAttempts,
            color: this.projectUpdateStartState.color
        });
    }

    private getValuesForProjectUpdate() {
        this.projectUpdate.name = this.projectForm.get('name').value;
        this.projectUpdate.description = this.projectForm.get('description').value;
        this.projectUpdate.countOfSaveBuilds = this.projectForm.get('countOfSavedBuilds').value;
        this.projectUpdate.countOfBuildAttempts = this.projectForm.get('countOfBuildAttempts').value;
        this.projectUpdate.color = this.projectForm.get('color').value;
    }

    private getValuesForProjectCreate() {
        this.projectCreate.name = this.projectForm.get('name').value;
        this.projectCreate.color = this.projectForm.get('color').value;
        this.projectCreate.compilerType = this.projectForm.get('compilerType').value;
        this.projectCreate.countOfBuildAttempts = this.projectForm.get('countOfBuildAttempts').value;
        this.projectCreate.countOfSaveBuilds = this.projectForm.get('countOfSavedBuilds').value;
        this.projectCreate.description = this.projectForm.get('description').value;
        this.projectCreate.language = this.projectForm.get('language').value;
        this.projectCreate.projectType = this.projectForm.get('projectType').value;
    }
}
