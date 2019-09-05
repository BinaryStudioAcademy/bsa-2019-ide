import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { DynamicDialogRef, DynamicDialogConfig, MenuItem } from 'primeng/api';
import { TerminalService } from 'primeng/components/terminal/terminalservice';
import { Subscribable, Subscription } from 'rxjs';
import { BuildService } from 'src/app/services/build.service';

@Component({
    selector: 'app-run-input',
    templateUrl: './run-input.component.html',
    styleUrls: ['./run-input.component.sass']
})
export class RunInputComponent implements OnDestroy, OnInit {

    @Input()
    public inputItems: string[];
    @Input()
    public connectionId: string;
    @Input()
    public projectId: number;
    public request: string;
    public firstInputMessage: string;
    public subscription: Subscription;
    public inputResult: string[] = [];
    public count = 0;


    constructor(private terminalService: TerminalService,
        private buildService: BuildService) {
        this.terminalService.commandHandler.subscribe(command => {
            this.inputResult.push(command);
            this.count++;
            console.log(this.inputResult);
            if (this.inputItems[this.count]) {
                this.terminalService.sendResponse(`Enter ${this.inputItems[this.count]}:`);
            }
            if (this.inputItems.length == this.inputResult.length) {
                this.buildService.runProjectWithInputs(this.projectId,this.connectionId, this.inputResult).subscribe(resp=>{});
                console.log("all items is entered "+ this.inputResult);
            }
        });
    }

    ngOnInit() {
        this.firstInputMessage = `Enter ${this.inputItems[0]}: `;
    }

    ngOnDestroy() {
        if (this.subscription) {
            this.subscription.unsubscribe();
        }
    }
}
