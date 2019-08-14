import { Component, OnInit } from '@angular/core';
import { ProjectDescriptionDTO } from '../../../../models/DTO/Project/projectDescriptionDTO';
import { ProjectService } from 'src/app/services/project.service/project.service';

@Component({
    selector: 'app-all-projects',
    templateUrl: './all-projects.component.html',
    styleUrls: ['./all-projects.component.sass']
})
export class AllProjectsComponent implements OnInit {
  projects: ProjectDescriptionDTO[];

  constructor(private projectService: ProjectService) { }

  ngOnInit() {
    this.projectService.getAllProjects()
      .subscribe(x => {
            this.projects = x.body;
            this.projects.forEach(y => {
                y.created = new Date(y.created);
                y.lastBuild = y.lastBuild ? new Date(y.lastBuild) : null;
            });
      });
  }
}
