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

  private unsubscribe$ = new Subject<void>();

  public projectForm = this.fb.group({
    name: ['', Validators.required],
    description: ['', Validators.required],
    countOfSaveBuilds: ['', Validators.required],
    countOfBuildAttempts: ['', Validators.required]
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
  }

  projectItemIsNotChange(): boolean {
    return this.projectForm.get('name').value === this.projectStartState.name
      && this.projectForm.get('description').value === this.projectStartState.description
      && Number(this.projectForm.get('countOfSaveBuilds').value) === this.projectStartState.countOfSaveBuilds
      && Number(this.projectForm.get('countOfBuildAttempts').value) === this.projectStartState.countOfBuildAttempts;
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
    return control.hasError('required') ? 'Field is required!' : 'error';
  }

  private SetProjectObjectsFromResponse(resp: HttpResponse<ProjectUpdateDTO>): void {
    this.project = resp.body;
    this.projectStartState.name = this.project.name;
    this.projectStartState.description = this.project.description;
    this.projectStartState.countOfSaveBuilds = this.project.countOfSaveBuilds;
    this.projectStartState.countOfBuildAttempts = this.project.countOfBuildAttempts;
  }

}
