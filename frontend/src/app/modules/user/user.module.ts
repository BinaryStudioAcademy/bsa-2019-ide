import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserRootComponent } from './components/user-root/user-root.component';
import { UserDetailsComponent } from './components/user-details/user-details.component';
import { UserSettingsComponent } from './components/user-settings/user-settings.component';
import { AppRoutingModule } from 'src/app/app-routing.module';

@NgModule({
  declarations: [UserRootComponent, UserDetailsComponent, UserSettingsComponent],
  imports: [
    CommonModule,
    AppRoutingModule
  ]
})
export class UserModule { }
