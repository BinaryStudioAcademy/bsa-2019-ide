import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ProjectDescriptionDTO } from '../../../../models/DTO/Project/projectDescriptionDTO';
import { ProjectDialogService } from 'src/app/services/proj-dialog.service/project-dialog.service';
import { ProjectType } from 'src/app/modules/project/models/project-type';

@Component({
    selector: 'app-projects-list',
    templateUrl: './projects-list.component.html',
    styleUrls: ['./projects-list.component.sass']
})
export class ProjectsListComponent implements OnInit {
    @Input() projects: ProjectDescriptionDTO[];
    currentMenu: any;

    constructor(private projectDialogService: ProjectDialogService) { }

    ngOnInit() { }

    public createProject() {
        this.projectDialogService.show(ProjectType.Create);
    }

    hideAllMenus(menu: any) {
        if (this.currentMenu !== undefined) {
            this.currentMenu.hide();
        }
        this.currentMenu = menu;
    }
}
