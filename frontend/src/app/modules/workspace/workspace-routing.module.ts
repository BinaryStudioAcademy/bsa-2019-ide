import { SaveBeforeExitGuard } from './../../guards/save-before-exit.guard';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { WorkspaceRootComponent } from './workspace-root/workspace-root.component';
import { LoginGuard } from 'src/app/guards/login.guard';
import { AddCollaboratorsComponent } from '../collaborator/components/add-collaborators/add-collaborators.component';

const workspaceRoutes: Routes = [
    {
        path: 'workspace/:id',
        component: WorkspaceRootComponent,
        canActivate: [LoginGuard]
    }
];

@NgModule({
  imports: [RouterModule.forChild(workspaceRoutes)],
  exports: [RouterModule]
})
export class WorkspaceRoutingModule { }
