import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserRootComponent } from './components/user-root/user-root.component';
import { UserDetailsComponent } from './components/user-details/user-details.component';
import { UserSettingsComponent } from './components/user-settings/user-settings.component';
import { UserRoutingModule } from './user-routing.module';
import { DialogModule } from 'primeng/dialog';
import { SlideMenuModule } from 'primeng/slidemenu';
import { ButtonModule } from 'primeng/button';
import { EmailVerificationComponent } from './components/email-verification/email-verification.component';
import { UserDialogWindowComponent } from './components/user-dialog-window/user-dialog-window.component';
import { ReactiveFormsModule } from '@angular/forms';
import { InputTextModule, KeyFilterModule, AccordionModule } from 'primeng/primeng';
import { DynamicDialogModule } from 'primeng/components/dynamicdialog/dynamicdialog';
import { ImageCropperModule } from 'ngx-image-cropper';
import { PasswordModule } from 'primeng/password';
import { CardModule } from 'primeng/card';
import { EditorModule } from '../editor/editor.module';
import { TabViewModule } from 'primeng/primeng';
import { CalendarModule } from 'primeng/calendar';
import {ConfirmDialogModule} from 'primeng/confirmdialog';
import {ProgressBarModule} from 'primeng/progressbar';
import { ProgressSpinnerModule}  from 'primeng/progressspinner';
import { SharedModule } from '../shared/shared.module';
import { TableModule } from 'primeng/table';
import { UserProjectsComponent } from './components/user-projects/user-projects.component';

@NgModule({
    declarations: [
        UserRootComponent, 
        UserDetailsComponent, 
        UserSettingsComponent, 
        EmailVerificationComponent,
        UserDialogWindowComponent,
        UserProjectsComponent
    ],
    imports: [
        CommonModule,
        UserRoutingModule,
        DialogModule,
        SlideMenuModule,
        ButtonModule,
        EditorModule,
        TabViewModule,
        ProgressBarModule,
        ButtonModule,
        ReactiveFormsModule,
        InputTextModule,
        KeyFilterModule,
        DynamicDialogModule,
        ImageCropperModule,
        PasswordModule,
        CardModule,
        AccordionModule,
        CardModule,
        CalendarModule,
        ConfirmDialogModule,
        ProgressSpinnerModule,
        SharedModule,
        TableModule
    ],
    entryComponents: [
        UserDialogWindowComponent
      ],
})
export class UserModule { }
