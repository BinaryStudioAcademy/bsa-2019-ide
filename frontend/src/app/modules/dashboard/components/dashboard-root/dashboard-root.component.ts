import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProjectWindowComponent } from 'src/app/modules/project/components/project-window/project-window.component';
import { ProjectDialogService } from 'src/app/services/proj-dialog.service/project-dialog.service';
import { ProjectType } from 'src/app/modules/project/models/project-type';

@Component({
    selector: 'app-dashboard-root',
    templateUrl: './dashboard-root.component.html',
    styleUrls: ['./dashboard-root.component.sass']
})
export class DashboardRootComponent implements OnInit {
    items: string[][];
    isActive: number;

    constructor(private router: Router,
                private projectDialogService: ProjectDialogService) { }

    ngOnInit() {
        this.items = [
            ['Favourite projects', '/dashboard'],
            ['My projects', '/dashboard/myProjects'],
            ['Assigned projects', '/dashboard/assignedProjects']
        ];
        this.isActive = this.items.findIndex(x => x[1] === this.router.url);
    }

    redirect(i: number) {
        this.isActive = i;
        this.router.navigate([this.items[i][1]]);
    }

    createProject() {
        this.projectDialogService.show(ProjectType.Create);
    }
}
