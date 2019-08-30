
import { Directive, ElementRef, Input, OnInit, Renderer2 } from '@angular/core';
import { EventService } from '../services/event.service/event.service';

@Directive({
    selector: '[appHighlightMatch]'
})
export class HighlightMatchDirective implements OnInit {
    @Input('appHighlightMatch') queryString: string;

    constructor(private el: ElementRef, private renderer: Renderer2, ) { }

    ngOnInit() {
        this.highlightAfterTimeOut(0);
        
    }

    highlightAfterTimeOut(time) {
        setTimeout(() => {
            if(!this.queryString){
                return;
            }
            const escapedQuery = this.queryString.replace(/[.*+?^${}()|[\]\\]/g, '\\$&');
            this.el.nativeElement.innerHTML
            this.renderer.setProperty(
                this.el.nativeElement,
                'innerHTML',
                this.el.nativeElement.innerHTML.replace(
                    new RegExp(escapedQuery, 'gi'),
                    `<mark>$&</mark>`));
        }, time);
    }
}
