import { Injectable } from '@angular/core';
import { DialogService } from 'primeng/components/common/api';
import { ProjectWindowComponent } from 'src/app/modules/project/components/project-window/project-window.component';
import { ProjectType } from 'src/app/modules/project/models/project-type';

@Injectable({
  providedIn: 'root'
})
export class ProjectDialogService {

  constructor(private dialogService: DialogService) { }

  show(projType: ProjectType, projectId: number = 0) {
      const ref = this.dialogService.open(ProjectWindowComponent,
        {
            data: { 
                projectType: projType,
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
            showHeader: false
        })
  }
}
