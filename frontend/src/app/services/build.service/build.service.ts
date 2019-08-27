import { Injectable } from '@angular/core';
import { HttpClientWrapperService } from '../http-client-wrapper.service';
import { BuildDTO } from 'src/app/models/DTO/Common/buildDTO';
import { Observable } from 'rxjs';
import { HttpResponse } from '@angular/common/http';
import { BuildDescriptionDTO } from 'src/app/models/DTO/Common/buildDescriptionDTO';

@Injectable({
  providedIn: 'root'
})
export class BuildService {

    private address: string = 'builds';

    constructor(
        private http: HttpClientWrapperService
    ) { }
  
    public GetBuildsByUserId(userId: number): Observable<HttpResponse<BuildDescriptionDTO[]>>{
        return this.http.getRequest(this.address+"/"+userId);
    }
}
