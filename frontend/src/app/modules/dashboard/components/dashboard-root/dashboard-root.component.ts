import { Component, OnInit } from '@angular/core';
import {MenuItem} from 'primeng/api';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dashboard-root',
  templateUrl: './dashboard-root.component.html',
  styleUrls: ['./dashboard-root.component.sass']
})
export class DashboardRootComponent implements OnInit {
  items: string[][];
  isActive: Array<boolean> = [];

  constructor(private router: Router) { }

  ngOnInit() {
    this.items = [
      ['All projects', '/dashboard/'],
      ['My projects', '/dashboard/myProjects'],
      ['Assigned projects', '/dashboard/assignedProjects']
    ];

    this.isActive[0] = true;
  }

  redirect(i: number) {
    this.isActive = [];
    this.isActive[i] = true;
    this.router.navigate([this.items[i][1]]);
  }
}
