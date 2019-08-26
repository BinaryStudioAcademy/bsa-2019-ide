import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EditorSettingsComponent } from './components/editor-settings/editor-settings.component';
import { DropdownModule, ProgressSpinnerModule, ButtonModule } from 'primeng/primeng';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DynamicDialogModule } from 'primeng/components/dynamicdialog/dynamicdialog';
import { SharedModule } from '../shared/shared.module';



@NgModule({
  declarations: [
      EditorSettingsComponent
    ],
  imports: [
    CommonModule,
    DropdownModule,
    FormsModule,
    ReactiveFormsModule,
    ProgressSpinnerModule,
    ButtonModule,
    DynamicDialogModule,
    SharedModule
  ],
  exports:[
      EditorSettingsComponent
  ]
})
export class EditorModule { }
