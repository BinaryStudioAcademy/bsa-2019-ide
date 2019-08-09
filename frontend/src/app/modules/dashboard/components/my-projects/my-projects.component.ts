import { Component, OnInit } from '@angular/core';
import { ProjectDescription } from 'src/app/models/dto/project/project-description';

@Component({
  selector: 'app-my-projects',
  templateUrl: './my-projects.component.html',
  styleUrls: ['./my-projects.component.sass']
})
export class MyProjectsComponent implements OnInit {
  projects: ProjectDescription[];

  constructor() { }

  ngOnInit() {
    this.projects =
    [
      {
        id: 1,
        title: 'Project12',
        createDate: new Date(Date.parse('2019-07')),
        lastBuildDate: new Date(Date.parse('2019-08-01')),
        logoLink: 'https://cdn.humoraf.ru/wp-content/uploads/2017/08/23-14.jpg',
        creator: 'Person1'
      },
      {
        id: 2,
        title: 'Project32',
        createDate: new Date(Date.parse('2019')),
        lastBuildDate: new Date(Date.parse('2019-06')),
        logoLink: 'http://www.nokiaplanet.com/uploads/posts/2015-01/1421138632_frozen-480x800.jpg',
        creator: 'Person52'
      },
      {
        id: 3,
        title: 'Project13',
        createDate: new Date(Date.parse('2018-07')),
        lastBuildDate: new Date(Date.parse('2019-07-03')),
        logoLink: 'https://mirpozitiva.ru/uploads/posts/2016-08/medium/1472042903_31.jpg',
        creator: 'Person3'
      },
    ];
  }
}
