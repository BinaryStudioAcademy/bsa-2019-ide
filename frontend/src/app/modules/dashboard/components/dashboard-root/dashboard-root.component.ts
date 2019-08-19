import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
    selector: 'app-dashboard-root',
    templateUrl: './dashboard-root.component.html',
    styleUrls: ['./dashboard-root.component.sass']
})
export class DashboardRootComponent implements OnInit {
    items: string[][];
    isActive: number;

    constructor(  private router: Router) { }

    ngOnInit() {
        this.items = [
        ['All projects', '/dashboard'],
        ['My projects', '/dashboard/myProjects'],
        ['Assigned projects', '/dashboard/assignedProjects'],
        ['Favourite projects', '/dashboard/favouriteProjects']
        ];
        this.isActive = this.items.findIndex(x => x[1] === this.router.url);
    }

    redirect(i: number) {
        this.isActive = i;
        this.router.navigate([this.items[i][1]]);
    }
}
