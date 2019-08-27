import { Component, OnInit } from '@angular/core';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/api';
import { InfoService } from 'src/app/services/info.service/info.service';

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
        private infoService: InfoService,
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
        console.log(this.fileInfoData);
        this.infoService.getFileStructureSize(this.fileInfoData.projectId,this.fileInfoData.node.key).subscribe(
            (resp)=>
            {
                this.size=resp.body;
            }
        )
    }

    public close(): void {
        this.ref.close();
    }

    public isFolder(): boolean{
        return this.type==="0";
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
