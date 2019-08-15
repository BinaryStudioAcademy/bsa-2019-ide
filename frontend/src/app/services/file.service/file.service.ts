import { Injectable } from '@angular/core';
import { HttpClientWrapperService } from '../http-client-wrapper.service';
import { Observable } from 'rxjs';
import { HttpResponse } from '@angular/common/http';
import { FileDTO } from 'src/app/models/DTO/File/fileDTO';
import { FileCreateDTO } from 'src/app/models/DTO/File/fileCreateDTO';
import { ConfirmDialog } from 'primeng/primeng';

@Injectable({
  providedIn: 'root'
})
export class FileService {
    private address: string = 'files';
    
    constructor(private httpClient: HttpClientWrapperService) { }

    public getProjectById(id: string): Observable<HttpResponse<FileDTO>> {
        return this.httpClient.getRequest(this.address + `/${id}`);
    }

    public addFile(file: FileCreateDTO): Observable<HttpResponse<any>> {
        console.log(file);
        debugger;
        return this.httpClient.postRequest(this.address, file);
    }
}
