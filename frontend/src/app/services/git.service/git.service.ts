import { Injectable } from '@angular/core';
import { HttpClientWrapperService } from '../http-client-wrapper.service';
import { Observable } from 'rxjs';
import { HttpResponse } from '@angular/common/http';
import { GitBranchDTO } from 'src/app/models/DTO/Git/gitBranchDTO';
import { GitMessageDTO } from 'src/app/models/DTO/Git/gitMessageDTO';
import { GitCredentialsDTO } from 'src/app/models/DTO/Git/gitCredentialsDTO';

@Injectable({
  providedIn: 'root'
})
export class GitService {

    private address: string = 'git/';

    constructor(private httpClient: HttpClientWrapperService) { }
        
    clone(): Observable<HttpResponse<any>>{
        return this.httpClient.getRequest('git/clone');
    }

    pull(git:GitBranchDTO): Observable<HttpResponse<any>>{
        return this.httpClient.postRequest(this.address + `pull`, git);
    }

    commit(git:GitMessageDTO): Observable<HttpResponse<any>>{
        return this.httpClient.postRequest(this.address + `commit`, git);
    }

    push(git: GitBranchDTO): Observable<HttpResponse<any>>{
        return this.httpClient.postRequest(this.address + `push`, git);
    }

    addCredentials(git: GitCredentialsDTO): Observable<HttpResponse<any>>{
        return this.httpClient.postRequest(this.address + `credentials`, git);
    }
}
