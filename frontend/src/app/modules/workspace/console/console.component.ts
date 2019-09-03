import { Component, OnInit } from '@angular/core';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/api';

@Component({
    selector: 'app-console',
    templateUrl: './console.component.html',
    styleUrls: ['./console.component.sass']
})
export class ConsoleComponent implements OnInit {

    public metadata: string;

    constructor(private config: DynamicDialogConfig,
        private ref: DynamicDialogRef) {

    }

    ngOnInit() {
        this.metadata = this.config.data.metadata;
    }

}
