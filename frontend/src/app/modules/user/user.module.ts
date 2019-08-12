import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserRootComponent } from './components/user-root/user-root.component';
import { UserDetailsComponent } from './components/user-details/user-details.component';
import { UserSettingsComponent } from './components/user-settings/user-settings.component';
import { UserRoutingModule } from './user-routing.module';
import {DialogModule} from 'primeng/dialog';

@NgModule({
  declarations: [UserRootComponent, UserDetailsComponent, UserSettingsComponent],
  imports: [
    CommonModule,
    UserRoutingModule,
    DialogModule
  ]
})
export class UserModule { }
