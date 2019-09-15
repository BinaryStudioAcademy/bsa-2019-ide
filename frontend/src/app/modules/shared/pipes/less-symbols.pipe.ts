import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'lessSymbols'
})
export class LessSymbolsPipe implements PipeTransform {

    transform(value: string, count: number, ...args: any[]): string {
        if (!value) {
            return '';
        }
        return value.length > count + 1 ? value.substr(0, count - 3) + '...' : value;
    }

}
