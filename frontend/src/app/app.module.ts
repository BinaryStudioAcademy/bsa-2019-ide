import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { AuthorizationModule } from './modules/authorization/authorization.module';
import { DashboardModule } from './modules/dashboard/dashboard.module';
import { LandingModule } from './modules/landing/landing.module';
import { ProjectModule } from './modules/project/project.module';
import { UserModule } from './modules/user/user.module';
import { WorkspaceModule } from './modules/workspace/workspace.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AuthorizationModule,
    DashboardModule,
    LandingModule,
    ProjectModule,
    UserModule,
    WorkspaceModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
