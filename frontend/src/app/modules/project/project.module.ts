import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProjectRootComponent } from './components/project-root/project-root.component';
import { ProjectDetailsComponent } from './components/project-details/project-details.component';
import { ProjectRoutingModule } from './project-routing.module';
import { ProjectDetailsInfoComponent } from './components/project-details-info/project-details-info.component';
import { ProjectDetailsUserStatisticsComponent } from './components/project-details-user-statistics/project-details-user-statistics.component';
import { DynamicDialogRef, DynamicDialogConfig } from 'primeng/api';

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
import { FormsModule } from '@angular/forms';
import { DynamicDialogModule } from 'primeng/components/dynamicdialog/dynamicdialog';
import { CollaboratorModule } from '../collaborator/collaborator.module';
import { AddCollaboratorsComponent } from '../collaborator/components/add-collaborators/add-collaborators.component';
import {FileUploadModule} from 'primeng/fileupload';
import { HistoryChangesComponent } from './components/history-changes/history-changes.component';
import {AccordionModule} from 'primeng/accordion';
import { HistorySearchPipe } from './pipes/history-search.pipe';


@NgModule({
  declarations: [
    ProjectRootComponent,
    ProjectDetailsComponent,
    ProjectDetailsInfoComponent,
    ProjectDetailsUserStatisticsComponent,
    ProjectWindowComponent,
    HistoryChangesComponent,
    HistorySearchPipe
  ],
  imports: [
    FormsModule,
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
    DynamicDialogModule,
    CollaboratorModule,
    FileUploadModule,
    AccordionModule
  ],
  entryComponents: [
    ProjectWindowComponent
  ],
  providers:[
    AddCollaboratorsComponent,
    DynamicDialogRef,
    DynamicDialogConfig    
  ]
})
export class ProjectModule { }
