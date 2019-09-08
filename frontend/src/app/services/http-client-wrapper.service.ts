import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class HttpClientWrapperService {
    public baseUrl = environment.apiUrl;
    public headers = new HttpHeaders();

    constructor(private http: HttpClient) { }

    public getHeader(key: string) {
        return this.headers[key];
    }

    public setHeader(key: string, value: string) {
        this.headers.set(key, value);
    }

    public deleteHeader(key: string) {
        this.headers.delete(key);
    }

    public getRequest<T>(url: string, params?: any): Observable<HttpResponse<T>> {
        return this.http.get<T>(this.buildUrl(url), { headers: this.headers, params, observe: 'response' });
    }
    public getBlobRequest(url: string, params?: any): Observable<HttpResponse<Blob>> {
        return this.http.get(this.buildUrl(url), { headers: this.headers, params, observe: 'response', responseType: 'blob' })
    }

    public postRequest<T>(url: string, body: any | null): Observable<HttpResponse<T>> {
        return this.http.post<T>(this.buildUrl(url), body, { headers: this.headers, observe: 'response' });
    }

    public putRequest<T>(url: string, body: any | null): Observable<HttpResponse<T>> {
        return this.http.put<T>(this.buildUrl(url), body, { headers: this.headers, observe: 'response' });
    }

    public deleteRequest<T>(url: string, params?: any): Observable<HttpResponse<T>> {
        return this.http.delete<T>(this.buildUrl(url), { headers: this.headers, params, observe: 'response' });
    }

    public buildUrl(url: string) {
        return /^https?:\/\/.+/.test(url) ? url : this.baseUrl.concat(url);
    }

}
