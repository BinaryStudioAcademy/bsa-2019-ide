import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { AuthorizationModule } from './modules/authorization/authorization.module';
import { DashboardModule } from './modules/dashboard/dashboard.module';
import { LandingModule } from './modules/landing/landing.module';
import { ProjectModule } from './modules/project/project.module';
import { UserModule } from './modules/user/user.module';
import { WorkspaceModule } from './modules/workspace/workspace.module';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { MenubarModule } from 'primeng/menubar';
import { ButtonModule } from 'primeng/button';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import {ToastrModule} from 'ngx-toastr';
import { DynamicDialogModule } from 'primeng/components/dynamicdialog/dynamicdialog';
import { DialogService } from 'primeng/api';
import { JwtInterceptor } from './helpers/jwt.interceptor';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,

  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AuthorizationModule,
    DashboardModule,
    LandingModule,
    ProjectModule,
    UserModule,
    WorkspaceModule,
    AppRoutingModule,
    MenubarModule,
    ButtonModule,
    HttpClientModule,
    DynamicDialogModule,
    ToastrModule.forRoot()
  ],
  providers: 
  
    [DialogService,
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true }],
  bootstrap: [AppComponent]
})
export class AppModule { }
