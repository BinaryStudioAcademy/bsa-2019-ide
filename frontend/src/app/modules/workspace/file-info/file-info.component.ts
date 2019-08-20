import { Component, OnInit } from '@angular/core';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/api';
import { FileService } from 'src/app/services/file.service/file.service';

@Component({
    selector: 'app-file-info',
    templateUrl: './file-info.component.html',
    styleUrls: ['./file-info.component.sass']
})
export class FileInfoComponent implements OnInit {

    public type: string;
    public path: string=""
    public countOfFolders: number=0;
    public countOfFiles: number=0;
    public createAt;

    constructor(private config: DynamicDialogConfig,
        private ref: DynamicDialogRef) {

    }

    ngOnInit() {
        this.getItemPath();
        this.type = this.config.data.node.type
        this.getCountOfInternalItem(this.config.data.node);
    }

    public close(): void {
        this.ref.close();
    }

    public getItemPath(): void {
        var item = this.config.data.node;
        while (item) {
            this.path=item.label+'/'+this.path;
            item = item.parent;
        }
    }

    public getCountOfInternalItem(item: any) {
        item.children.forEach(element => {
            console.log(element);
            if(element.type==0)
            {
                this.countOfFolders++;
                this.getCountOfInternalItem(element);
            }
            else{
                this.countOfFiles++;
            }
        });
    }
}
