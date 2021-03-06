import { query } from '@angular/animations';
import { Injectable } from '@angular/core';
import { HttpClientWrapperService } from '../http-client-wrapper.service';
import { Observable } from 'rxjs';
import { HttpResponse } from '@angular/common/http';
import { FileSearchResultDTO } from 'src/app/models/DTO/File/fileSearchResultDTO';
import { GlobalSearchResultDTO } from 'src/app/models/DTO/File/globalSearchResultDTO';

@Injectable({
  providedIn: 'root'
})
export class SearchFileService {

    private address: string = 'filesearch';

    constructor(private httpClient: HttpClientWrapperService) { }

    public find(query: string, projectId: number): Observable<HttpResponse<FileSearchResultDTO[]>> {
        
        return this.httpClient.getRequest(this.address, {query, projectId});
    }

    public findFilesGlobal(query: string): Observable<HttpResponse<GlobalSearchResultDTO[]>>{
        return this.httpClient.getRequest("filesearch/globalsearch", {query});
    }
}
