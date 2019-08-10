import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardRootComponent } from './components/dashboard-root/dashboard-root.component';
import { DashboardRoutingModule } from './dashboard-routing.module';
import { MenuModule } from 'primeng/menu';
import { ProjectsListComponent } from './components/projects-list/projects-list.component';
import { ProjectCardComponent } from './components/project-card/project-card.component';
import {ButtonModule} from 'primeng/button';
import {CardModule} from 'primeng/card';
import {TabMenuModule} from 'primeng/tabmenu';
import { AllProjectsComponent } from './components/all-projects/all-projects.component';
import { MyProjectsComponent } from './components/my-projects/my-projects.component';
import { AssignedProjectsComponent } from './components/assigned-projects/assigned-projects.component';


@NgModule({
  declarations: [
    DashboardRootComponent,
    ProjectsListComponent,
    ProjectCardComponent,
    AllProjectsComponent,
    MyProjectsComponent,
    AssignedProjectsComponent
  ],
  imports: [
    CommonModule,
    DashboardRoutingModule,
    MenuModule,
    ButtonModule,
    CardModule,
    TabMenuModule
  ]
})
export class DashboardModule { }
