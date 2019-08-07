import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'primeng/api';
import {AuthDialogService} from '../services/auth-dialog.service/auth-dialog.service'
import { DialogType } from '../models/common/auth-dialog-type';
import { AuthenticationService } from '../services/auth.service/auth.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.sass']
})
export class NavMenuComponent implements OnInit {
  items: MenuItem[];

  public dialogType = DialogType;

  constructor(
    private authDialogService: AuthDialogService,
    private authService: AuthenticationService
) {}

  ngOnInit() {
    this.items = [
      {label: 'Home', routerLink: ['']},
      {label: 'Dashboard', routerLink: ['/dashboard']},
      {label: 'User', routerLink: ['/user']}
    ];
  }

  public openAuthDialog(type: DialogType) {
    this.authDialogService.openAuthDialog(type);
}
  public LogOut()
  {
    this.authService.logout();
  }
}
