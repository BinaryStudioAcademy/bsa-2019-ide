import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { ProjectService } from 'src/app/services/project.service/project.service';
import { ToastrService } from 'ngx-toastr';
import { DynamicDialogRef, DynamicDialogConfig } from 'primeng/api';
import { HttpResponse } from '@angular/common/http';
import { ProjectInfoDTO } from 'src/app/models/DTO/Project/projectInfoDTO';
import { ProjectUpdateDTO } from 'src/app/models/DTO/Project/projectUpdateDTO';
import { ProjectDescriptionDTO } from 'src/app/models/DTO/Project/projectDescriptionDTO';
import { ProjDialogDataService } from 'src/app/services/proj-dialog-data.service/proj-dialog-data.service';
import { AccessModifier } from 'src/app/models/Enums/accessModifier';

@Component({
    selector: 'app-project-update',
    templateUrl: './project-update.component.html',
    styleUrls: ['./project-update.component.sass']
})
export class ProjectUpdateComponent implements OnInit {
    public title: string;
    public languages: { label: string, value: number }[];
    public projectTypes: any;
    public compilerTypes: any;
    public colors: { label: string, value: string }[];
    public access: any;
    public projectForm: FormGroup;
    public isFileSelected: boolean = false;

    public isPageLoaded: boolean = false;
    public hasDetailsSaveResponse: boolean = true;

    public projectUpdate: ProjectUpdateDTO;

    private projectUpdateStartState: ProjectUpdateDTO;
    private projectId: number;

    constructor(private ref: DynamicDialogRef,
        private config: DynamicDialogConfig,
        private fb: FormBuilder,
        private projectService: ProjectService,
        private toastrService: ToastrService,
        private dialogService: ProjDialogDataService) { }

    ngOnInit(): void {

        this.title = 'Edit project';

        this.colors = [
            { label: 'Red', value: '#ff0000' },
            { label: 'Black', value: '#000000' },
            { label: 'Blue', value: '#0000ff' },
            { label: 'Blueviolet', value: '#bf00ff' },
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
            { label: 'Go', value: 3 }
        ];

        this.access = [
            { label: 'Public', value: 0 },
            { label: 'Private', value: 1 }
        ];


        this.projectForm = this.fb.group({
            name: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(32), Validators.pattern(/^[A-Z0-9]+$/i)]],
            description: ['', Validators.required],
            countOfSavedBuilds: ['', [Validators.required, Validators.max(10)]],
            countOfBuildAttempts: ['', [Validators.required, Validators.max(10)]],
            access: ['', Validators.required],
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
                    this.toastrService.error('Can\'t load project details.', 'Error Message:');
                    console.error(error.message);
                }
            );
    }
    public resetSelection() {
        this.isFileSelected = false;
    }
    public selectHandler() {
        this.isFileSelected = true;
    }

    public projectItemIsNotChange(): boolean {
        return this.IsProjectNotChange();
    }

    public IsProjectNotChange(): boolean {
        return this.projectForm.get('name').value === this.projectUpdateStartState.name
            && this.projectForm.get('description').value === this.projectUpdateStartState.description
            && this.projectForm.get('countOfSavedBuilds').value === this.projectUpdateStartState.countOfSaveBuilds
            && this.projectForm.get('countOfBuildAttempts').value === this.projectUpdateStartState.countOfBuildAttempts
            && this.projectForm.get('color').value === this.projectUpdateStartState.color
            && this.projectForm.get('access').value === this.projectUpdateStartState.accessModifier;
    }
    public onSubmit() {
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
    }

    private projectInfoToProjectDesc(project: ProjectInfoDTO): ProjectDescriptionDTO {
        
        return {
            color: project.color,
            amountOfMembers: project.amountOfMembers,
            description: project.description,
            language: project.language,
            projectType: project.projectType,
            creatorId: project.authorId,
            id: project.id,
            created: project.createdAt,
            creator: project.authorName,
            favourite: true,
            title: project.name,
            isPublic: project.accessModifier == AccessModifier.public
        }
    }

    public getErrorMessage(field: string): string {
        const control = this.projectForm.get(field);

        let errorMessage: string;
        if (control.hasError('required')) {
            errorMessage = 'Value is required!';
        }
        else if (control.hasError('max')) {
            errorMessage = `Quantity must be less than ${control.errors.max.max}!`;
        }
        else if (control.hasError('minlength')) {
            errorMessage = `The length must be at least ${control.errors.minlength.requiredLength} letters!`;
        }
        else if (control.hasError('maxlength')) {
            errorMessage = `The length should be no more than ${control.errors.maxlength.requiredLength} letters!`;
        }
        else if (control.hasError('pattern')) {

            errorMessage = field === "githuburl" ? "https://github.com/user/repository wrong github pattern " : `This field can contain only latin letters and numbers!`;
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
            color: this.colors.find(c => c.value === this.projectUpdateStartState.color).value,
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
}