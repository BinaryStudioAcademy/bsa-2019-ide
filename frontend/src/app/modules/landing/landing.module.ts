import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LandingRootComponent } from './components/landing-root/landing-root.component';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ProjectsListComponent } from './components/projects-list/projects-list.component';
import { CommentCardComponent } from './components/comment-card/comment-card.component';

@NgModule({
  declarations: [LandingRootComponent, ProjectsListComponent, CommentCardComponent],
  imports: [
    CommonModule,
  ]
})
export class LandingModule { }
