import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LandingRootComponent } from './components/landing-root/landing-root.component';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ProjectsListComponent } from './components/projects-list/projects-list.component';

@NgModule({
  declarations: [LandingRootComponent, ProjectsListComponent],
  imports: [
    CommonModule,
  ]
})
export class LandingModule { }
