import { Injectable } from '@angular/core';
import * as signalR from "@aspnet/signalr";
import { NotificationDTO } from 'src/app/models/DTO/Common/notificationDTO';
import { TokenService } from '../token.service/token.service';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class SignalRService {

    constructor(private tokenService: TokenService) { }

    public notifications: NotificationDTO[] = [];

    private hubConnection: signalR.HubConnection


    public startConnection = (isAuth: boolean, userId: number) => {
        this.hubConnection = new signalR.HubConnectionBuilder()
            .withUrl(environment.apiUrl + 'notification')
            .build();

        this.hubConnection
            .start()
            .then(() => {
                console.log('Connection started');
                if (isAuth)
                {
                    this.addToGroup(userId);
                }
            })
            .catch(err => console.log('Error while starting connection: ' + err))
    }

    public getNotifications(): NotificationDTO[] {
        return this.notifications;
    }

    public crearData()
    {
        this.notifications=[];
    }

    public addToGroup(userId: number): void {
        this.hubConnection.invoke("JoinGroup", userId)
            .catch((error) => console.log(error));
    }

    public addTransferChartDataListener(): NotificationDTO[] {
        this.hubConnection.on('transferchartdata', (data) => {
            this.notifications.push(data);
        });
        return this.notifications;
    }

    public markNotificationIsRead(notificationId: number): void
    {
        this.hubConnection.invoke("MarkRead", notificationId)
            .catch((error) => console.log(error));
    }

    public deleteTransferChartDataListener()
    {
        this.hubConnection.off('transferchartdata');
    }
}