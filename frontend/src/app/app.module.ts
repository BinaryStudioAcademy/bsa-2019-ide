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
import { ToastrModule } from 'ngx-toastr';
import { DynamicDialogModule } from 'primeng/components/dynamicdialog/dynamicdialog';
import { DialogService } from 'primeng/api';
import { JwtInterceptor } from './helpers/jwt.interceptor';
import { GeneralModule } from './general/general.module';
import { TreeModule } from 'primeng/tree';
import { MenuModule,AutoCompleteModule } from 'primeng/primeng';
import {MonacoEditorModule } from '@materia-ui/ngx-monaco-editor';
import { LoginGuard } from './guards/login.guard';
import { JwtModule } from '@auth0/angular-jwt';
import { TokenGetter } from './services/token.service/token.service';
import { RefreshTokenInterceptor } from './helpers/token.interceptor';
import {SplitButtonModule} from 'primeng/splitbutton';
import { SharedModule } from './modules/shared/shared.module';
import { FormsModule } from '@angular/forms';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,

    ],
    imports: [
        AutoCompleteModule,
        FormsModule,
        SplitButtonModule,
        MenuModule,
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
        SharedModule,
        HttpClientModule,
        DynamicDialogModule,
        ToastrModule.forRoot({
            positionClass: 'toast-bottom-right'
          }),
        GeneralModule,
        TreeModule,
        MonacoEditorModule,
        JwtModule.forRoot({
            config: {
                tokenGetter: TokenGetter,
            }
        })
    ],
    providers: [
        DialogService,
        {
            provide: HTTP_INTERCEPTORS,
            useClass: RefreshTokenInterceptor,
            multi: true
        },
        {
            provide: HTTP_INTERCEPTORS,
            useClass: JwtInterceptor,
            multi: true
        },
        LoginGuard,
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
