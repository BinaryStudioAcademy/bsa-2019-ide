import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProjectRootComponent } from './components/project-root/project-root.component';
import { ProjectSettingsComponent } from './components/project-settings/project-settings.component';
import { ProjectDetailsComponent } from './components/project-details/project-details.component';
import { CreateProjectComponent } from './components/create-project/create-project.component';
import { ProjectInfoResolver } from 'src/app/resolvers/project-info.resolver';
import { LoginGuard } from 'src/app/guards/login.guard';
import { AddCollaboratorsComponent } from '../collaborator/components/add-collaborators/add-collaborators.component';

const projectRoutes: Routes = [
  {
    path: 'project',
    component: ProjectRootComponent,
    children: [
      {
        path: 'add',
        component: CreateProjectComponent
      },
      {
        path: ':id',
        component: ProjectDetailsComponent,
        resolve: { project: ProjectInfoResolver } // What is it?
                                                  // I don't know bro.
                                                  // Gyus this is for loading data
      },                                         
      {
        path: ':id/settings',
        component: ProjectSettingsComponent
      },
    ],
    canActivate: [LoginGuard]
  }
];

@NgModule({
  imports: [RouterModule.forChild(projectRoutes)],
  exports: [RouterModule]
})
export class ProjectRoutingModule { }
