import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardRootComponent } from './components/dashboard-root/dashboard-root.component';
import { DashboardRoutingModule } from './dashboard-routing.module';
import { MenuModule } from 'primeng/menu';
import { AllProjectsListComponent } from './components/all-projects-list/all-projects-list.component';
import { CreateProjectComponent } from './components/create-project/create-project.component';


@NgModule({
  declarations: [
    DashboardRootComponent,
    AllProjectsListComponent,
    CreateProjectComponent
  ],
  imports: [
    CommonModule,
    DashboardRoutingModule,
    MenuModule
  ]
})
export class DashboardModule { }
