import { Component, OnInit, OnDestroy, OnChanges } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { AuthDialogService } from '../services/auth-dialog.service/auth-dialog.service'
import { DialogType } from '../modules/authorization/models/auth-dialog-type';
import { AuthenticationService } from '../services/auth.service/auth.service';
import { UserDTO } from '../models/DTO/User/userDTO';
import { Router } from '@angular/router';
import { UserService } from '../services/user.service/user.service';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { EventService } from '../services/event.service/event.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.sass']
})
export class NavMenuComponent implements OnInit, OnDestroy, OnChanges {
  items: MenuItem[];

  public dialogType = DialogType;
  public authorizedUser: UserDTO;
  private unsubscribe$ = new Subject<void>();
  private userMenuBarItem=false;

  constructor(
    private authDialogService: AuthDialogService,
    private authService: AuthenticationService,
    private eventService: EventService,
    private userService: UserService,
    private router: Router
  ) { }

  ngOnInit() {
    this.getUser();

    this.eventService.userChangedEvent$
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe((user) => (this.authorizedUser = user ? this.userService.copyUser(user) : undefined));
      console.log("init");

      if (this.authorizedUser)
      {
          this.userMenuBarItem=true;
      }

      this.items = [
        { label: 'Home', routerLink: [''] },
        { label: 'Dashboard', routerLink: ['/dashboard'] },
        { label: 'User', routerLink: ['/user'],visible: this.userMenuBarItem }
      ];
  }

  ngOnChanges()
  {
      console.log("change");
  }

  public ngOnDestroy() {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }

  public openAuthDialog(type: DialogType) {
    this.authDialogService.openAuthDialog(type);
  }
  public LogOut() {
    this.authService.logout();
    this.authorizedUser = undefined;
    this.router.navigate(['/']);
  }

  private getUser() {
    if (!this.authService.areTokensExist()) {
      return;
    }

    this.authService
      .getUser()
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe((user) => (this.authorizedUser = this.userService.copyUser(user)));
  }
}
