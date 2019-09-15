import { Directive, OnInit, Input, ElementRef } from '@angular/core';

@Directive({
  selector: '[appLanguage]'
})
export class LanguageDirective implements OnInit{

    @Input() language: number;

    constructor(private elementRef: ElementRef)  {
        
    }

    ngOnInit(){
        this.highlight(this.language, this.elementRef);
    }

    private highlight(language: number, el:ElementRef) {
        switch (language) {
          case 0:
            this.elementRef.nativeElement.innerHTML = 'C#';
            break;
          case 1: 
            this.elementRef.nativeElement.innerHTML = 'TypeScript';
            break;
          case 2:
            this.elementRef.nativeElement.innerHTML = 'JavaScript'; 
            break;
          case 3:    
            this.elementRef.nativeElement.innerHTML = 'Go';
            break;
        }
    }
}
