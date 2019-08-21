import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserRootComponent } from './components/user-root/user-root.component';
import { UserDetailsComponent } from './components/user-details/user-details.component';
import { UserSettingsComponent } from './components/user-settings/user-settings.component';
import { LoginGuard } from 'src/app/guards/login.guard';
import { EmailVerificationComponent } from './components/email-verification/email-verification.component';
const userRoutes: Routes = [
    {
        path: 'vf',
        component: EmailVerificationComponent
    },
    {
        path: 'user',
        component: UserRootComponent,
        children: [
            {
                path: 'details',
                component: UserDetailsComponent,
            },
            {
                path: 'settings',
                component: UserSettingsComponent
            }
        ],
        canActivate: [LoginGuard]
    }
];

@NgModule({
  imports: [RouterModule.forChild(userRoutes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
