import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dashboard-root',
  templateUrl: './dashboard-root.component.html',
  styleUrls: ['./dashboard-root.component.sass']
})
export class DashboardRootComponent implements OnInit {
  items: string[][];
  isActive: Array<boolean> = [true, false, false];

  constructor(  private router: Router) { }

  ngOnInit() {
    this.items = [
      ['All projects', '/dashboard/'],
      ['My projects', '/dashboard/myProjects'],
      ['Assigned projects', '/dashboard/assignedProjects'],
      ['Favourite projects', '/dashboard/favouriteProjects']
    ];
    const route = this.router.url;
    this.isActive = [];
    this.isActive[this.items.findIndex(x => x[1] === route)] = true;
  }

  redirect(i: number) {
    this.isActive = [];
    this.isActive[i] = true;
    this.router.navigate([this.items[i][1]]);
  }
}
