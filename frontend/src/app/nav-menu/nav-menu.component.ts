import { Component, OnInit, OnDestroy, OnChanges } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { AuthDialogService } from '../services/auth-dialog.service/auth-dialog.service';
import { DialogType } from '../modules/authorization/models/auth-dialog-type';
import { UserDTO } from '../models/DTO/User/userDTO';
import { Router } from '@angular/router';
import { UserService } from '../services/user.service/user.service';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { EventService } from '../services/event.service/event.service';
import { TokenService } from '../services/token.service/token.service';

@Component({
    selector: 'app-nav-menu',
    templateUrl: './nav-menu.component.html',
    styleUrls: ['./nav-menu.component.sass']
})
export class NavMenuComponent implements OnInit, OnDestroy {
    authUserItems: MenuItem[];
    unAuthUserItems: MenuItem[];

    public dialogType = DialogType;
    public isAuthorized: boolean;
    public  items: MenuItem[];
    private unsubscribe$ = new Subject<void>();

    constructor(
        private authDialogService: AuthDialogService,
        private router: Router,
        private tokenService: TokenService
    ) { }

    ngOnInit() {
        this.getUser();
        this.authUserItems = [
            { label: 'Home', routerLink: [''] },
            { label: 'Dashboard', routerLink: ['/dashboard'] }
        ];
        this.unAuthUserItems = [
            {
                label: 'Home',
                command: (event: any) => {
                    this.openAuthDialog(this.dialogType.SignIn);
                }
            }
        ];

        this.tokenService.isAuthenticatedEvent$
            .pipe(takeUntil(this.unsubscribe$))
            .subscribe((auth) => (this.isAuthorized = auth));

        this.items = [
            {label: 'Log out', icon: 'pi pi-sign-out', command: () => {
                this.LogOut();
            }}
        ];
    }

    public goToUserDetails() {
        this.router.navigate(['/user/details']);
    }

    public getMenuItems() {
        if (this.isAuthorized) {
            return this.authUserItems;
        } else {
            return this.unAuthUserItems;
        }
    }

    public ngOnDestroy() {
        this.unsubscribe$.next();
        this.unsubscribe$.complete();
    }

    public openAuthDialog(type: DialogType) {
        this.authDialogService.openAuthDialog(type);
    }

    public LogOut() {
        this.tokenService.logout();
        this.isAuthorized = undefined;
        this.router.navigate(['/']);
    }

    private getUser() {
        if (!this.tokenService.areTokensExist()) {
            return;
        }

        this.tokenService
            .IsAuthorized()
            .pipe(takeUntil(this.unsubscribe$))
            .subscribe((auth) => this.isAuthorized = auth);
    }
}
