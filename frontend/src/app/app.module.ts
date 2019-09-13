import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { AuthorizationModule } from './modules/authorization/authorization.module';
import { DashboardModule } from './modules/dashboard/dashboard.module';
import {CollaboratorModule} from './modules/collaborator/collaborator.module';
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
import { MenuModule,AutoCompleteModule, ListboxModule, AccordionModule, OverlayPanelModule } from 'primeng/primeng';
import { MonacoEditorModule } from '@materia-ui/ngx-monaco-editor';
import { LoginGuard } from './guards/login.guard';
import { JwtModule } from '@auth0/angular-jwt';
import { TokenGetter } from './services/token.service/token.service';
import { RefreshTokenInterceptor } from './helpers/token.interceptor';
import { SplitButtonModule } from 'primeng/splitbutton';
import { SharedModule } from './modules/shared/shared.module';
import { FormsModule } from '@angular/forms';
import { ProjectSettingsRouteGuard } from './guards/project-settings-route.guard';
import { AddCollaboratorsComponent } from './modules/collaborator/components/add-collaborators/add-collaborators.component';
import { FileInfoComponent } from './modules/workspace/file-info/file-info.component';
import { ChartsModule } from 'ng2-charts';

import { HighlightMatchDirective } from './directives/highlight-match.directive';
import { ImportFileComponent } from './modules/workspace/import-file/import-file.component';
import { NotificationStatusDirective } from './directives/notification-status/notification-status.directive';
import { NotificationComponent } from './notification/notification.component';
import { CallbackComponent } from './callback/callback.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        NotificationStatusDirective,
        NotificationComponent,
        CallbackComponent

    ],
    imports: [
        OverlayPanelModule,
        AccordionModule,
        ListboxModule,
        ChartsModule,
        CollaboratorModule,
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
        ProjectSettingsRouteGuard
    ],
    entryComponents: [
        AddCollaboratorsComponent,
        FileInfoComponent,
        ImportFileComponent
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
