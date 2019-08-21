import { Injectable } from '@angular/core';
import * as signalR from "@aspnet/signalr";
import { NotificationModel } from 'src/app/models/DTO/Common/notificationModel';
import { TokenService } from '../token.service/token.service';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class SignalRService {

    constructor(private tokenService: TokenService) { }
    public data: NotificationModel[];

    private hubConnection: signalR.HubConnection
    

    public startConnection = () => {
        this.hubConnection = new signalR.HubConnectionBuilder()
            .withUrl(environment.apiUrl + 'notification')
            .build();

        console.log(this.hubConnection);

        this.hubConnection
            .start()
            .then(() => console.log('Connection started'))
            .catch(err => console.log('Error while starting connection: ' + err))
    }

    public addTransferChartDataListener = () => {
        this.hubConnection.on('transferchartdata', (data) => {
            this.data = data;
            console.log(data);
        });
    }
}