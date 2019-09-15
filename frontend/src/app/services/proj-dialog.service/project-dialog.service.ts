import { Injectable } from '@angular/core';
import { DialogService } from 'primeng/components/common/api';
import { ProjectWindowComponent } from 'src/app/modules/project/components/project-window/project-window.component';
import { ProjectType } from 'src/app/modules/project/models/project-type';
import { ProjectUpdateComponent } from 'src/app/modules/project/components/project-update/project-update.component';

@Injectable({
  providedIn: 'root'
})
export class ProjectDialogService {
  
    constructor(private dialogService: DialogService) { }

    public show(projType: ProjectType, projectId = 0) {
      const ref = this.dialogService.open(ProjectWindowComponent,
        {
            data: { 
                projectId: projectId,
                projectType: projType
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
            showHeader: false,
            closeOnEscape: true
        })
    }

    public showEditDialog(projectId = 0) {
        console.log(projectId);
        const ref = this.dialogService.open(ProjectUpdateComponent,
          {
              data: { 
                  projectId: projectId
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
              showHeader: false,
              closeOnEscape: true
          })
      }
}
