import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { DynamicDialogRef, DynamicDialogConfig, MenuItem } from 'primeng/api';
import { TerminalService } from 'primeng/components/terminal/terminalservice';
import { Subscribable, Subscription } from 'rxjs';

@Component({
  selector: 'app-run-input',
  templateUrl: './run-input.component.html',
  styleUrls: ['./run-input.component.sass']
})
export class RunInputComponent implements OnDestroy, OnInit {

    @Input() 
    public inputItems: string[];
    public request: string;
    public firstInputMessage: string;
    public subscription: Subscription;
    public inputResult:string[]=[];
    public count=0;


    constructor(private terminalService: TerminalService) {
        this.terminalService.commandHandler.subscribe(command => {
            this.inputResult.push(command);
            this.count++;
            console.log(this.inputResult);
            if(this.inputItems[this.count])
            {
                this.terminalService.sendResponse(`Enter ${this.inputItems[this.count]}:`);
            }
        });
        }

        ngOnInit()
        {
            this.firstInputMessage=`Enter ${this.inputItems[0]}: `;
        }

        ngOnDestroy(){
            if (this.subscription) {
                this.subscription.unsubscribe();
            }
        }
}
