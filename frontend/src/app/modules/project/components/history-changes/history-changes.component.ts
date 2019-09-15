import { Component, OnInit, Input, ViewEncapsulation } from '@angular/core';
import { FileHistoryService } from 'src/app/services/file-history.service/file-history.service';
import { FileHistoryListDTO } from 'src/app/models/DTO/File/fileHistoryListDTO';

@Component({
  selector: 'app-history-changes',
  styleUrls: ['./history-changes.component.sass'],
  templateUrl: './history-changes.component.html',
  encapsulation: ViewEncapsulation.None,
})
export class HistoryChangesComponent implements OnInit {
    @Input() projectId: number;
    public personNickname: string;
    public fileChangesList: FileHistoryListDTO[];

    constructor(private fileHistoryService: FileHistoryService) {
    }

    ngOnInit() {
        this.fileHistoryService.getHistoriesForProject(this.projectId).subscribe(
            (response) => {
                console.log(response.body);
                this.fileChangesList = response.body;
            },
            (error) => {
                console.log('---> There was an error while getting project histories', error);
            }
        )
    }

    public isEmpty = string => (!string || !string.length);
}
