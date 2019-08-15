import { Component, OnInit } from '@angular/core';
import { ProjectDescriptionDTO } from '../../../../models/DTO/Project/projectDescriptionDTO';
import { ProjectService } from 'src/app/services/project.service/project.service';

@Component({
  selector: 'app-my-projects',
  templateUrl: './my-projects.component.html',
  styleUrls: ['./my-projects.component.sass']
})
export class MyProjectsComponent implements OnInit {
    projects: ProjectDescriptionDTO[];

    constructor(private projectService: ProjectService) { }

    ngOnInit() {
        this.projectService.getMyProjects()
        .subscribe(x => {
                this.projects = x.body;
                this.projects.forEach(y => {
                    y.created = new Date(y.created);
                    y.lastBuild = y.lastBuild = y.lastBuild ? new Date(y.lastBuild) : null;
                });
        });
    }
}
