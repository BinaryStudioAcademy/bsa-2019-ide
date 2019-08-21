import { Injectable, Inject } from '@angular/core';
import { EventManager } from '@angular/platform-browser';
import { Observable } from 'rxjs';
import { DOCUMENT } from '@angular/common';

type Options = {
    element: any;
    keys: string;
}

@Injectable({
    providedIn: 'root'
})
export class HotkeyService {
    defaults: Partial<Options> = {
        element: this.document
    }

    constructor(private eventManager: EventManager,
        @Inject(DOCUMENT) private document: Document) {
    }

    public addShortcut(options: Partial<Options>) {
        const merged = { ...this.defaults, ...options };
        const event = `keydown.${merged.keys}`;

        return new Observable(observer => {
            const handler = (e) => {
                e.preventDefault()
                observer.next(e);
            };

            const dispose = this.eventManager.addEventListener(
                merged.element, event, handler
            );

            return () => {
                dispose();
            };
        })
    }
}
