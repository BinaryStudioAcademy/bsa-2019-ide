import { Component, OnInit } from '@angular/core';
import {MenuItem} from 'primeng/api';

@Component({
  selector: 'app-dashboard-root',
  templateUrl: './dashboard-root.component.html',
  styleUrls: ['./dashboard-root.component.sass']
})
export class DashboardRootComponent implements OnInit {
  items: MenuItem[];

  constructor() { }

  ngOnInit() {
    this.items = [{
      label: 'Projects',
      items: [
          {label: 'Project 1', routerLink: ['/project/1']},
          {label: 'Project 2', routerLink: ['/project/2']}
      ]
    },
    {
      label: 'Workspaces',
      items: [
          {label: 'Workspace 1', routerLink: ['/workspace/1']},
          {label: 'Workspaces 2', routerLink: ['/workspace/2']}
      ]
    }];
  }
}
