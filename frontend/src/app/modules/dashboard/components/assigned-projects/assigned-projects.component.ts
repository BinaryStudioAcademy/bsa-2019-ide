import { Component, OnInit } from '@angular/core';
import { ProjectDescription } from 'src/app/model/project';

@Component({
  selector: 'app-assigned-projects',
  templateUrl: './assigned-projects.component.html',
  styleUrls: ['./assigned-projects.component.sass']
})
export class AssignedProjectsComponent implements OnInit {
  projects: ProjectDescription[];

  constructor() { }

  ngOnInit() {
    this.projects =
    [
      {
        id: 1,
        title: 'Project1',
        createDate: new Date(Date.parse('2019-07')),
        lastBuildDate: new Date(Date.parse('2018-08-11')),
        logoLink: 'https://s1.logaster.com/static/v3/img/first_step_seo/example-1.png',
        creator: 'Person1'
      },
      {
        id: 2,
        title: 'Project2',
        createDate: new Date(Date.parse('2019')),
        lastBuildDate: new Date(Date.parse('2019-06')),
        logoLink: 'http://www.nokiaplanet.com/uploads/posts/2015-01/1421138632_frozen-480x800.jpg',
        creator: 'Person2'
      },
      {
        id: 3,
        title: 'Project3',
        createDate: new Date(Date.parse('2018-07')),
        lastBuildDate: new Date(Date.parse('2019-07-03')),
        logoLink: 'https://s1.logaster.com/static/v3/img/first_step_seo/example-1.png',
        creator: 'Person3'
      },
    ];
  }
}
