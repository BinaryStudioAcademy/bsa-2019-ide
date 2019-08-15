import { Directive, Input, ElementRef, OnInit } from '@angular/core';

@Directive({
  selector: '[appCompilerType]'
})
export class CompilerTypeDirective implements OnInit{

    @Input() compilerType: number;

    constructor(private elementRef: ElementRef)  {
        
    }

    ngOnInit(){
        this.highlight(this.compilerType, this.elementRef);
    }

    private highlight(compilerType: number, el:ElementRef) {
        switch (compilerType) {
          case 0:
            this.elementRef.nativeElement.innerHTML = 'CoreCLR';
            break;
          case 1: 
            this.elementRef.nativeElement.innerHTML = 'Roslyn';
            break;
          case 2:
            this.elementRef.nativeElement.innerHTML = 'V8'; 
            break;
          case 3:    
            this.elementRef.nativeElement.innerHTML = 'Gc';
            break;
        }
    }
}
