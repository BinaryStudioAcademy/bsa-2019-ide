import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CollaboratorRoutingModule } from '../collaborator/collaborator-routing.module';
import { AddCollaboratorsComponent } from './components/add-collaborators/add-collaborators.component';
import { FormsModule } from '@angular/forms';
import { AutoCompleteModule } from "primeng/primeng"
import { ProjectModule } from '../project/project.module'
import { ProgressSpinnerModule } from 'primeng/progressspinner';
import { ButtonModule } from 'primeng/button';
import { AddCollaboratorsListComponent } from './components/add-collaborators-list/add-collaborators-list.component';
import { DropdownModule } from 'primeng/dropdown';

@NgModule({
    declarations: [
        AddCollaboratorsComponent,
        AddCollaboratorsListComponent
    ],
    imports: [
        CommonModule,
        CollaboratorRoutingModule,
        FormsModule,
        DropdownModule,
        AutoCompleteModule,
        ProjectModule,
        ProgressSpinnerModule,
        ButtonModule
    ]
})
export class CollaboratorModule { }
