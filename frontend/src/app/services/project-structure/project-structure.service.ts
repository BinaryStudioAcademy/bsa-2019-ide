import { Injectable } from '@angular/core';
import { HttpClientWrapperService } from '../http-client-wrapper.service';
import { Observable } from 'rxjs';
import { HttpResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProjectStructureService {
    
    private address = 'projectstructure/';

    constructor(private httpClient:HttpClientWrapperService) { }

    public importFile(body) : Observable<HttpResponse<any>>{
        return this.httpClient.postRequest(`${this.address}import`, body)
    }
}
