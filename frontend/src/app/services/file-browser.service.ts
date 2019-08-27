import { HttpClientWrapperService } from './http-client-wrapper.service';
import { Injectable } from '@angular/core';
import { ProjectStructureDTO } from '../models/DTO/Workspace/projectStructureDTO';
import { HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { DialogService, TreeNode } from 'primeng/api';
import { FileInfoComponent } from '../modules/workspace/file-info/file-info.component';


@Injectable({
    providedIn: 'root'
})
export class FileBrowserService {

    private address = 'projectstructure/';

    constructor(private httpClient: HttpClientWrapperService,
        private dialogService: DialogService)
    { }

    public getProjectStructureById(id: number): Observable<HttpResponse<ProjectStructureDTO>> {
        return this.httpClient.getRequest(this.address + `${id}`);
    }

    public updateProjectStructure(id: number, projectStructure : ProjectStructureDTO) : Observable<HttpResponse<any>>{
        return this.httpClient.putRequest(this.address, projectStructure);
    }

    public OpenModalWindow(node: TreeNode, projectId: string)
    {
        const dialog = this.dialogService.open(FileInfoComponent,{
            data:
            {
                node,
                projectId
            },
            width: '30%',
            contentStyle: {
              'border-radius' : '5px',
              'padding': '2%'
            },
            showHeader : false
        });
    }
}
