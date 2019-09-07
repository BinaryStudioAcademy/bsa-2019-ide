import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GitWindowComponent } from './components/git-window/git-window.component';
import { GitCredentialsComponent } from './components/git-credentials/git-credentials.component';
import { DropdownModule } from 'primeng/dropdown';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MenuModule } from 'primeng/menu';
import { ButtonModule } from 'primeng/button';
import { ProgressSpinnerModule } from 'primeng/progressspinner';
import { DialogModule } from 'primeng/dialog';
import { SlideMenuModule } from 'primeng/slidemenu';
import { KeyFilterModule, InputTextModule } from 'primeng/primeng';


@NgModule({
  declarations: [GitWindowComponent, GitCredentialsComponent],
  imports: [
    CommonModule,
    DropdownModule,
    FormsModule,
    MenuModule,
    ButtonModule,
    InputTextModule,
    KeyFilterModule,
    DialogModule,
    SlideMenuModule,
    ReactiveFormsModule,
    ProgressSpinnerModule
  ],
  exports: [
    GitWindowComponent,
    GitCredentialsComponent
  ],
  entryComponents: [
    GitWindowComponent
  ],
})
export class GitModule { }
