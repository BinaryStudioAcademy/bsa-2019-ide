import { Injectable } from '@angular/core';
import { HttpClientWrapperService } from './http-client-wrapper.service';
import { Observable } from 'rxjs';
import { HttpResponse, HttpParams } from '@angular/common/http';
import { DialogService } from 'primeng/api';
import { RunInputComponent } from '../modules/workspace/run-input/run-input.component';

@Injectable({
    providedIn: 'root'
})
export class BuildService {

    private address = 'Project/';

    constructor(private httpClient: HttpClientWrapperService,
        private dialogService: DialogService) { }

    public buildProject(id: number): Observable<HttpResponse<boolean>> {
        return this.httpClient.getRequest(`${this.address}build/${id}`);
    }

    public runProject(id: number, connectionId: string): Observable<HttpResponse<string[]>> {
        return this.httpClient.getRequest(`${this.address}tryrun/${id}/${connectionId}`);
    }

    public runProjectWithInputs(id: number, connectionId: string, inputs: string[]): Observable<HttpResponse<string>> {
        let params = new HttpParams();
        params = params.append('inputs', inputs.join(', '));
        console.log(params);
        return this.httpClient.getRequest(`${this.address}run/${id}/${connectionId}`, params);
    }
}
