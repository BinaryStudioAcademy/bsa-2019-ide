import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardRootComponent } from './components/dashboard-root/dashboard-root.component';
import { ProjectsListComponent } from './components/projects-list/projects-list.component';
import { AllProjectsComponent } from './components/all-projects/all-projects.component';
import { MyProjectsComponent } from './components/my-projects/my-projects.component';
import { AssignedProjectsComponent } from './components/assigned-projects/assigned-projects.component';

const dashboardRoutes: Routes = [
  {
    path: 'dashboard',
    component: DashboardRootComponent,
    children:
    [
      {
        path: '',
        component: AllProjectsComponent
      },
      {
        path: 'myProjects',
        component: MyProjectsComponent
      },
      {
        path: 'assignedProjects',
        component: AssignedProjectsComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(dashboardRoutes)],
  exports: [RouterModule]
})
export class DashboardRoutingModule { }
