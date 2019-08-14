import { Component, OnInit } from '@angular/core';
import { ProjectDescriptionDTO } from '../../../../models/DTO/Project/projectDescriptionDTO';
import { ProjectService } from 'src/app/services/project.service/project.service';

@Component({
    selector: 'app-assigned-projects',
    templateUrl: './assigned-projects.component.html',
    styleUrls: ['./assigned-projects.component.sass']
})
export class AssignedProjectsComponent implements OnInit {
    projects: ProjectDescriptionDTO[];

    constructor(private projectService: ProjectService) { }

    ngOnInit() {
        this.projectService.getAssignedProjects()
        .subscribe(x => {
            this.projects = x.body;
            this.projects.forEach(y => {
            y.created = new Date(y.created);
            y.lastBuild = y.lastBuild ? new Date(y.lastBuild) : null;
            });
        });
    }
}
