import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';
import { ProjectInfoDTO } from 'src/app/models/DTO/Project/projectInfoDTO';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-project-details',
  templateUrl: './project-details.component.html',
  styleUrls: ['./project-details.component.sass']
})
export class ProjectDetailsComponent implements OnInit {
    public project: ProjectInfoDTO;
    projectId: number;

    constructor(
      private route: ActivatedRoute
    ) { }

    ngOnInit() {
        this.route.data.subscribe(data => {
            this.project = data['project'];
            this.projectId = this.project.id;
        });
    }
}
