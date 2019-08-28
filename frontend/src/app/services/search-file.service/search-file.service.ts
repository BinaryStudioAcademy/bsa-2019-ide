import { Injectable } from '@angular/core';
import { HttpClientWrapperService } from '../http-client-wrapper.service';
import { Observable } from 'rxjs';
import { HttpResponse } from '@angular/common/http';
import { FileSearchResultDTO } from 'src/app/models/DTO/File/fileSearchResultDTO';

@Injectable({
  providedIn: 'root'
})
export class SearchFileService {

    private address: string = 'filesearch';

    constructor(private httpClient: HttpClientWrapperService) { }

    public find(query: string, projectId: number): Observable<HttpResponse<FileSearchResultDTO[]>> {
        return this.httpClient.getRequest(this.address, {query, projectId});
    }
}
