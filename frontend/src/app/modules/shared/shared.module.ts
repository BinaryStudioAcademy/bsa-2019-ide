import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ConfirmationDialogComponent } from './confirmation-dialog/confirmation-dialog.component';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ConfirmationService } from 'primeng/api';
import { ProjectTypeDirective } from 'src/app/directives/projectType/project-type.directive';
import { LanguageDirective } from 'src/app/directives/language/language.directive';
import { CompilerTypeDirective } from 'src/app/directives/compilerType/compiler-type.directive';
import { ProviderDirective } from 'src/app/directives/credentials/provider.directive';
import { LessSymbolsPipe } from './pipes/less-symbols.pipe';
import { FooterComponent } from './footer/footer.component';
import { UserAccessDirective } from 'src/app/directives/userAccess/user-access.directive';

@NgModule({
    declarations: [
        ConfirmationDialogComponent,
        ProjectTypeDirective,
        LanguageDirective,
        CompilerTypeDirective,
        ProviderDirective,
        LessSymbolsPipe,
        FooterComponent,
        UserAccessDirective
    ],
    imports: [
        CommonModule,
        ConfirmDialogModule
    ],
    exports: [
        ConfirmationDialogComponent,
        ProjectTypeDirective,
        LanguageDirective,
        CompilerTypeDirective,
        ProviderDirective,
        LessSymbolsPipe,
        FooterComponent
    ],
    providers: [
        ConfirmationService
    ]
})
export class SharedModule { }
