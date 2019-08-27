import { Injectable } from '@angular/core';
import { DialogService } from 'primeng/api';
import { UserDialogType } from 'src/app/modules/user/components/models/project-dialog-type';
import { UserDialogWindowComponent } from 'src/app/modules/user/components/user-dialog-window/user-dialog-window.component';

@Injectable({
  providedIn: 'root'
})
export class UserDetailsDialogService {

    constructor(private dialogService: DialogService) { }

    public show(userDialogType: UserDialogType) {
      const ref = this.dialogService.open(UserDialogWindowComponent,
        {
            data: { 
                userDialogType: userDialogType
            },
            width: '500px',
            style: {
                'box-shadow': '0 0 3px 0 #000',
            },
            contentStyle: {
                'border-radius': '3px',
                'overflow-y': 'auto',
                'max-height': '90vh'
            },
            showHeader: false
        })
    }
}