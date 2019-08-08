import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardRootComponent } from './components/dashboard-root/dashboard-root.component';
import { DashboardRoutingModule } from './dashboard-routing.module';
import { MenuModule } from 'primeng/menu';
import { AllProjectsListComponent } from './components/all-projects-list/all-projects-list.component';
import { ProjectCardComponent } from './components/project-card/project-card.component';


@NgModule({
  declarations: [
    DashboardRootComponent,
    AllProjectsListComponent,
    ProjectCardComponent
  ],
  imports: [
    CommonModule,
    DashboardRoutingModule,
    MenuModule
  ]
})
export class DashboardModule { }
