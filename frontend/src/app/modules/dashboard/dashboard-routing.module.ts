import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardRootComponent } from './components/dashboard-root/dashboard-root.component';
import { ProjectsListComponent } from './components/projects-list/projects-list.component';
import { AllProjectsComponent } from './components/all-projects/all-projects.component';
import { MyProjectsComponent } from './components/my-projects/my-projects.component';
import { AssignedProjectsComponent } from './components/assigned-projects/assigned-projects.component';
import { LoginGuard } from 'src/app/guards/login.guard';
import { FavouriteProjectsComponent } from './components/favourite-projects/favourite-projects.component';

const dashboardRoutes: Routes = [
    {
        path: 'dashboard',
        component: DashboardRootComponent,
        children:
        [
        {
            path: 'all',
            component: AllProjectsComponent
        },
        {
            path: 'assignedProjects',
            component: AssignedProjectsComponent
        },
        {
            component: FavouriteProjectsComponent,
            path: ''
        },
        {
            component: MyProjectsComponent,
            path: 'myProjects'
        }
        ],
        canActivate: [LoginGuard]
    }
];

@NgModule({
  imports: [RouterModule.forChild(dashboardRoutes)],
  exports: [RouterModule]
})
export class DashboardRoutingModule { }
