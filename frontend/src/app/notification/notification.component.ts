import { Component, OnInit, Input } from '@angular/core';
import { NotificationDTO } from '../models/DTO/Common/notificationDTO';
import { NotificationStatus } from '../models/Enums/notificationStatus';

@Component({
  selector: 'app-notification',
  templateUrl: './notification.component.html',
  styleUrls: ['./notification.component.sass']
})
export class NotificationComponent implements OnInit {
    public status: string;
    @Input() notification: NotificationDTO;

    constructor() { }

    ngOnInit() {
        switch (this.notification.status) {
            case NotificationStatus.message:
                this.status = 'Message';
                break;
            case NotificationStatus.warning: 
                this.status = 'Warning';
                break;
            case NotificationStatus.error:
                this.status = 'Error';
                break;           
        }
    }

}
