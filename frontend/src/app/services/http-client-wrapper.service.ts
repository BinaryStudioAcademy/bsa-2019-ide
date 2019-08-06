import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class HttpClientWrapperService {
  public baseUrl = environment.apiUrl;
  
  constructor(private http: HttpClient) { }
}
