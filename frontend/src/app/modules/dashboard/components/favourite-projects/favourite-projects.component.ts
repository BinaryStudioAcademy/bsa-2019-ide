import { Component, OnInit } from '@angular/core';
import {ProjectService} from '../../../../services/project.service/project.service';
import {ProjectDescriptionDTO} from '../../../../models/DTO/Project/projectDescriptionDTO';

@Component({
  selector: 'app-favourite-projects',
  templateUrl: './favourite-projects.component.html',
  styleUrls: ['./favourite-projects.component.sass']
})
export class FavouriteProjectsComponent implements OnInit {

  public projects: ProjectDescriptionDTO[];

  constructor(private projectService: ProjectService) { }

  public ngOnInit() {
    this.projectService.getFavouriteProjects()
    .subscribe(x => {
        this.projects = x.body;
        this.projects.forEach(y => {
            y.created = new Date(y.created);
            y.lastBuild = y.lastBuild ? new Date(y.lastBuild) : null;
        });
    });
  }

}
