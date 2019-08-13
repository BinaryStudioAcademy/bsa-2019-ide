import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProjectRootComponent } from './components/project-root/project-root.component';
import { ProjectSettingsComponent } from './components/project-settings/project-settings.component';
import { ProjectDetailsComponent } from './components/project-details/project-details.component';
import { CreateProjectComponent } from './components/create-project/create-project.component';
import { ProjectInfoResolver } from 'src/app/resolvers/project-info.resolver';
import { LoginGuard } from 'src/app/guards/login.guard';

const projectRoutes: Routes = [
  {
    path: 'project/add',
    component: CreateProjectComponent,
    canActivate: [LoginGuard]
  },
  {
    path: 'project',
    component: ProjectRootComponent,
    children: [
      {
        path: ':id',
        component: ProjectDetailsComponent,
        resolve: { project: ProjectInfoResolver } // What is it?
      },
      {
        path: ':id/settings',
        component: ProjectSettingsComponent
      }
    ],
    canActivate: [LoginGuard]
  }
];

@NgModule({
  imports: [RouterModule.forChild(projectRoutes)],
  exports: [RouterModule]
})
export class ProjectRoutingModule { }
