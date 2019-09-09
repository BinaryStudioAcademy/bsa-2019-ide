import { Injectable } from '@angular/core';
import { HttpClientWrapperService } from '../http-client-wrapper.service';
import { Observable } from 'rxjs';
import { HttpResponse } from '@angular/common/http';
import { FileHistoryDTO } from 'src/app/models/DTO/File/fileHistoryDTO';
import { FileHistoryListDTO } from 'src/app/models/DTO/File/fileHistoryListDTO';

@Injectable({
  providedIn: 'root'
})
export class FileHistoryService {

    private address: string = 'fileHistories';

    constructor(private httpClient: HttpClientWrapperService) { }

    public getHistoriesForProject(projectId: number): Observable<HttpResponse<FileHistoryListDTO[]>> {
        return this.httpClient.getRequest(`${this.address}/histories/${projectId}`);
    }
}
