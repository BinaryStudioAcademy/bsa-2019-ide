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
    public colors;
    public projectForm: FormGroup;
    private project: ProjectEditDTO;
    private projectType: ProjectType;

    public projectId: number;
    public projectStartState = {} as ProjectEditDTO;
    public isPageLoaded = false;
    public hasDetailsSaveResponse = true;

    constructor(private ref: DynamicDialogRef,
                private config: DynamicDialogConfig,
                private fb: FormBuilder,
                private projectService: ProjectService,
                private toastrService: ToastrService,
                private router: Router) { }

    ngOnInit(): void { 
        this.projectType = this.config.data.projectType;
        if (!this.isCreateForm()) {
            this.projectId = this.config.data.projectId;
            this.projectService.getProjectById(this.projectId)
                .subscribe(
                    (resp) => {
                        this.SetProjectObjectsFromResponse(resp);
                        console.log(resp);
                        this.isPageLoaded = true;
                    },
                    (error) => {
                        this.isPageLoaded = true;
                        this.toastrService.error('Can\'t load project details.', 'Error Message:');
                        console.error(error.message);
                    }
                );
        }
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
        }

        this.project = {
            color: null,
            compilerType: null,
            countOfBuildAttempts: null,
            countOfSaveBuilds: null,
            description: null,
            language: null,
            name: null,
            projectType: null,
            accessModifier: null,
            id: null
        }
    }
    
    private SetProjectObjectsFromResponse(resp: HttpResponse<ProjectInfoDTO>): void {
        const res = resp.body;
        this.project.id = res.id;
        this.project.name = res.name;
        this.project.description = res.description;
        this.project.countOfSaveBuilds = res.countOfSaveBuilds;
        this.project.countOfBuildAttempts = res.countOfBuildAttempts;
        this.project.color = res.color;
        this.project.accessModifier = res.accessModifier;

        this.projectStartState.id = res.id;
        this.projectStartState.name = res.name;
        this.projectStartState.description = res.description;
        this.projectStartState.countOfSaveBuilds = res.countOfSaveBuilds;
        this.projectStartState.countOfBuildAttempts = res.countOfBuildAttempts;
        this.projectStartState.color = res.color;
        this.projectStartState.accessModifier = res.accessModifier;
    }

    projectItemIsNotChange(): boolean {
        return this.project.name === this.projectStartState.name
        && this.project.description === this.projectStartState.description
        && this.project.countOfSaveBuilds === this.projectStartState.countOfSaveBuilds
        && this.project.countOfBuildAttempts === this.projectStartState.countOfBuildAttempts
        && this.project.color === this.projectStartState.color;
    }

    isCreateForm() {
        return this.projectType === ProjectType.Create;
    }

    onSubmit() {
        console.log(this.project);
        if(this.isCreateForm()) {
            this.projectService.addProject(this.project)
                .subscribe(res => {
                    this.toastrService.success("Project created");
                    let projectId = res.body;
                    this.hasDetailsSaveResponse = true;
                    this.close();
                    this.router.navigate([`/project/${projectId}`]);                },
                    error => {
                        this.toastrService.error('error');                        
                        this.hasDetailsSaveResponse = true;
                    })
        } else {
            this.hasDetailsSaveResponse = false;
            this.projectService.updateProject(this.project)
            .subscribe(
                (resp) => {
                    this.router.navigate([`project/${this.projectId}`]);
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

    close() {
        this.ref.close();
    }
}