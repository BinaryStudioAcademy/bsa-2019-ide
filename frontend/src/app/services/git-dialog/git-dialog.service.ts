import { Injectable } from '@angular/core';
import { DialogService } from 'primeng/api';
import { CommandType } from 'src/app/modules/git/models/commang-type';
import { GitWindowComponent } from 'src/app/modules/git/components/git-window/git-window.component';

@Injectable({
  providedIn: 'root'
})
export class GitDialogService {

    constructor(private dialogService: DialogService) { }

    public show(projectId: string, commandType: CommandType) {
      const ref = this.dialogService.open(GitWindowComponent,
        {
            data: {
                projectId: projectId, 
                commandType: commandType
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
