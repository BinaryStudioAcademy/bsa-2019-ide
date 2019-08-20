import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProjectRootComponent } from './components/project-root/project-root.component';
import { ProjectDetailsComponent } from './components/project-details/project-details.component';
import { ProjectRoutingModule } from './project-routing.module';
import { ProjectDetailsInfoComponent } from './components/project-details-info/project-details-info.component';
import { ProjectDetailsUserStatisticsComponent } from './components/project-details-user-statistics/project-details-user-statistics.component';

import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';
import { TableModule } from 'primeng/table';
import { ReactiveFormsModule } from '@angular/forms';
import { DropdownModule } from 'primeng/dropdown';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { InputTextModule } from 'primeng/inputtext';
import { KeyFilterModule } from 'primeng/keyfilter';
import { ProgressSpinnerModule } from 'primeng/progressspinner';
import { SharedModule } from '../shared/shared.module';
import {TabViewModule} from 'primeng/tabview';
import { ProjectWindowComponent } from './components/project-window/project-window.component';

@NgModule({
  declarations: [
    ProjectRootComponent,
    ProjectDetailsComponent,
    ProjectDetailsInfoComponent,
    ProjectDetailsUserStatisticsComponent,
    ProjectWindowComponent
  ],
  imports: [
    CommonModule,
    ProjectRoutingModule,
    ButtonModule,
    CardModule,
    TableModule,
    ReactiveFormsModule,
    DropdownModule,
    InputTextareaModule,
    InputTextModule,
    KeyFilterModule,
    SharedModule,
    ProgressSpinnerModule,
    TabViewModule,
    SharedModule
  ],
  entryComponents: [
    ProjectWindowComponent
  ]
})
export class ProjectModule { }
