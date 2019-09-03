import { Component, OnInit } from '@angular/core';
import { DynamicDialogRef, DynamicDialogConfig, MenuItem } from 'primeng/api';

@Component({
  selector: 'app-run-input',
  templateUrl: './run-input.component.html',
  styleUrls: ['./run-input.component.sass']
})
export class RunInputComponent implements OnInit {

    public items: any[]=[];
    constructor(private config: DynamicDialogConfig,
        private ref: DynamicDialogRef) {
        }

  ngOnInit() {
      this.config.data.input.forEach(element=>{
      this.items.push(
              {'label':element, 'value': ""}
          )
      })
  }

  public OnClick(myForm) {
    console.log(myForm.form.value.inputs);
    this.ref.close();
  }

  public close(){
      this.ref.close();
  }
}
