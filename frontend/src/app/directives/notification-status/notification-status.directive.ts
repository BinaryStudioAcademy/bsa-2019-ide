import { Directive, Input, ElementRef } from '@angular/core';
import { NotificationStatus } from 'src/app/models/Enums/notificationStatus';

@Directive({
  selector: '[appNotificationStatus]'
})
export class NotificationStatusDirective {

    @Input() notificationStatus: NotificationStatus;

    constructor(private elementRef: ElementRef)  {  }

    ngOnInit(){
        switch (this.notificationStatus) {
            case NotificationStatus.message:
                this.elementRef.nativeElement.style.backgroundColor = '#33b5e5';
                break;
            case NotificationStatus.warning: 
                this.elementRef.nativeElement.style.backgroundColor = '#ffbb33';
                break;
            case NotificationStatus.error:
                this.elementRef.nativeElement.style.backgroundColor = '#ff4444';
                break;           
        }
    }
}
