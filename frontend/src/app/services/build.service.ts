import { Injectable } from '@angular/core';
import { HttpClientWrapperService } from './http-client-wrapper.service';
import { Observable } from 'rxjs';
import { HttpResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class BuildService {

    private address = 'Project/';

    constructor(private httpClient: HttpClientWrapperService)
    { }

    public buildProject(id: number): Observable<HttpResponse<boolean>> {
        return this.httpClient.getRequest(`${this.address}build/${id}`);
    }

    public runProject(id: number, connectionId: string): Observable<HttpResponse<boolean>> {
        return this.httpClient.getRequest(`${this.address}run/${id}/${connectionId}`);
    }
}
