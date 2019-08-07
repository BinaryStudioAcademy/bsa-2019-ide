import { HttpClientWrapperService } from './../../../../services/http-client-wrapper.service';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-landing-root',
  templateUrl: './landing-root.component.html',
  styleUrls: ['./landing-root.component.sass']
})
export class LandingRootComponent implements OnInit {
  values: string[];
  constructor( private tr: ToastrService) { }

  ngOnInit() {
  }

  hello(message: string) {
    this.tr.success(message, 'Success');
  }

}
