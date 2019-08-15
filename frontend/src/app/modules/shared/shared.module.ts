import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ConfirmationDialogComponent } from './confirmation-dialog/confirmation-dialog.component';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ConfirmationService } from 'primeng/api';


@NgModule({
    declarations: [
        ConfirmationDialogComponent
    ],
    imports: [
        CommonModule,
        ConfirmDialogModule
    ],
    exports: [
        ConfirmationDialogComponent
    ],
    providers: [
        ConfirmationService
    ]
})
export class SharedModule { }
