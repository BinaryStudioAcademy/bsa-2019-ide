import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.sass']
})
export class NavMenuComponent implements OnInit {
  items: MenuItem[];

  ngOnInit() {
    this.items = [
      {label: 'Home', routerLink: ['']},
      {label: 'Dashboard', routerLink: ['/dashboard']},
      {label: 'User', routerLink: ['/user']}
    ];
  }
}
