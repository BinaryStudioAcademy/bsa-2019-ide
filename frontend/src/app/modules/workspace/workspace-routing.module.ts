import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { WorkspaceRootComponent } from './workspace-root/workspace-root.component';
import { LoginGuard } from 'src/app/guards/login.guard';

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
