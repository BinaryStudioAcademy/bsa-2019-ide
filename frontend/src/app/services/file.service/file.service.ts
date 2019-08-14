import { Injectable } from '@angular/core';
import { HttpClientWrapperService } from '../http-client-wrapper.service';
import { Observable } from 'rxjs';
import { HttpResponse } from '@angular/common/http';
import { FileDTO } from 'src/app/models/DTO/File/fileDTO';

@Injectable({
  providedIn: 'root'
})
export class FileService {
    private address: string = 'files';
    
    constructor(private httpClient: HttpClientWrapperService) { }

    public getProjectById(id: string): Observable<HttpResponse<FileDTO>> {
        return this.httpClient.getRequest(this.address + `/${id}`);
    }
}
