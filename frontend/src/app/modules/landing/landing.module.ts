import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LandingRootComponent } from './components/landing-root/landing-root.component';
import { CommentCardComponent } from './components/comment-card/comment-card.component';
import { ProjectCardComponent } from './components/project-card/project-card.component';
import { SharedModule } from '../shared/shared.module';
import { PrettySizePipe } from './pipes/pretty-size.pipe';

@NgModule({
  declarations: [
      LandingRootComponent,
      CommentCardComponent,
      ProjectCardComponent,
      PrettySizePipe
    ],
  imports: [
    CommonModule,
    SharedModule
  ]
})
export class LandingModule { }
