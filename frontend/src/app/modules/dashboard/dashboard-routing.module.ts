import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardRootComponent } from './components/dashboard-root/dashboard-root.component';
import { AllProjectsListComponent } from './components/all-projects-list/all-projects-list.component';

const dashboardRoutes: Routes = [
  {
    path: 'dashboard',
    component: DashboardRootComponent,
    children:
    [
      {
        path: '',
        component: AllProjectsListComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(dashboardRoutes)],
  exports: [RouterModule]
})
export class DashboardRoutingModule { }
