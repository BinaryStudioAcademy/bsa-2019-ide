import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProjectRootComponent } from './components/project-root/project-root.component';
import { ProjectDetailsComponent } from './components/project-details/project-details.component';
import { ProjectInfoResolver } from 'src/app/resolvers/project-info.resolver';
import { LoginGuard } from 'src/app/guards/login.guard';

const projectRoutes: Routes = [
  {
    path: 'project',
    component: ProjectRootComponent,
    children: [
      {
        path: ':id',
        component: ProjectDetailsComponent,
        resolve: { project: ProjectInfoResolver } // What is it?
                                                  // I don't know bro.
      }                                           // Gyus this is for loading data
    ],
    canActivate: [LoginGuard]
  }
];

@NgModule({
  imports: [RouterModule.forChild(projectRoutes)],
  exports: [RouterModule]
})
export class ProjectRoutingModule { }
