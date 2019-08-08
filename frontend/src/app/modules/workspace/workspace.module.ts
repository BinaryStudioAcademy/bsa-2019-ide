import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WorkspaceRootComponent } from './workspace-root/workspace-root.component';
import { WorkspaceRoutingModule } from './workspace-routing.module';
import { FileBrowserSectionComponent } from './file-browser-section/file-browser-section.component';
import { EditorSectionComponent } from './editor-section/editor-section.component';

@NgModule({
  declarations: [WorkspaceRootComponent, FileBrowserSectionComponent, EditorSectionComponent],
  imports: [
    CommonModule,
    WorkspaceRoutingModule
  ]
})
export class WorkspaceModule { }
