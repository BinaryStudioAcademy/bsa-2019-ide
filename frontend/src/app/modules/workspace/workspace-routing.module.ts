import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { WorkspaceRootComponent } from './workspace-root/workspace-root.component';

const workspaceRoutes: Routes = [
  {path: 'workspace/:id', component: WorkspaceRootComponent}
];

@NgModule({
  imports: [RouterModule.forChild(workspaceRoutes)],
  exports: [RouterModule]
})
export class WorkspaceRoutingModule { }
