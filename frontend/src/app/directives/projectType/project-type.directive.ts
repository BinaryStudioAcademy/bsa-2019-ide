import { Directive, ElementRef, OnInit, Input } from '@angular/core';

@Directive({
  selector: '[appProjectType]'
})

export class ProjectTypeDirective  implements OnInit{

    @Input() projectType: number;

    constructor(private elementRef: ElementRef)  {
        
    }

    ngOnInit(){
        this.highlight(this.projectType, this.elementRef);
    }

    private highlight(projectType: number, el:ElementRef) {
        switch (projectType) {
          case 0:
            this.elementRef.nativeElement.innerHTML = 'Console App';
            break;
          case 1: 
            this.elementRef.nativeElement.innerHTML = 'Web App';
            break;
          case 2:
            this.elementRef.nativeElement.innerHTML = 'Library'; 
            break;
        }
    }
}
