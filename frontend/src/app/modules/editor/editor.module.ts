import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EditorSettingsComponent } from './components/editor-settings/editor-settings.component';
import { DropdownModule, ProgressSpinnerModule, ButtonModule } from 'primeng/primeng';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



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
    ButtonModule
  ],
  exports:[
      EditorSettingsComponent
  ]
})
export class EditorModule { }
