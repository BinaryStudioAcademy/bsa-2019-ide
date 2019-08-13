import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';
import { ProjectInfoDTO } from 'src/app/models/DTO/Project/projectInfoDTO';
import { ActivatedRoute } from '@angular/router';
import {ProjectDetailsInfoComponent} from '../project-details-info/project-details-info.component';

@Component({
  selector: 'app-project-details',
  templateUrl: './project-details.component.html',
  styleUrls: ['./project-details.component.sass']
})
export class ProjectDetailsComponent implements OnInit {
    public projectId: number;
    public project: ProjectInfoDTO;

    constructor(private route: ActivatedRoute) { }

    ngOnInit() {
      this.projectId = Number(this.route.snapshot.paramMap.get('id'));
      if (!this.projectId) {
        console.error('Id in URL is not a number!');
        return;
      }

      this.route.data.subscribe(data => {
          this.project = data['project'];
      });
    }
}
