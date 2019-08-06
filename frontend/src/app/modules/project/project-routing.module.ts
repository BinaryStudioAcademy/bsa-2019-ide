import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProjectRootComponent } from './components/project-root/project-root.component';
import { ProjectSettingsComponent } from './components/project-settings/project-settings.component';
import { ProjectDetailsComponent } from './components/project-details/project-details.component';

const projectRoutes: Routes = [
  {path: 'project/:id', component: ProjectRootComponent,
    children: [
      {path: '', component: ProjectDetailsComponent},
      {path: 'settings', component: ProjectSettingsComponent}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(projectRoutes)],
  exports: [RouterModule]
})
export class ProjectRoutingModule { }
