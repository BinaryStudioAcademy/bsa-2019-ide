import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EventService } from 'src/app/services/event.service/event.service';

@Component({
    selector: 'app-dashboard-root',
    templateUrl: './dashboard-root.component.html',
    styleUrls: ['./dashboard-root.component.sass']
})
export class DashboardRootComponent implements OnInit {
    items: string[][];
    public isActive: number;

    constructor(private router: Router,
        private eventService: EventService) { }

    ngOnInit() {
        this.items = [
            ['Favourite projects', '/dashboard/favouriteProjects'],
            ['My projects', '/dashboard'],
            ['Assigned projects', '/dashboard/assignedProjects']
        ];
        this.isActive = this.items.findIndex(x => x[1] === this.router.url);
        this.eventService.currProjectSwitch(null);
    }

    redirect(i: number) {
        this.isActive = i;
        this.router.navigate([this.items[i][1]]);
    }

}
