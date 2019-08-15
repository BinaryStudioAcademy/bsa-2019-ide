import { LeavePageDialogService } from './../../../services/leave-page-dialog.service';
import { FileUpdateDTO } from './../../../models/DTO/File/fileUpdateDTO';
import { WorkspaceService } from './../../../services/workspace.service';

import { Component, OnInit, ViewChild } from '@angular/core';
import { ResizeEvent } from 'angular-resizable-element';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { EditorSectionComponent } from '../editor-section/editor-section.component';
import { Observable, of } from 'rxjs';
import { switchMap } from 'rxjs/internal/operators/switchMap';
import { map } from 'rxjs/internal/operators/map';
import { FileService } from 'src/app/services/file.service/file.service';
import { MenuItem } from 'primeng/api';


@Component({
    selector: 'app-workspace-root',
    templateUrl: './workspace-root.component.html',
    styleUrls: ['./workspace-root.component.sass']
})
export class WorkspaceRootComponent implements OnInit {
    public projectId: number;
    public openedFiles: FileUpdateDTO[];
    public items: MenuItem[];
    public activeItem: MenuItem;
    
    
    @ViewChild(EditorSectionComponent, { static: false })
    private editor: EditorSectionComponent;

    constructor(
        private route: ActivatedRoute,
        private tr: ToastrService,
        private ws: WorkspaceService,
        private saveOnExit: LeavePageDialogService,
        private fileService: FileService) { }

    ngOnInit() {
        this.projectId = Number(this.route.snapshot.paramMap.get('id'));
        if (!this.projectId) {
            console.error('Id in URL is not a number!');
            return;
        }

        this.openedFiles = [
            { id: '1', folder: 'Project', name: 'Main.cs', content: 'Hello World', updaterId: 0 }
        ]

        this.items = [
            { label: this.openedFiles[0].name, icon: 'fa fa-fw fa-file' }
        ];

        this.activeItem = this.items[this.items.length - 1];

    }

    public onFileSelected(fileId: string): void {
        if (!!this.openedFiles.find(f => f.id === fileId)){
            this.activeItem = this.items.find(i => i.target === fileId);
            this.editor.code = this.openedFiles.find(f => f.id === fileId).content;
            return;
        }

        this.fileService.getProjectById(fileId)
            .subscribe(
                (resp) => {
                    this.openedFiles.push(resp.body as FileUpdateDTO);
                    this.items.push({label: resp.body.name, icon: 'fa fa-fw fa-file', target: resp.body.id})
                    this.activeItem = this.items[this.items.length - 1];
                    this.editor.code = resp.body.content;
                },
                (error) => {
                    this.tr.error("Can't load selected file.", "Error Message");
                    console.error(error.message);
                }
            );
    }

    public saveFiles() {        
        const openedFiles = this.editor.openedFiles;
        return this.saveFilesRequest(openedFiles);
    }

    public onSaveButtonClick(ev) {
        this.saveFiles().subscribe(
            success => {
                if (success.ok) {
                    this.tr.success("Files saved", "Success", { tapToDismiss: true })
                } else {
                    this.tr.error("Can't save files", "Error", { tapToDismiss: true });
                }

            },
            error => this.tr.error("Can't save files", "Error", { tapToDismiss: true }));
    }

    public onFilesSave(ev) {


        this.saveFilesRequest(ev).subscribe(
            success => {
                if (success.ok) {
                    this.tr.success("Files saved", "Success", { tapToDismiss: true })
                } else {
                    this.tr.error("Can't save files", "Error", { tapToDismiss: true });
                }
            },
            error => this.tr.error("Can't save files", "Error", { tapToDismiss: true }));
    }

    public onFileClose(ev: FileUpdateDTO) {
        const indexFile = this.openedFiles.findIndex(f => f.id === ev.id);
        this.openedFiles.splice(indexFile, 1);
        const indexTab = this.items.findIndex(i => i.target === ev.id);
        this.items.splice(indexTab, 1);
    }

    private saveFilesRequest(files: FileUpdateDTO[]) {
        return this.ws.saveFilesRequest(files);
    }

    canDeactivate(): Observable<boolean> {

        return this.saveOnExit.confirm('Save changes?')
            .pipe(
                switchMap(
                    mustSave => mustSave ? this.saveFiles().pipe(map(result => result.ok ? true : false)) : of(false)));
    }

    // *********code below for resizing blocks***************
    //   public style: object = {};

    //   validate(event: ResizeEvent): boolean {
    //     const MIN_DIMENSIONS_PX: number = 50;
    //     if (
    //       event.rectangle.width &&
    //       event.rectangle.height &&
    //       (event.rectangle.width < MIN_DIMENSIONS_PX ||
    //         event.rectangle.height < MIN_DIMENSIONS_PX)
    //     ) {
    //       return false;
    //     }
    //     return true;
    //   }

    //   onResizeEnd(event: ResizeEvent): void {
    //     this.style = {
    //       position: 'fixed',
    //       left: `${event.rectangle.left}px`,
    //       top: `${event.rectangle.top}px`,
    //       width: `${event.rectangle.width}px`,
    //       height: `${event.rectangle.height}px`
    //     };
    // }
}
