import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CollaboratorRoutingModule } from '../collaborator/collaborator-routing.module';
import { AddCollaboratorsComponent } from './components/add-collaborators/add-collaborators.component';
import { FormsModule } from '@angular/forms';
import { AutoCompleteModule } from "primeng/primeng"
import { ProjectModule } from '../project/project.module'



@NgModule({
    declarations: [
        AddCollaboratorsComponent
    ],
    imports: [
        CommonModule,
        CollaboratorRoutingModule,
        FormsModule,
        AutoCompleteModule,
        ProjectModule
    ]
})
export class CollaboratorModule { }
