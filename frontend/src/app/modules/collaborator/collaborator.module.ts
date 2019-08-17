import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CollaboratorRoutingModule } from '../collaborator/collaborator-routing.module';
import { AddCollaboratorsComponent } from './components/add-collaborators/add-collaborators.component';



@NgModule({
  declarations: [
    AddCollaboratorsComponent
  ],
  imports: [
    CommonModule,
    CollaboratorRoutingModule
  ]
})
export class CollaboratorModule { }
