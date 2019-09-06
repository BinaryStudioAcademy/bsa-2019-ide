import { Injectable } from '@angular/core';
import { HttpClientWrapperService } from '../http-client-wrapper.service';
import { Observable } from 'rxjs';
import { HttpResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class GitService {

    private address: string = 'git/';

    constructor(private httpClient: HttpClientWrapperService) { }
        
    clone(): Observable<HttpResponse<any>>{
        return this.httpClient.getRequest('git/clone');
    }

    pull(projectId: string, branch: string): Observable<HttpResponse<any>>{
        return this.httpClient.getRequest('git/pull/'+ projectId + '/' + branch);
    }

    commit(projectId: string, message: string): Observable<HttpResponse<any>>{
        return this.httpClient.getRequest(this.address + `commit/${projectId}/${message}`);
    }

    push(projectId: string, branch: string): Observable<HttpResponse<any>>{
        return this.httpClient.getRequest(this.address + `push/${projectId}/${branch}`);
    }
}
