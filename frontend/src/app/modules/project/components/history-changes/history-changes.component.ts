import { Component, OnInit, Input } from '@angular/core';
import { FileHistoryService } from 'src/app/services/file-history.service/file-history.service';
import { FileShownHistoryDTO } from 'src/app/models/DTO/File/fileShownHistoryDTO';

@Component({
  selector: 'app-history-changes',
  templateUrl: './history-changes.component.html',
  styleUrls: ['./history-changes.component.sass']
})
export class HistoryChangesComponent implements OnInit {
    @Input() projectId: number;
    public personNickname: string;
    public fileChangesList: FileShownHistoryDTO[];

    constructor(private fileHistoryService: FileHistoryService) { }

    ngOnInit() {
        this.fileHistoryService.getHistoriesForProject(this.projectId).subscribe(
            (response) => {
                this.fileChangesList = response.body;
            },
            (error) => {
                console.log('---> There was an error while getting project histories');
                console.log(error);
            }
        )
    }

    public isEmpty = string => (!string || !string.length);
}
