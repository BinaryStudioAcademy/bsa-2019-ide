import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardRootComponent } from './components/dashboard-root/dashboard-root.component';
import { DashboardRoutingModule } from './dashboard-routing.module';
import { MenuModule } from 'primeng/menu';


@NgModule({
  declarations: [DashboardRootComponent],
  imports: [
    CommonModule,
    DashboardRoutingModule,
    MenuModule
  ]
})
export class DashboardModule { }
