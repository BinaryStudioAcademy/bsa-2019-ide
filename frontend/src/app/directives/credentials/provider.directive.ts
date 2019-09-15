import { Directive, ElementRef, Input } from '@angular/core';

@Directive({
  selector: '[appProvider]'
})
export class ProviderDirective {

    @Input() provider: number;

    constructor(private elementRef: ElementRef)  {
        
    }

    ngOnInit(){
        this.highlight(this.provider, this.elementRef);
    }

    private highlight(provider: number, el:ElementRef) {
        switch (provider) {
          case 0:
            this.elementRef.nativeElement.innerHTML = 'GitHub';
            break;
          case 1: 
            this.elementRef.nativeElement.innerHTML = 'Bitbucket';
            break;
          case 2:
            this.elementRef.nativeElement.innerHTML = 'Gitlab'; 
            break;
        }
    }
}

