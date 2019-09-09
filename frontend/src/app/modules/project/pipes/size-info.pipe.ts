import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'sizeInfo'
})
export class SizeInfoPipe implements PipeTransform {
    transform(size, value) {
        if (size === 0) {
            return "The file did not change";
        }
        if (size > 0) {
            return `The file increased by ${size} kilobytes`;
        }
        return `The file decreased by ${-size} kilobytes`;
    }
}
