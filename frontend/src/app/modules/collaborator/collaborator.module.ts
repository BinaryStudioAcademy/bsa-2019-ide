import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddCollaboratorsComponent } from './components/add-collaborators/add-collaborators.component';
import { FormsModule } from '@angular/forms';
import { AutoCompleteModule } from "primeng/primeng"
import { ProgressSpinnerModule } from 'primeng/progressspinner';
import { ButtonModule } from 'primeng/button';
import { AddCollaboratorsListComponent } from './components/add-collaborators-list/add-collaborators-list.component';
import { DropdownModule } from 'primeng/dropdown';
import { ProjectSettingsComponent } from '../project/components/project-settings/project-settings.component';

@NgModule({
    declarations: [
        AddCollaboratorsComponent,
        AddCollaboratorsListComponent
    ],
    imports: [
        CommonModule,
        FormsModule,
        DropdownModule,
        AutoCompleteModule,
        ProgressSpinnerModule,
        ButtonModule
    ],
    exports:[
        AddCollaboratorsListComponent
    ],
    providers:[
        ProjectSettingsComponent
    ]
})
export class CollaboratorModule { }
