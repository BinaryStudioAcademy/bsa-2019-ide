import { Component, OnInit, Input } from '@angular/core';
import { NotificationDTO } from '../models/DTO/Common/notificationDTO';

@Component({
  selector: 'app-notification',
  templateUrl: './notification.component.html',
  styleUrls: ['./notification.component.sass']
})
export class NotificationComponent implements OnInit {

    @Input() notification: NotificationDTO;

    constructor() { }

    ngOnInit() {
    }

}
