import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LandingRootComponent } from './components/landing-root/landing-root.component';
import { CommentCardComponent } from './components/comment-card/comment-card.component';
import { ProjectCardComponent } from './components/project-card/project-card.component';
import { SharedModule } from '../shared/shared.module';
import { PrettySizePipe } from './pipes/pretty-size.pipe';
import { FooterComponent } from './components/footer/footer.component';

@NgModule({
  declarations: [
      LandingRootComponent,
      CommentCardComponent,
      ProjectCardComponent,
      PrettySizePipe,
      FooterComponent
    ],
  imports: [
    CommonModule,
    SharedModule
  ]
})
export class LandingModule { }
