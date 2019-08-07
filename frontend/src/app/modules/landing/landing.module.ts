import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LandingRootComponent } from './components/landing-root/landing-root.component';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [LandingRootComponent],
  imports: [
    CommonModule,
  ]
})
export class LandingModule { }
