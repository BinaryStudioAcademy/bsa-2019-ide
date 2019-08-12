import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProjectRootComponent } from './components/project-root/project-root.component';
import { ProjectSettingsComponent } from './components/project-settings/project-settings.component';
import { ProjectDetailsComponent } from './components/project-details/project-details.component';
import { CreateProjectComponent } from './components/create-project/create-project.component';
import { ProjectInfoResolver } from 'src/app/resolvers/project-info.resolver';

const projectRoutes: Routes = [
  {
    path: 'project/add',
    component: CreateProjectComponent
  },
  {
    path: 'project/:id',
    component: ProjectRootComponent,
    children: [
      {
        path: '',
        component: ProjectDetailsComponent,
        resolve: { project: ProjectInfoResolver }
      },
      {
        path: 'settings',
        component: ProjectSettingsComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(projectRoutes)],
  exports: [RouterModule]
})
export class ProjectRoutingModule { }
