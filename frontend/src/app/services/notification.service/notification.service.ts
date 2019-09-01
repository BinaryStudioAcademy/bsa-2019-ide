import { Injectable } from '@angular/core';
import { HttpClientWrapperService } from '../http-client-wrapper.service';
import { NotificationDTO } from 'src/app/models/DTO/Common/notificationDTO';
import { Observable } from 'rxjs';
import { HttpResponse } from '@angular/common/http';
import { ConsoleComponent } from 'src/app/modules/workspace/console/console.component';
import { DialogService } from 'primeng/api';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

    public routePrefix = 'notification';

    constructor(private httpService: HttpClientWrapperService,
        private dialogService: DialogService) { }

    public getUserNotifications(userId: number): Observable<HttpResponse<NotificationDTO[]>> {
        return this.httpService.getRequest<NotificationDTO[]>(`${this.routePrefix}/getUserNotification/${userId}`);
    }

    public OpenConsole(message: string)
    {
        const ref = this.dialogService.open(ConsoleComponent,
            {
                data: { 
                    message: message
                },
                width: '70vw',
                style: {
                    'box-shadow': '0 0 3px 0 #000',
                },
                contentStyle: {
                    'border-radius': '3px',
                    'overflow-y': 'auto',
                    'height': '60vh',
                    'background-color': 'black',
                    'font-size': '13px',
                    'color': 'white'
                },
                showHeader: true,
                header: "Console"
            })
      }

}
