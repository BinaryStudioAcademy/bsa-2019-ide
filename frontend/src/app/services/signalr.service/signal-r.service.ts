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


    public startConnection = () => {
        this.hubConnection = new signalR.HubConnectionBuilder()
            .withUrl(environment.apiUrl + 'notification')
            .build();

        this.hubConnection
            .start()
            .then(() => console.log('Connection started'))
            .catch(err => console.log('Error while starting connection: ' + err))
    }

    public getNotifications(): NotificationDTO[] {
        return this.notifications;
    }

    public creanData()
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
            console.log(this.notifications);
        });
        return this.notifications;
    }

    public deleteTransferChartDataListener()
    {
        this.hubConnection.off('transferchartdata');
    }
}