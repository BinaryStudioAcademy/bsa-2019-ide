import { Component, OnInit, OnDestroy, OnChanges } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { AuthDialogService } from '../services/auth-dialog.service/auth-dialog.service';
import { DialogType } from '../modules/authorization/models/auth-dialog-type';
import { UserDTO } from '../models/DTO/User/userDTO';
import { Router } from '@angular/router';
import { UserService } from '../services/user.service/user.service';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { ProjectService } from '../services/project.service/project.service';
import { TokenService } from '../services/token.service/token.service';
import { ProjectDescriptionDTO } from '../models/DTO/Project/projectDescriptionDTO';
import { SearchProjectDTO } from '../models/DTO/Project/searchProjectDTO'

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
    public items: MenuItem[];
    private unsubscribe$ = new Subject<void>();

    project: SearchProjectDTO;
    filterProhects: SearchProjectDTO[]

    constructor(
        private authDialogService: AuthDialogService,
        private router: Router,
        private tokenService: TokenService,
        private projectService: ProjectService
    ) { }

    ngOnInit() {
        this.getUser();
        this.authUserItems = [
            { label: 'Home', routerLink: [''] },
            { label: 'Dashboard', routerLink: ['/dashboard'] },
            { label: 'User', routerLink: ['/user'] }
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
            {
                label: 'Log out', icon: 'pi pi-sign-out', command: () => {
                    this.LogOut();
                }
            }
        ];
    }

    filterProject(event) {
        let query = event.query;
        this.projectService.getProjectsName().subscribe(projects => {
            this.filterProhects = this.filterProhects = this.filter(query, projects.body);
            this.filterProhects = this.filterProhects;
        });
    }

    checkProject(project: SearchProjectDTO) {
        console.log(this.project.name);
        this.project.name="";
        this.router.navigate([`/project/${project.id}`]);
    }

    filter(query, countries: SearchProjectDTO[]): SearchProjectDTO[] {
        let filtered: SearchProjectDTO[] = [];
        for (let i = 0; i < countries.length; i++) {
            let country = countries[i];
            if (country.name.toLowerCase().indexOf(query.toLowerCase()) == 0) {
                filtered.push(country);
            }
        }
        return filtered;
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
