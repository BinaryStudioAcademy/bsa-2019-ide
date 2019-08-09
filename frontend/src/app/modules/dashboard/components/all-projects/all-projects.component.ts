import { Component, OnInit } from '@angular/core';
import { ProjectDescriptionDTO } from '../../../../models/DTO/Project/projectDescriptionDTO';

@Component({
    selector: 'app-all-projects',
    templateUrl: './all-projects.component.html',
    styleUrls: ['./all-projects.component.sass']
})
export class AllProjectsComponent implements OnInit {
    projects: ProjectDescriptionDTO[];

    constructor() { }

    ngOnInit() {
        this.projects =
            [
                {
                    id: 1,
                    title: 'Project1',
                    created: new Date(Date.parse('2019-07')),
                    lastBuild: new Date(Date.parse('2019-08-01')),
                    photoLink: 'https://s1.logaster.com/static/v3/img/first_step_seo/example-1.png',
                    creator: 'Person1'
                },
                {
                    id: 2,
                    title: 'Project2',
                    created: new Date(Date.parse('2019')),
                    lastBuild: new Date(Date.parse('2019-06')),
                    photoLink: 'http://www.nokiaplanet.com/uploads/posts/2015-01/1421138632_frozen-480x800.jpg',
                    creator: 'Person2'
                },
                {
                    id: 3,
                    title: 'Project3',
                    created: new Date(Date.parse('2018-07')),
                    lastBuild: new Date(Date.parse('2019-07-03')),
                    photoLink: 'https://s1.logaster.com/static/v3/img/first_step_seo/example-1.png',
                    creator: 'Person3'
                },
            ];
    }
}
