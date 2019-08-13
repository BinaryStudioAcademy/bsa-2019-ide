import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WorkspaceRootComponent } from './workspace-root/workspace-root.component';
import { WorkspaceRoutingModule } from './workspace-routing.module';
import { FileBrowserSectionComponent } from './file-browser-section/file-browser-section.component';
import { EditorSectionComponent } from './editor-section/editor-section.component';
import { GeneralModule } from 'src/app/general/general.module';
import { ButtonModule } from 'primeng/button';
import {TreeModule} from 'primeng/tree';
import {MonacoEditorModule} from '@materia-ui/ngx-monaco-editor';
import { FormsModule } from '@angular/forms';
import {TabMenuModule} from 'primeng/tabmenu';
import { MenuModule } from 'primeng/menu';
import { ContextMenuModule } from 'primeng/components/contextmenu/contextmenu';


@NgModule({
  declarations: [WorkspaceRootComponent, FileBrowserSectionComponent, EditorSectionComponent],
  imports: [
    CommonModule,
    WorkspaceRoutingModule,
    GeneralModule,
    ButtonModule,
    TreeModule,
    MonacoEditorModule,
    FormsModule,
    TabMenuModule,
    MenuModule,
    ContextMenuModule
  ]
})
export class WorkspaceModule { }
