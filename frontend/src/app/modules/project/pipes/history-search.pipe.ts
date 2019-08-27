import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'historySearch'
})
export class HistorySearchPipe implements PipeTransform {

    transform(histories, value) {
        if (histories === undefined) {
            return histories;
        }
        return histories.filter(history => {
            if (value === undefined) {
                return true;
            }
            return history.creatorNickname.toLowerCase().includes(value.toLowerCase()) || history.fileName.toLowerCase().includes(value.toLowerCase());
        });
    }

}
