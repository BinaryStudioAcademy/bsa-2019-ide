import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ConfirmationService } from 'primeng/api';

@Component({
  selector: 'app-confirmation-dialog',
  templateUrl: './confirmation-dialog.component.html',
  styleUrls: ['./confirmation-dialog.component.sass']
})
export class ConfirmationDialogComponent implements OnInit {
    @Input() buttonName: string;
    @Input() header: string;
    @Input() message: string;
    @Output() IsConfirmed = new EventEmitter<boolean>();

    constructor(private confirmationService: ConfirmationService) {}

    ngOnInit(): void {
    }

    confirm() {
        this.confirmationService.confirm({
            message: this.message,
            header: this.header,
            icon: 'pi pi-exclamation-triangle',
            accept: () => {
                this.IsConfirmed.emit(true);
            },
            reject: () => {
                this.IsConfirmed.emit(false);
            }
        });
    }
}
