import { Injectable } from '@angular/core';
import { DialogService } from 'primeng/components/common/api';
import { AddCollaboratorsComponent } from 'src/app/modules/collaborator/components/add-collaborators/add-collaborators.component';


@Injectable({
  providedIn: 'root'
})
export class CollaborateService {

  constructor(private dialogService: DialogService) { }

  public openDialogWindow(projectId: number)
    {
        const dialog = this.dialogService.open(AddCollaboratorsComponent, {
            data: {
                id: projectId
            },
            width: '40%',
            contentStyle: {
              'border-radius' : '5px',
              'padding': '2%'
            },
            showHeader : false
        });
    }
}
