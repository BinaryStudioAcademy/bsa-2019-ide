import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ProjectService } from 'src/app/services/project.service/project.service';
import { ProjectCreateDTO } from '../../../../models/DTO/Project/projectCreateDTO';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { UserDTO } from 'src/app/models/DTO/User/userDTO';

@Component({
    selector: 'app-create-project',
    templateUrl: './create-project.component.html',
    styleUrls: ['./create-project.component.sass']
})
export class CreateProjectComponent implements OnInit, OnDestroy {

    constructor(
        private fb: FormBuilder,
        private projectService: ProjectService,
        private toastrService: ToastrService,
        private router: Router) { }

    public languages: any;
    public projectTypes: any;
    public compilerTypes: any;
    private project: ProjectCreateDTO;

    public projectForm = this.fb.group({
        name: ['', Validators.required],
        description: ['', Validators.required],
        language: ['', Validators.required],
        projectType: ['', Validators.required],
        compilerType: ['', Validators.required],
        countOfSavedBuilds: ['', Validators.required],
        countOfBuildAttempts: ['', Validators.required]
    });

    onSubmit() {

        this.project = {
            name: this.projectForm.get('name').value,
            description: this.projectForm.get('description').value,
            authorId: 3, // set on back
            language: this.projectForm.get('language').value,
            projectType: this.projectForm.get('projectType').value,
            compilerType: this.projectForm.get('compilerType').value,
            countOfSaveBuilds: this.projectForm.get('countOfSavedBuilds').value,
            countOfBuildAttempts: this.projectForm.get('countOfBuildAttempts').value
        };


        this.projectService.addProject(this.project)
            .subscribe(res => {
                this.toastrService.success("Project created");
                let projectId = res.body;
                this.router.navigate([`/project/${projectId}`]);
            },
                error => {
                    this.toastrService.error('error');
                })
    }

    ngOnInit(): void { 
        this.languages = [
            { label: 'C#', value: 0 },
            { label: 'TypeScript', value: 1 }
        ];

        this.compilerTypes = [
            { label: '.Net Core', value: 0 }
        ];

        this.projectTypes = [
            { label: 'Console App', value: 0 },
            { label: 'Web App', value: 1 },
            { label: 'Library', value: 2 }
        ];
    }

    ngOnDestroy(): void {
        this.projectForm = null;
    }
}
