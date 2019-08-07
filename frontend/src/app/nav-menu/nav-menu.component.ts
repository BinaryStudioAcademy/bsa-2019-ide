import { Component, OnInit, OnDestroy } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { AuthDialogService } from '../services/auth-dialog.service/auth-dialog.service'
import { DialogType } from '../models/common/auth-dialog-type';
import { AuthenticationService } from '../services/auth.service/auth.service';
import { User } from '../models/user';
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
export class NavMenuComponent implements OnInit, OnDestroy {
  items: MenuItem[];

  public dialogType = DialogType;
  public authorizedUser: User;
  private unsubscribe$ = new Subject<void>();

  constructor(
    private authDialogService: AuthDialogService,
    private authService: AuthenticationService,
    private eventService: EventService,
    private userService: UserService,
    private router: Router
  ) { }

  ngOnInit() {
    this.items = [
      { label: 'Home', routerLink: [''] },
      { label: 'Dashboard', routerLink: ['/dashboard'] },
      { label: 'User', routerLink: ['/user'] }
    ];

    this.getUser();

    this.eventService.userChangedEvent$
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe((user) => (this.authorizedUser = user ? this.userService.copyUser(user) : undefined));
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
    //this.router.navigate(['/']);
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
