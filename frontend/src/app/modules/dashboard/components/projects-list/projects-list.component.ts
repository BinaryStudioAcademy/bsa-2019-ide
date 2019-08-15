import { Component, OnInit, Input } from '@angular/core';
import { ProjectDescriptionDTO } from '../../../../models/DTO/Project/projectDescriptionDTO';

@Component({
    selector: 'app-projects-list',
    templateUrl: './projects-list.component.html',
    styleUrls: ['./projects-list.component.sass']
})
export class ProjectsListComponent implements OnInit {
    @Input() header: string;
    @Input() projects: ProjectDescriptionDTO[];
    currentMenu: any;

    constructor() { }

    ngOnInit() { }

    hideAllMenus(menu: any) {
        if (this.currentMenu !== undefined) {
            this.currentMenu.hide();
        }
        this.currentMenu = menu;
    }
}
