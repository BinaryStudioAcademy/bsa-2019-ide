import { Directive, Input, ElementRef } from '@angular/core';
import { NotificationStatus } from 'src/app/models/Enums/notificationStatus';

@Directive({
  selector: '[appNotificationStatus]'
})
export class NotificationStatusDirective {

    @Input() notificationStatus: NotificationStatus;

    constructor(private elementRef: ElementRef)  {  }

    ngOnInit(){
        console.log(this.notificationStatus, this.elementRef);
        switch (this.notificationStatus) {
            case NotificationStatus.message:
                this.elementRef.nativeElement.style.backgroundColor = 'green';
                break;
            case NotificationStatus.warning: 
                this.elementRef.nativeElement.style.backgroundColor = 'orange';
                break;
            case NotificationStatus.error:
                this.elementRef.nativeElement.style.backgroundColor = 'red';
                break;           
        }

    }

}
