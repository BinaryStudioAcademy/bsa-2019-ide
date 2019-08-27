import { Injectable } from '@angular/core';
import { HttpClientWrapperService } from '../http-client-wrapper.service';
import { Observable } from 'rxjs';
import { HttpResponse } from '@angular/common/http';
import { LikedProjectsInLanguageDTO } from 'src/app/models/DTO/Project/likedProjectsInLanguageDTO';

@Injectable({
  providedIn: 'root'
})
export class InfoService {

    private address = 'info';

    constructor(private httpClient: HttpClientWrapperService) { }

    public getMostLikedProjects(): Observable<HttpResponse<LikedProjectsInLanguageDTO[]>> {
        return this.httpClient.getRequest(this.address);
    }

    public getFileStructureSize(projectStructureId: string, fileStructureId: string): Observable<HttpResponse<number>>{
        return this.httpClient.getRequest("projectstructure/size/"+projectStructureId+'/'+fileStructureId);
    }
}
