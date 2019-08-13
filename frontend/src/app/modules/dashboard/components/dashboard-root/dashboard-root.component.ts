import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, NavigationStart, ActivatedRouteSnapshot } from '@angular/router';
import { map } from 'rxjs/operators';

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
      ['Favorite projects', '/dashboard/favoriteProjects']
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
