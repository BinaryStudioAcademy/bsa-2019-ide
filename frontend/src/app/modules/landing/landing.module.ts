import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LandingRootComponent } from './components/landing-root/landing-root.component';
import { CommentCardComponent } from './components/comment-card/comment-card.component';
import { ProjectCardComponent } from './components/project-card/project-card.component';

@NgModule({
  declarations: [
      LandingRootComponent,
      CommentCardComponent,
      ProjectCardComponent
    ],
  imports: [
    CommonModule,
  ]
})
export class LandingModule { }
