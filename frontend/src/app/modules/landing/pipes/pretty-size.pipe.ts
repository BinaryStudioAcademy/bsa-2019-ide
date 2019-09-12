import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'prettySize'
})
export class PrettySizePipe implements PipeTransform {

  transform(value: number, ...args: any[]): any {
    if (value === 0) return '0 Bytes';

    const k = 1024;
    const sizes = ['Bytes', 'KB', 'MB', 'GB', 'TB', 'PB', 'EB', 'ZB', 'YB'];

    const i = Math.floor(Math.log(value) / Math.log(k));

    return parseFloat((value / Math.pow(k, i)).toFixed(0)) + ' ' + sizes[i];
  }
}
