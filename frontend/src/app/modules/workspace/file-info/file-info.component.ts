import { Component, OnInit } from '@angular/core';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/api';
import { FileService } from 'src/app/services/file.service/file.service';
import { FileBrowserService } from 'src/app/services/file-browser.service';

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
    public name: string;
    public fileInfoData;
    public size: number;
    public projectId: number;

    constructor(private config: DynamicDialogConfig,
        private fileBrowserService: FileBrowserService,
        private ref: DynamicDialogRef) {

    }

    ngOnInit() {
        this.fileInfoData=this.config.data;
        this.name=this.fileInfoData.node.label;
        this.getItemPath();
        this.type = this.fileInfoData.node.type
        if(this.fileInfoData.node.children)
        {
            this.getCountOfInternalItem(this.fileInfoData.node);
        }
        this.fileBrowserService.getFileStructureSize(this.fileInfoData.projectId,this.fileInfoData.node.key).subscribe(
            (resp)=>
            {
                this.size=resp.body;
            }
        )
    }

    public close(): void {
        this.ref.close();
    }

    public IsFilder(): boolean{
        return this.type=="1";
    }

    public getItemPath(): void {
        var item = this.fileInfoData.node;
        while (item) {
            this.path=item.label+'/'+this.path;
            item = item.parent;
        }
    }

    public getCountOfInternalItem(item: any): void {
        item.children.forEach(element => {
            if(element.type==0)
            {
                this.countOfFolders++;
                if (element.children)
                {
                    this.getCountOfInternalItem(element);
                }
            }
            else{
                this.countOfFiles++;
            }
        });
    }
}
