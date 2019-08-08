import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardRootComponent } from './components/dashboard-root/dashboard-root.component';
import { AllProjectsListComponent } from './components/all-projects-list/all-projects-list.component';
import { CreateProjectComponent } from './components/create-project/create-project.component';

const dashboardRoutes: Routes = [
  {
    path: 'dashboard',
    component: DashboardRootComponent,
    children:
    [
      {
        path: '',
        component: AllProjectsListComponent
      },
      {
        path: 'add',
        component: CreateProjectComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(dashboardRoutes)],
  exports: [RouterModule]
})
export class DashboardRoutingModule { }
