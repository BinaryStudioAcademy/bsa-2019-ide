import { Component, OnInit } from '@angular/core';
import {ProjectService} from "../../../../services/project.service/project.service"
import {ProjectDescriptionDTO} from '../../../../models/DTO/Project/projectDescriptionDTO'

@Component({
  selector: 'app-favorite-projects',
  templateUrl: './favorite-projects.component.html',
  styleUrls: ['./favorite-projects.component.sass']
})
export class FavoriteProjectsComponent implements OnInit {

    projects: ProjectDescriptionDTO[];

  constructor(private projectService: ProjectService) { }

  ngOnInit() {
    this.projectService.getFavoriteProjects()
    .subscribe(x => {
        this.projects = x.body;
        this.projects.forEach(y => {
        y.created = new Date(y.created);
        y.lastBuild = y.lastBuild ? new Date(y.lastBuild) : null;
        });
    });
  }

}
