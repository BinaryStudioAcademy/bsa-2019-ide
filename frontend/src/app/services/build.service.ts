import { Injectable } from '@angular/core';
import { HttpClientWrapperService } from './http-client-wrapper.service';
import { Observable } from 'rxjs';
import { HttpResponse } from '@angular/common/http';
import { DialogService } from 'primeng/api';
import { RunInputComponent } from '../modules/workspace/run-input/run-input.component';

@Injectable({
  providedIn: 'root'
})
export class BuildService {

    private address = 'Project/';

    constructor(private httpClient: HttpClientWrapperService,
        private dialogService: DialogService)
    { }

    public buildProject(id: number): Observable<HttpResponse<boolean>> {
        return this.httpClient.getRequest(`${this.address}build/${id}`);
    }

    public runProject(id: number, connectionId: string): Observable<HttpResponse<string[]>> {
        return this.httpClient.getRequest(`${this.address}tryrun/${id}/${connectionId}`);
    }

    public showInputWindow(inputItem: string[])
    {
        const ref = this.dialogService.open(RunInputComponent,
            {
                data: { 
                    input: inputItem
                },
                width: '500px',
                style: {
                    'box-shadow': '0 0 3px 0 #000',
                },
                contentStyle: {
                    'border-radius': '3px',
                    'overflow-y': 'auto',
                    'max-height': '90vh'
                },
                showHeader: false,
                closeOnEscape: true
            });
            return ref.onClose;
    }
}
