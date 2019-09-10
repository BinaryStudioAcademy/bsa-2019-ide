import { Injectable } from '@angular/core';
import * as signalR from "@aspnet/signalr";
import { NotificationDTO } from 'src/app/models/DTO/Common/notificationDTO';
import { environment } from 'src/environments/environment';
import { NotificationService } from '../notification.service/notification.service';
import { TokenService } from '../token.service/token.service';
import { NotificationType } from 'src/app/models/Enums/notificationType';

@Injectable({
    providedIn: 'root'
})
export class SignalRService {

    constructor(
        private notificationService: NotificationService,
        private tokenService: TokenService
    ) { }

    public notifications: NotificationDTO[] = [];
    public runState=true;
    public buildState=true;
    public notification: NotificationDTO;

    private hubConnection: signalR.HubConnection;
    private connectionId: string;
    private userId: number;

    public startConnection = (isAuth: boolean, userId: number) => {
        this.userId = userId;

        this.hubConnection = new signalR.HubConnectionBuilder()
            .withUrl(`${environment.apiUrl}notification`, {
                skipNegotiation: true,
                transport: signalR.HttpTransportType.WebSockets,
                accessTokenFactory: () => this.tokenService.getAccessToken()
            })
            .build();

        this.hubConnection
            .start()
            .then(() => {
                this.addConnectionIdListener();
                this.runStateListener();
                console.log('SignalR Connection started');
                if (isAuth)
                {
                    this.addToGroup(userId);
                    this.join(userId);
                }
            })
            .catch((error) => console.log('Error while starting connection: ' + error))
    }

    public getNotifications(): NotificationDTO[] {
        return this.notifications;
    }

    public clearData()
    {
        this.notifications=[];
    }

    public addToGroup(userId: number): void {
        this.hubConnection.invoke("JoinGroup", userId)
            .catch((error) => console.log(error));
    }

    public join(userId: number): void {
        this.hubConnection.invoke("Join", userId)
            .catch((error) => console.log(error));
    }

    public addTransferChartDataListener(): NotificationDTO[] {
        this.hubConnection.on('transferchartdata', (notification) => {
            this.notifications.unshift(notification);
        });
        this.hubConnection.on('transferRunResult', (notification) => {
            this.notifications.unshift(notification);
        });
        return this.notifications;
    }

    public runStateListener(){
        this.hubConnection.on('progressState', (state: NotificationDTO)=>{
            console.log(state);
            if(state.type==NotificationType.projectRun){
                this.runState=false;
            }
            if(state.type==NotificationType.projectBuild){
                this.notification=state;
                this.buildState=false;
            }
        });
    }

    public addConnectionIdListener(): void{
        this.hubConnection.on('sendConnectionId', (connectionId, userId) => {
            if (userId === this.userId) {
                this.connectionId = connectionId;
            }
        });
    }

    public getConnectionId(): string {
        return this.connectionId;
    }

    public markNotificationAsRead(notificationId: number): void
    {
        this.hubConnection.invoke("MarkAsRead", notificationId)
            .catch((error) => console.log(error));
    }

    public deleteDataListeners()
    {
        this.hubConnection.off('transferchartdata');
        this.hubConnection.off('transferRunResult');
        this.hubConnection.off('sendConnectionId');
        this.hubConnection.off('progressState');
    }

    public deleteConnectionIdListener()
    {
        this.hubConnection.off('sendConnectionId');
    }
}
