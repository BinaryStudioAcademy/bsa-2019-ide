import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProjectRootComponent } from './components/project-root/project-root.component';
import { ProjectSettingsComponent } from './components/project-settings/project-settings.component';
import { ProjectDetailsComponent } from './components/project-details/project-details.component';
import { ProjectRoutingModule } from './project-routing.module';
import { ProjectDetailsInfoComponent } from './components/project-details-info/project-details-info.component';
import { ProjectDetailsUserStatisticsComponent } from './components/project-details-user-statistics/project-details-user-statistics.component';
import { ButtonModule } from 'primeng/button';
import {CardModule} from 'primeng/card';
import {TableModule} from 'primeng/table';

@NgModule({
  declarations: [ProjectRootComponent, ProjectSettingsComponent, ProjectDetailsComponent, ProjectDetailsInfoComponent, ProjectDetailsUserStatisticsComponent],
  imports: [
    CommonModule,
    ProjectRoutingModule,
    ButtonModule,
    CardModule,
    TableModule
  ]
})
export class ProjectModule { }
