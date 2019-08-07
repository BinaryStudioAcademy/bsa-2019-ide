import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpHeaders } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class HttpService {
    public baseUrl: string = environment.apiUrl;
    public headers = new HttpHeaders();

    constructor(private http: HttpClient) {}

    public getHeaders(): HttpHeaders {
        return this.headers;
    }

    public getHeader(key: string): string {
        return this.headers[key];
    }

    public setHeader(key: string, value: string): void {
        this.headers[key] = value;
    }

    public deleteHeader(key: string): void {
        delete this.headers[key];
    }

    public getRequest<T>(url: string, httpParams?: any): Observable<T> {
        return this.http.get<T>(this.buildUrl(url), { headers: this.getHeaders(), params: httpParams });
    }

    public getFullRequest<T>(url: string, httpParams?: any): Observable<HttpResponse<T>> {
        return this.http.get<T>(this.buildUrl(url), { observe: 'response', headers: this.getHeaders(), params: httpParams });
    }

    public postClearRequest<T>(url: string, payload: object): Observable<T> {
        return this.http.post<T>(this.buildUrl(url), payload);
    }

    public postRequest<T>(url: string, payload: object): Observable<T> {
        return this.http.post<T>(this.buildUrl(url), payload, { headers: this.getHeaders() });
    }

    public postFullRequest<T>(url: string, payload: object): Observable<HttpResponse<T>> {
      console.log(url);
      console.log(this.getHeaders());
        return this.http.post<T>(this.buildUrl(url), payload, { headers: this.getHeaders(), observe: 'response' });
    }

    public putRequest<T>(url: string, payload: object): Observable<T> {
        return this.http.put<T>(this.buildUrl(url), payload, { headers: this.getHeaders() });
    }

    public putFullRequest<T>(url: string, payload: object): Observable<HttpResponse<T>> {
        return this.http.put<T>(this.buildUrl(url), payload, { headers: this.getHeaders(), observe: 'response' });
    }

    public deleteRequest<T>(url: string, httpParams?: any): Observable<T> {
        return this.http.delete<T>(this.buildUrl(url), { headers: this.getHeaders(), params: httpParams });
    }

    public deleteFullRequest<T>(url: string, httpParams?: any): Observable<HttpResponse<T>> {
        return this.http.delete<T>(this.buildUrl(url), { headers: this.getHeaders(), observe: 'response', params: httpParams });
    }

    public buildUrl(url: string): string {
        if (url.startsWith('http://') || url.startsWith('https://')) {
            return url;
        }
        return this.baseUrl + url;
    }

    public prepareData(payload: object): string {
        return JSON.stringify(payload);
    }
}
