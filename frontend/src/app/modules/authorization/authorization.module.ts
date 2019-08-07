import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthDialogComponent } from './components/auth-dialog/auth-dialog.component';
import { FormsModule } from '@angular/forms';
import { MatButtonModule, MatFormFieldModule, MatInputModule, MatRippleModule, MatIconModule, MatDialogModule } from '@angular/material';

@NgModule({
  declarations: [
    AuthDialogComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatRippleModule,
    MatIconModule,
    MatDialogModule
  ],
  entryComponents:[
    AuthDialogComponent
  ]
})
export class AuthorizationModule { }
