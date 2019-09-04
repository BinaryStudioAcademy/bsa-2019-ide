import { Injectable } from '@angular/core';
import { start } from 'repl';

@Injectable({
  providedIn: 'root'
})
export class ErrorHandlerService {

    constructor() { }
    
    private getException(error: string) {
        if(error === undefined) 
            return;
        let index = error.indexOf('<div class="titleerror">') + '<div class="titleerror">'.length;
        if(index === -1)
            return 'Server is off';
        let lastIndex = error.indexOf('</div>', index);
        return error.substring(index, lastIndex);
    }

    public getExceptionMessage(error: any) {
        if (error.status !== 500)
            return 'Server is off'
        let exception = this.getException(error.error);
        let startIndex = exception.indexOf(':') + 2;
        if(startIndex === -1)
            return 'Server is off';
        return exception.substr(startIndex);
    }
}
