import { Injectable } from '@angular/core';
import { HttpClientWrapperService } from '../http-client-wrapper.service';
import { NotificationDTO } from 'src/app/models/DTO/Common/notificationDTO';
import { Observable } from 'rxjs';
import { HttpResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

    public routePrefix = 'notification';

    constructor(private httpService: HttpClientWrapperService) { }

    public getUserNotifications(userId: number): Observable<HttpResponse<NotificationDTO[]>> {
        return this.httpService.getRequest<NotificationDTO[]>(`${this.routePrefix}/getUserNotification/${userId}`);
    }

}
