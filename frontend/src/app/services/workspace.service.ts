import { HttpResponse } from '@angular/common/http';
import { HttpClientWrapperService } from './http-client-wrapper.service';
import { Injectable } from '@angular/core';
import { FileUpdateDTO } from '../models/DTO/File/fileUpdateDTO';
import { forkJoin, Observable } from 'rxjs';
import { FileDTO } from '../models/DTO/File/fileDTO';
import { DialogService } from 'primeng/api';
import { EditorSettingsComponent } from '../modules/editor/components/editor-settings/editor-settings.component';
import { ProjectInfoDTO } from '../models/DTO/Project/projectInfoDTO';
import { EditorSettingDTO } from '../models/DTO/Common/editorSettingDTO';

@Injectable({
    providedIn: 'root'
})
export class WorkspaceService {

    constructor(
        private dialogService: DialogService,
        private req: HttpClientWrapperService
        ) { }

    public show(project: ProjectInfoDTO): Observable<any> {
        const ref = this.dialogService.open(EditorSettingsComponent,
        {
            data: { 
                project: project,
                type: "workspace"
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
        });
        return ref.onClose;
    }

    public getFileById(fileId): Observable<HttpResponse<FileDTO>> {
        return this.req.getRequest(`files/${fileId}`);
    }

    public saveFilesRequest(files: FileUpdateDTO[]): Observable<HttpResponse<FileUpdateDTO>[]> {
        const fileRequests: Observable<HttpResponse<FileUpdateDTO>>[] = files.map(x => this.saveFileRequest(x));
        return forkJoin(fileRequests);
    }
    public saveFileRequest(file: FileUpdateDTO): Observable<HttpResponse<FileUpdateDTO>> {
        return this.req.putRequest('files', file);
    }
}
