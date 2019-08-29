import { Component, OnInit } from '@angular/core';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/api';
import { ToastrService } from 'ngx-toastr';
import { FileBrowserService } from 'src/app/services/file-browser.service';
import { ImportProjectDTO } from 'src/app/models/DTO/Workspace/importProjectDTO';
import { ProjectStructureService } from 'src/app/services/project-structure/project-structure.service';

@Component({
  selector: 'app-import-file',
  templateUrl: './import-file.component.html',
  styleUrls: ['./import-file.component.sass']
})
export class ImportFileComponent implements OnInit {

    uploadedFiles: any[] = [];
    public fileInfoData;
    fileId: string;
    projectStrId: string;
    hasDetailsSaveResponse = true;
    importProjectDto: ImportProjectDTO;
    listOfParents: string[] = [];

    constructor(
        private config: DynamicDialogConfig,
        private ref: DynamicDialogRef,
        private toastr: ToastrService,
        private projectStructure: ProjectStructureService) {
    }

    ngOnInit() {
        this.fileInfoData=this.config.data;
        this.projectStrId = this.fileInfoData.projectId;
        this.fileId = this.fileInfoData.node.key;

        var tempNode = this.fileInfoData.node;
                   
        while(tempNode !== undefined){
            this.listOfParents.push(tempNode.key);
            tempNode = tempNode.parent==undefined ? undefined : tempNode.parent;
        }

        this.listOfParents.reverse();
        console.log(this.listOfParents);
        if(this.fileInfoData.parent === undefined)
            console.log('Its root folder');

    }

    public close() {
        this.ref.close();
    }

    public Uploader(event): void {  
        if(event.files.length == 0){
        console.log('No file selected.');
        return;
        }

        this.hasDetailsSaveResponse = false;
        var fileToUpload = event.files[0];

        const formData = new FormData();

        formData.append("projectStructureId", this.projectStrId);
        formData.append("fileStructureId", this.fileId);
        formData.append('parentNodeIds', JSON.stringify(this.listOfParents));
        formData.append("file", fileToUpload);                

        this.projectStructure.importFile(formData)
            .subscribe(response =>{
                this.toastr.success('File uploaded successfully');
                this.hasDetailsSaveResponse = true;
                this.close();
    
            }, error =>{
                this.toastr.error("Can`t upload file");
                this.hasDetailsSaveResponse = true;
            });
    }

    public onError(event): void {
        this.toastr.error(event);
    }
}