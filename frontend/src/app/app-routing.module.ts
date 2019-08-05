import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LandingRootComponent } from './modules/landing/components/landing-root/landing-root.component';
import { UserRootComponent } from './modules/user/components/user-root/user-root.component';
import { UserDetailsComponent } from './modules/user/components/user-details/user-details.component';
import { UserSettingsComponent } from './modules/user/components/user-settings/user-settings.component';
import { DashboardRootComponent } from './modules/dashboard/components/dashboard-root/dashboard-root.component';
import { ProjectRootComponent } from './modules/project/components/project-root/project-root.component';
import { ProjectSettingsComponent } from './modules/project/components/project-settings/project-settings.component';
import { ProjectDetailsComponent } from './modules/project/components/project-details/project-details.component';
import { WorkspaceRootComponent } from './modules/workspace/workspace-root/workspace-root.component';

const routes: Routes = [
  {path: '', component: LandingRootComponent},
  {path: 'user', component: UserRootComponent,
    children: [
      {path: '', component: UserDetailsComponent},
      {path: 'settings', component: UserSettingsComponent}
    ]
  },
  {path: 'dashboard', component: DashboardRootComponent},
  {path: 'project/:id', component: ProjectRootComponent,
    children: [
      {path: '', component: ProjectDetailsComponent},
      {path: 'settings', component: ProjectSettingsComponent}
    ]
  },
  {path: 'workspace/:id', component: WorkspaceRootComponent},
  {path: '**', redirectTo: '', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
