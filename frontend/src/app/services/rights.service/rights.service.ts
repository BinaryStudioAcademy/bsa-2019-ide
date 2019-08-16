import { Injectable } from '@angular/core';
import { HttpClientWrapperService } from '../http-client-wrapper.service';
import { Observable } from 'rxjs';
import { HttpResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class RightsService {

    private address = 'rights';

  constructor(private httpClient: HttpClientWrapperService) { }

  public getUsersRigths(): Observable<HttpResponse<[]>>
    {
        return this.httpClient.getRequest(this.address+'/name');
    }
}
