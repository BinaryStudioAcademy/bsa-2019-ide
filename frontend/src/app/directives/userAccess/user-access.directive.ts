import { Directive, ElementRef, OnInit, Input } from '@angular/core';


@Directive({
    selector: '[appUserAccess]'
})
export class UserAccessDirective implements OnInit {

    @Input() userAccess: number;

    constructor(private elementRef: ElementRef) { }

    ngOnInit() {
        this.highlight(this.userAccess, this.elementRef);
    }

    private highlight(userAccess: number, el: ElementRef) {
        switch (userAccess) {
            case 0:
                this.elementRef.nativeElement.innerHTML = 'Can read';
                break;
            case 1:
                this.elementRef.nativeElement.innerHTML = 'Can write';
                break;
            case 2:
                this.elementRef.nativeElement.innerHTML = 'Can build';
                break;
            case 3:
                this.elementRef.nativeElement.innerHTML = 'Can run';
                break;
        }
    }

}
