import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';
import { ProjectInfoDTO } from 'src/app/models/DTO/Project/projectInfoDTO';
import { ActivatedRoute } from '@angular/router';
import {ProjectDetailsInfoComponent} from '../project-details-info/project-details-info.component';
import { ProjectService } from 'src/app/services/project.service/project.service';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-project-details',
  templateUrl: './project-details.component.html',
  styleUrls: ['./project-details.component.sass']
})
export class ProjectDetailsComponent implements OnInit {
    public projectId: number;
    public project: ProjectInfoDTO;

    private unsubscribe$ = new Subject<void>();

    constructor(
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
        .pipe(takeUntil(this.unsubscribe$))
        .subscribe(
          (resp) => {
            this.project = resp.body;
          },
          (error) => {
            console.error(error.message);
          }
        );
    }
}
