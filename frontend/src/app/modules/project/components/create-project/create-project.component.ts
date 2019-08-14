import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ProjectService } from 'src/app/services/project.service/project.service';
import { ProjectCreateDTO } from '../../../../models/DTO/Project/projectCreateDTO';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

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
    public colors: any;
    private project: ProjectCreateDTO;

    public projectForm = this.fb.group({
        name: ['', Validators.required],
        description: ['', Validators.required],
        language: ['', Validators.required],
        projectType: ['', Validators.required],
        compilerType: ['', Validators.required],
        countOfSavedBuilds: ['', Validators.required],
        countOfBuildAttempts: ['', Validators.required],
        color: ['', Validators.required]
    });

    onSubmit() {

        this.project = {
            name: this.projectForm.get('name').value,
            description: this.projectForm.get('description').value,
            language: this.projectForm.get('language').value,
            projectType: this.projectForm.get('projectType').value,
            compilerType: this.projectForm.get('compilerType').value,
            countOfSaveBuilds: this.projectForm.get('countOfSavedBuilds').value,
            countOfBuildAttempts: this.projectForm.get('countOfBuildAttempts').value,
            color: this.projectForm.get('color').value
        };

        console.log(this.project)
        
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

    changeLanguage(e) {
        console.log(e)
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
            case 1 || 2:{
                this.compilerTypes = [
                    { label: 'V8', value: 2 }
                ];
                this.projectTypes = [
                    { label: 'Js/Ts app', value: 3 }
                ];
                break;
            }
            case 3:{
                this.compilerTypes = [
                    { label: 'Gc', value: 3 }
                ];
                this.projectTypes = [
                    { label: 'Go app', value: 4 }
                ];
                break;
            }
      }
    }
    ngOnInit(): void { //Maybe choose initializing
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
    }

    ngOnDestroy(): void {
        this.projectForm = null;
    }
}
