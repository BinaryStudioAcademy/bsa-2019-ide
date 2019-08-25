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
import { EditorModule } from '../editor/editor.module';
import { TabViewModule } from 'primeng/primeng';

@NgModule({
    declarations: [
        UserRootComponent, 
        UserDetailsComponent, 
        UserSettingsComponent, 
        EmailVerificationComponent
    ],
    imports: [
        CommonModule,
        UserRoutingModule,
        DialogModule,
        SlideMenuModule,
        ButtonModule,
        ProgressSpinnerModule,
        EditorModule,
        TabViewModule
    ]
})
export class UserModule { }
