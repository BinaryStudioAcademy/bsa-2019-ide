import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardRootComponent } from './components/dashboard-root/dashboard-root.component';
import { DashboardRoutingModule } from './dashboard-routing.module';


@NgModule({
  declarations: [DashboardRootComponent],
  imports: [
    CommonModule,
    DashboardRoutingModule
  ]
})
export class DashboardModule { }
