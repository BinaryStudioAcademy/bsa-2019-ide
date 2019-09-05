import { Component, OnInit, OnDestroy, ɵConsole } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { AuthDialogService } from '../services/auth-dialog.service/auth-dialog.service';
import { DialogType } from '../modules/authorization/models/auth-dialog-type';
import { Router } from '@angular/router';
import { Subject } from 'rxjs';
import { takeUntil, tap } from 'rxjs/operators';
import { ProjectService } from '../services/project.service/project.service';
import { TokenService } from '../services/token.service/token.service';
import { SearchProjectDTO } from '../models/DTO/Project/searchProjectDTO'
import { SignalRService } from '../services/signalr.service/signal-r.service';
import { NotificationDTO } from '../models/DTO/Common/notificationDTO';
import { NotificationService } from '../services/notification.service/notification.service';
import { UserService } from '../services/user.service/user.service';
import { EventService } from '../services/event.service/event.service';
import { NotificationStatus } from '../models/Enums/notificationStatus';
import { NotificationType } from '../models/Enums/notificationType';

@Component({
    selector: 'app-nav-menu',
    templateUrl: './nav-menu.component.html',
    styleUrls: ['./nav-menu.component.sass']
})
export class NavMenuComponent implements OnInit, OnDestroy {
    authUserItems: MenuItem[];
    unAuthUserItems: MenuItem[];

    public userNickName: string;
    public userAvatar: string;
    public project: SearchProjectDTO;
    public currProject: SearchProjectDTO;
    public filterProhects: SearchProjectDTO[]
    public dialogType = DialogType;
    public isAuthorized: boolean;
    public items: MenuItem[];
    public showNotification = false;
    public data: NotificationDTO[] = [];
    public notReadNotification: NotificationDTO[] = [];
    private unsubscribe$ = new Subject<void>();
    private userId: number;

    constructor(
        private authDialogService: AuthDialogService,
        private router: Router,
        private userService: UserService,
        private tokenService: TokenService,
        private projectService: ProjectService,
        private signalRService: SignalRService,
        private notificationService: NotificationService,
        private eventService: EventService
    ) { }

    ngOnInit() {
        this.getUser();
        this.signalRService.startConnection(this.isAuthorized, this.userId);
        this.authUserItems = [
            {
                label: 'Home',
                command: () => {
                    if (!this.router.url.startsWith('/dashboard')) {
                        this.router.navigate(['/dashboard'])
                    }
                }
            }
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
            .pipe(takeUntil(this.unsubscribe$),tap(isAuth => {if(isAuth) this.userNickName = this.tokenService.getUser().nickName;}))
            .subscribe((auth) => {

                this.isAuthorized = auth;
                if (this.isAuthorized ) {
                    this.getUser();
                    this.data = this.signalRService.addTransferChartDataListener();
                    this.loadNotifications(this.userId);
                }
            });

        this.eventService.currProjectChanged$.
            pipe(takeUntil(this.unsubscribe$))
            .subscribe((currProj) => {
                this.currProject = currProj;
            });

        this.items = [
            {
                label: 'Log out', icon: 'pi pi-sign-out', command: () => {
                    this.logOut();
                }
            }
        ];
    }

    public onNotificationClick(notification: NotificationDTO) {
        if (notification.type != NotificationType.assinedToProject) {
            this.notificationService.OpenConsole(notification.metadata);
        }
        this.router.navigate([`/workspace/${notification.projectId}`]);
    }

    public loadNotifications(userId: number): void {
        this.notificationService.getUserNotifications(userId)
            .subscribe(
                (resp) => {
                    this.notReadNotification = resp.body.sort(function (a, b) {
                        if (a.dateTime > b.dateTime) {
                            return -1;
                        }
                        if (a.dateTime < b.dateTime) {
                            return 1;
                        }
                        return 0;
                    });
                    console.log(resp.body);
                    console.log(this.notReadNotification);
                }
            );
    }

    public showNotificationPanel() {
        this.showNotification = !this.showNotification;
        const dataForDelete = this.data;
        if (!this.showNotification) {
            this.signalRService.clearData();
            this.signalRService.deleteTransferChartDataListener();
            this.data = this.signalRService.addTransferChartDataListener();
            dataForDelete.forEach(element => {
                this.signalRService.markNotificationAsRead(element.id);
            });
            this.notReadNotification.forEach(element => {
                this.signalRService.markNotificationAsRead(element.id);
            })
            this.notReadNotification = [];
        }
    }

    public filterProject(event): void {
        const query = event.query;
        this.projectService.getProjectsName().subscribe(projects => {
            this.filterProhects = this.filter(query, projects.body);
        });
    }

    public checkProject(project: SearchProjectDTO): void {
        if (project.id == -2) {
            return
        }
        this.project = null;
        if (project.id == -1) {
            this.router.navigate([`/workspace/${this.currProject.id}`], {
                queryParams: {
                    id: this.currProject.id,
                    query: project.name
                }
            });
            return;
        }
        if (project.id == -3) {
            this.router.navigate(['/searchoutput'], {
                queryParams: {
                    query: project.name
                }
            });
            return;
        }
        this.router.navigate([`/project/${project.id}`]);
    }

    public filter(query, projects: SearchProjectDTO[]): SearchProjectDTO[] {
        const filtered: SearchProjectDTO[] = [];
        filtered.push({ id: -3, name: query });
        if (!!this.currProject) {
            filtered.push({ id: -1, name: query });
        }
        for (let i = 0; i < projects.length; i++) {
            const project = projects[i];
            if (project.name.toLowerCase().indexOf(query.toLowerCase()) == 0) {
                filtered.push(project);
            }
        }
        if (filtered.length === 0) {
            const notFound: SearchProjectDTO = {
                id: -2,
                name: "We couldn’t find any project matching " + query
            }
            filtered.push(notFound);
        }
        return filtered;
    }

    public goToUserDetails() {
        this.router.navigate([`/user/details/${this.userId}`]);
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

    public logOut() {
        this.tokenService.logout();
        this.isAuthorized = undefined;
        this.signalRService.clearData();
        this.signalRService.deleteTransferChartDataListener();
    }

    public getAvatarAndName(): void {
        this.userService
            .getUserDetailsFromToken()
            .pipe(takeUntil(this.unsubscribe$))
            .subscribe(resp => {
                this.userAvatar = './assets/img/user-default-avatar.png';
                if (resp.body.url)
                    this.userAvatar = resp.body.url;

                this.userId = resp.body.id;
                this.userNickName = resp.body.nickName;
            },
                error => {
                    console.log(error);
                })
    };

    private getUser() {
        if (!this.tokenService.areTokensExist()) {
            return;
        }
        this.userId = this.tokenService.getUserId();

        this.tokenService
            .IsAuthorized()
            .pipe(takeUntil(this.unsubscribe$))
            .subscribe((auth) => {
                this.isAuthorized = auth;
                this.userId = this.tokenService.getUserId();
                this.getAvatarAndName();
            });
    }
}
