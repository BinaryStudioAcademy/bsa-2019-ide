import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LandingRootComponent } from './modules/landing/components/landing-root/landing-root.component';
import { LandingPageGuard } from './guards/landing-page.guard';
import { CallbackComponent } from './callback/callback.component';

const appRoutes: Routes = [
    { path: '', component: LandingRootComponent, canActivate: [LandingPageGuard] },
    { path: '**', redirectTo: '', pathMatch: 'full' },
    { path: 'callback', component: CallbackComponent}
];

@NgModule({
    imports: [
        RouterModule.forRoot(appRoutes)
    ],
    exports: [RouterModule]
})
export class AppRoutingModule { }
