import { Injectable } from '@angular/core';
import { HttpClientWrapperService } from '../http-client-wrapper.service';
import { Observable } from 'rxjs';
import { HttpResponse } from '@angular/common/http';
import { FileShownHistoryDTO } from 'src/app/models/DTO/File/fileShownHistoryDTO';

@Injectable({
  providedIn: 'root'
})
export class FileHistoryService {

    private address: string = 'fileHistories';

    constructor(private httpClient: HttpClientWrapperService) { }

    public getHistoriesForProject(projectId: number): Observable<HttpResponse<FileShownHistoryDTO[]>> {
        return this.httpClient.getRequest(`${this.address}/histories/${projectId}`);
    }
}
