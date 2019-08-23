import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthDialogComponent } from './components/auth-dialog/auth-dialog.component';
import { FormsModule } from '@angular/forms';
import { DynamicDialogModule } from 'primeng/components/dynamicdialog/dynamicdialog';
import {ProgressSpinnerModule} from 'primeng/progressspinner';
import { NavMenuComponent } from 'src/app/nav-menu/nav-menu.component';
@NgModule({
  declarations: [
    AuthDialogComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    DynamicDialogModule,
    ProgressSpinnerModule
  ],
  entryComponents:[
    AuthDialogComponent
  ]
})
export class AuthorizationModule { }
