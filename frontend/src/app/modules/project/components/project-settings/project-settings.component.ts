import { HttpResponse } from '@angular/common/http';
import { ProjectUpdateDTO } from './../../../../models/DTO/Project/projectUpdateDTO';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { ProjectInfoDTO } from 'src/app/models/DTO/Project/projectInfoDTO';
import { Subject } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { ProjectService } from 'src/app/services/project.service/project.service';
import { takeUntil, map } from 'rxjs/operators';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-project-settings',
  templateUrl: './project-settings.component.html',
  styleUrls: ['./project-settings.component.sass']
})
export class ProjectSettingsComponent implements OnInit, OnDestroy {
  public projectId: number;
  public project: ProjectUpdateDTO;
  public projectStartState = {} as ProjectUpdateDTO;

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
    private projectService: ProjectService
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
    console.log('submit click');
    this.projectService.updateProject(this.project)
      .subscribe(
        (resp) => {
          this.SetProjectObjectsFromResponse(resp);
        },
        (error) => {
          console.error(error.message);
        }
      );
  }

  private SetProjectObjectsFromResponse(resp: HttpResponse<ProjectUpdateDTO>) {
    this.project = resp.body;
    this.projectStartState.name = this.project.name;
    this.projectStartState.description = this.project.description;
    this.projectStartState.countOfSaveBuilds = this.project.countOfSaveBuilds;
    this.projectStartState.countOfBuildAttempts = this.project.countOfBuildAttempts;
  }

}
