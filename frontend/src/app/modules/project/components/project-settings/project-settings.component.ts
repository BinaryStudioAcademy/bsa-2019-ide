import { HttpResponse } from '@angular/common/http';
import { ProjectUpdateDTO } from './../../../../models/DTO/Project/projectUpdateDTO';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import { ProjectService } from 'src/app/services/project.service/project.service';
import { takeUntil } from 'rxjs/operators';
import { FormBuilder, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
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
    public isDetailsSaved = true;
    public colors;

    private unsubscribe$ = new Subject<void>();

    public projectForm = this.fb.group({
        name: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(32)]],
        description: ['', Validators.required],
        countOfSaveBuilds: ['', [Validators.required, Validators.max(10)]],
        countOfBuildAttempts: ['', [Validators.required, Validators.max(10)]],
        color: ['', Validators.required]
    });

    constructor(
        private fb: FormBuilder,
        private route: ActivatedRoute,
        private projectService: ProjectService,
        private toastService: ToastrService,
        private tokenService: TokenService,
        private router: Router
    ) { }

    ngOnInit() {
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
                this.isPageLoaded = true;
            },
            (error) => {
                this.isPageLoaded = true;
                this.toastService.error('Can\'t load project details.', 'Error Message:');
                console.error(error.message);
            }
        );

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

    projectItemIsNotChange(): boolean {
        return this.projectForm.get('name').value === this.projectStartState.name
        && this.projectForm.get('description').value === this.projectStartState.description
        && Number(this.projectForm.get('countOfSaveBuilds').value) === this.projectStartState.countOfSaveBuilds
        && Number(this.projectForm.get('countOfBuildAttempts').value) === this.projectStartState.countOfBuildAttempts
        && this.projectForm.get('color').value === this.projectStartState.color;
    }

    ngOnDestroy() {
        takeUntil(this.unsubscribe$);
    }

    onSubmit() {
        this.isDetailsSaved = false;
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

    public getErrorMessage(field: string): string {
        const control = this.projectForm.get(field);
        const isMaxError: boolean = !!control.errors && !!control.errors.max;
        const isMinLengthError: boolean = !!control.errors && !!control.errors.minlength;
        const isMaxLengthError: boolean = !!control.errors && !!control.errors.maxlength;

        return control.hasError('required')
                ? 'Value is required!'
            : (isMaxError)
                ? `Quantity must be less than ${control.errors.max.max}!`
            : (isMinLengthError)
                ? `The length must be at least ${control.errors.minlength.requiredLength} letters!`
            : (isMaxLengthError)
                ? `The length should be no more than ${control.errors.maxlength.requiredLength} letters!`
                    : 'validation error';
    }

    private SetProjectObjectsFromResponse(resp: HttpResponse<ProjectUpdateDTO>): void {
        this.project = resp.body;
        this.projectStartState.name = this.project.name;
        this.projectStartState.description = this.project.description;
        this.projectStartState.countOfSaveBuilds = this.project.countOfSaveBuilds;
        this.projectStartState.countOfBuildAttempts = this.project.countOfBuildAttempts;
        this.projectStartState.color = this.project.color;
    }

}
