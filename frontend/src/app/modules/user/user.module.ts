import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserRootComponent } from './components/user-root/user-root.component';
import { UserDetailsComponent } from './components/user-details/user-details.component';
import { UserSettingsComponent } from './components/user-settings/user-settings.component';
import { UserRoutingModule } from './user-routing.module';
import {DialogModule} from 'primeng/dialog';
import {SlideMenuModule} from 'primeng/slidemenu';
import {ButtonModule} from 'primeng/button';
import {ProgressSpinnerModule} from 'primeng/progressspinner';
import { EmailVerificationComponent } from './components/email-verification/email-verification.component';
import { UserDialogWindowComponent } from './components/user-dialog-window/user-dialog-window.component';
import { ReactiveFormsModule } from '@angular/forms';
import { InputTextModule, KeyFilterModule } from 'primeng/primeng';
import { DynamicDialogModule } from 'primeng/components/dynamicdialog/dynamicdialog';

@NgModule({
    declarations: [
        UserRootComponent, 
        UserDetailsComponent, 
        UserSettingsComponent, 
        EmailVerificationComponent, UserDialogWindowComponent
    ],
    imports: [
        CommonModule,
        UserRoutingModule,
        DialogModule,
        SlideMenuModule,
        ButtonModule,
        ProgressSpinnerModule,
        ButtonModule,
        ReactiveFormsModule,
        InputTextModule,
        KeyFilterModule,
        DynamicDialogModule,
    ],
    entryComponents: [
        UserDialogWindowComponent
      ],
})
export class UserModule { }
