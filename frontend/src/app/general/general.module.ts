import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ResizableModule } from 'angular-resizable-element';
import { ProjectWindowComponent } from '../modules/project/components/project-window/project-window.component';
import { ProgressSpinnerModule } from 'primeng/primeng';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    
  ],
  exports: [
    ResizableModule,
    
  ]
})
export class GeneralModule { }
