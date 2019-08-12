import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserRootComponent } from './components/user-root/user-root.component';
import { UserDetailsComponent } from './components/user-details/user-details.component';
import { UserSettingsComponent } from './components/user-settings/user-settings.component';
import { UserRoutingModule } from './user-routing.module';
import {DialogModule} from 'primeng/dialog';
import {SlideMenuModule} from 'primeng/slidemenu';
import {ButtonModule} from 'primeng/button';

@NgModule({
  declarations: [UserRootComponent, UserDetailsComponent, UserSettingsComponent],
  imports: [
    CommonModule,
    UserRoutingModule,
    DialogModule,
    SlideMenuModule,
    ButtonModule
  ]
})
export class UserModule { }
