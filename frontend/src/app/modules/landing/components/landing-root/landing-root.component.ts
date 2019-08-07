import { HttpClientWrapperService } from './../../../../services/http-client-wrapper.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-landing-root',
  templateUrl: './landing-root.component.html',
  styleUrls: ['./landing-root.component.sass']
})
export class LandingRootComponent implements OnInit {
  values: string[];
  constructor(private http: HttpClientWrapperService) { }

  ngOnInit() {
    this.http.getRequest<string[]>('values').subscribe(r => this.values = r.body);
  }

}
