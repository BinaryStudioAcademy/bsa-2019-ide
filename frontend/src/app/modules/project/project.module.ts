import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProjectRootComponent } from './components/project-root/project-root.component';
import { ProjectSettingsComponent } from './components/project-settings/project-settings.component';
import { ProjectDetailsComponent } from './components/project-details/project-details.component';
import { AppRoutingModule } from 'src/app/app-routing.module';

@NgModule({
  declarations: [ProjectRootComponent, ProjectSettingsComponent, ProjectDetailsComponent],
  imports: [
    CommonModule,
    AppRoutingModule
  ]
})
export class ProjectModule { }
