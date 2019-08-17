import { NgModule } from '@angular/core';
import { AddCollaboratorsComponent } from './components/add-collaborators/add-collaborators.component';
import { Routes, RouterModule } from '@angular/router';
import { LoginGuard } from 'src/app/guards/login.guard';

const addCollaboratorsRoutes: Routes = [
    {
        path: 'addcollaborators/:id',
        component: AddCollaboratorsComponent,
        canActivate: [LoginGuard]
    }
];

@NgModule({
  imports: [RouterModule.forChild(addCollaboratorsRoutes)],
  exports: [RouterModule]
})

export class CollaboratorRoutingModule { }
