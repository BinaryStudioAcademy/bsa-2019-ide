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
  public project: ProjectInfoDTO;

  private unsubscribe$ = new Subject<void>();

  public projectForm = this.fb.group({
    name: ['', Validators.required],
    description: ['', Validators.required],
    language: ['', Validators.required],
    projectType: ['', Validators.required],
    compilerType: ['', Validators.required],
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
          this.project = resp.body;
        },
        (error) => {
          console.error(error.message);
        }
      );
  }

  ngOnDestroy() {
    takeUntil(this.unsubscribe$);
  }

  onSubmit() {
    console.log('submit click');
  }

}
