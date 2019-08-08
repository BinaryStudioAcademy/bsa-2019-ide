import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthDialogComponent } from './components/auth-dialog/auth-dialog.component';
import { FormsModule } from '@angular/forms';
import { DynamicDialogModule } from 'primeng/components/dynamicdialog/dynamicdialog';

@NgModule({
  declarations: [
    AuthDialogComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    DynamicDialogModule
  ],
  entryComponents:[
    AuthDialogComponent
  ]
})
export class AuthorizationModule { }
