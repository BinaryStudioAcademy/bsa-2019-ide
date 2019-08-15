import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ConfirmationDialogComponent } from './confirmation-dialog/confirmation-dialog.component';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ConfirmationService } from 'primeng/api';
import { ProjectTypeDirective } from 'src/app/directives/projectType/project-type.directive';
import { LanguageDirective } from 'src/app/directives/language/language.directive';
import { CompilerTypeDirective } from 'src/app/directives/compilerType/compiler-type.directive';

@NgModule({
    declarations: [
        ConfirmationDialogComponent,
        ProjectTypeDirective,
        LanguageDirective,
        CompilerTypeDirective,
    ],
    imports: [
        CommonModule,
        ConfirmDialogModule
    ],
    exports: [
        ConfirmationDialogComponent,
        ProjectTypeDirective,
        LanguageDirective,
        CompilerTypeDirective
    ],
    providers: [
        ConfirmationService
    ]
})
export class SharedModule { }
