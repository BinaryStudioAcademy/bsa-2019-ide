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
import { ContextMenuModule, MenuModule, FieldsetModule, CardModule, ScrollPanelModule, PanelModule, ProgressSpinnerModule, ConfirmDialogModule, TooltipModule,  TerminalModule, SpinnerModule } from 'primeng/primeng';
import { FileInfoComponent } from './file-info/file-info.component';
import {ProgressBarModule} from 'primeng/progressbar';
import {OrderListModule} from 'primeng/orderlist';
import { EditorSettingsComponent } from '../editor/components/editor-settings/editor-settings.component';
import { ImportFileComponent } from './import-file/import-file.component';
import {FileUploadModule} from 'primeng/fileupload';

import { GlobalSearchOutputComponent } from './global-search-output/global-search-output.component';
import { HighlightMatchDirective } from 'src/app/directives/highlight-match.directive';
import { ConsoleComponent } from './console/console.component';
import { RunInputComponent } from './run-input/run-input.component';
import { TerminalService } from 'primeng/components/terminal/terminalservice';
import {AccordionModule} from 'primeng/accordion';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [
      WorkspaceRootComponent,
      FileBrowserSectionComponent,
      EditorSectionComponent,
      FileInfoComponent,
      ImportFileComponent, GlobalSearchOutputComponent,HighlightMatchDirective,ConsoleComponent, RunInputComponent
    ],
  imports: [
    TerminalModule,
    MenuModule,
    ContextMenuModule,
    CommonModule,
    WorkspaceRoutingModule,
    GeneralModule,
    ButtonModule,
    TreeModule,
    MonacoEditorModule,
    FormsModule,
    TabMenuModule,
    MenuModule,
    ContextMenuModule,
    ProgressBarModule,
    OrderListModule,
    ProgressBarModule,
    FieldsetModule,
    CardModule,
    ScrollPanelModule,
    PanelModule,
    FileUploadModule,
    ProgressSpinnerModule,
    AccordionModule,
    SharedModule,
    ConfirmDialogModule,
    TooltipModule,
    ProgressSpinnerModule
  ],
  providers:[
      TerminalService
  ],
  entryComponents: [
      EditorSettingsComponent,
      ConsoleComponent,
      RunInputComponent
  ]
})
export class WorkspaceModule { }
