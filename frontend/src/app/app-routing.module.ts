import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LandingRootComponent } from './modules/landing/components/landing-root/landing-root.component';
import { LandingPageGuard } from './guards/landing-page.guard';

const appRoutes: Routes = [
    { path: '', component: LandingRootComponent, canActivate: [LandingPageGuard] },
    { path: '**', redirectTo: '', pathMatch: 'full' }
];

@NgModule({
    imports: [
        RouterModule.forRoot(appRoutes)
    ],
    exports: [RouterModule]
})
export class AppRoutingModule { }
