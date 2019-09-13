import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardRootComponent } from './components/dashboard-root/dashboard-root.component';
import { DashboardRoutingModule } from './dashboard-routing.module';
import { MenuModule } from 'primeng/menu';
import { ProjectsListComponent } from './components/projects-list/projects-list.component';
import { ProjectCardComponent } from './components/project-card/project-card.component';
import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';
import { TabMenuModule } from 'primeng/tabmenu';
import { MyProjectsComponent } from './components/my-projects/my-projects.component';
import { AssignedProjectsComponent } from './components/assigned-projects/assigned-projects.component';
import { FavouriteProjectsComponent } from './components/favourite-projects/favourite-projects.component';
import { ContextMenuModule } from 'primeng/contextmenu';
import { SharedModule } from '../shared/shared.module';
import { DialogModule } from 'primeng/dialog';
import { ProjectUpdateComponent } from 'src/app/modules/project/components/project-update/project-update.component';
import { ProjectWindowComponent } from '../project/components/project-window/project-window.component';
import { ProgressSpinnerModule, DropdownModule, FileUploadModule, InplaceModule, InputTextModule, InputTextareaModule } from 'primeng/primeng';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FontAwesomeModule, FaIconLibrary } from '@fortawesome/angular-fontawesome';
import { DatePipe } from '@angular/common'

import { faSquare, faCheckSquare, faFolderPlus, faFileArchive } from '@fortawesome/free-solid-svg-icons';
import { faCoffee } from '@fortawesome/free-solid-svg-icons';
import { faStackOverflow, faGithub, faMedium } from '@fortawesome/free-brands-svg-icons';
import { BrowserModule } from '@angular/platform-browser';

@NgModule({
    declarations: [
        DashboardRootComponent,
        ProjectsListComponent,
        ProjectCardComponent,
        MyProjectsComponent,
        AssignedProjectsComponent,
        FavouriteProjectsComponent,
        ProjectWindowComponent,
        ProjectUpdateComponent
    ],
    imports: [
        CommonModule,
        DashboardRoutingModule,
        MenuModule,
        ButtonModule,
        CardModule,
        TabMenuModule,
        ContextMenuModule,
        SharedModule,
        DialogModule,
        ProgressSpinnerModule,
        FormsModule,
        ReactiveFormsModule,
        DropdownModule,
        FileUploadModule,
        InplaceModule,
        InputTextModule,
        InputTextareaModule,
        FontAwesomeModule,
        BrowserModule
    ],
    providers: [DatePipe]
})
export class DashboardModule {
    constructor(library: FaIconLibrary) {
        library.addIcons(faSquare,
            faCheckSquare,
            faStackOverflow,
            faGithub,
            faMedium,
            faFolderPlus,
            faCoffee,
            faFileArchive,
            faGithub);
    }
}
