import { LeavePageDialogService } from './../../../services/leave-page-dialog.service';
import { FileUpdateDTO } from './../../../models/DTO/File/fileUpdateDTO';
import { WorkspaceService } from './../../../services/workspace.service';

import { Component, OnInit, ViewChild } from '@angular/core';
import { ResizeEvent } from 'angular-resizable-element';
import { ToastrService } from 'ngx-toastr';
import { EditorSectionComponent } from '../editor-section/editor-section.component';
import { Observable, of } from 'rxjs';
import { switchMap} from 'rxjs/internal/operators/switchMap';
import { map } from 'rxjs/internal/operators/map';




@Component({
    selector: 'app-workspace-root',
    templateUrl: './workspace-root.component.html',
    styleUrls: ['./workspace-root.component.sass']
})
export class WorkspaceRootComponent implements OnInit {
    @ViewChild(EditorSectionComponent, { static: false })
    private editor: EditorSectionComponent;

    constructor(
        private tr: ToastrService,
        private ws: WorkspaceService,
        private saveOnExit: LeavePageDialogService) { }

    ngOnInit() {
    }

    public onFileSelected(fileId) {
        this.tr.success(`fileId ${fileId}`, 'Success');
        console.log(this.editor.code = "bebebe");
    }

    public saveFiles() {
        const openedFiles = this.editor.openedFiles;
        return this.saveFilesRequest(openedFiles);
    }

    public onFilesSave(ev) {
        this.saveFilesRequest(ev).subscribe(success => this.tr.success("Files Saved"), error => this.tr.error("Can't save files"));
    }

    private saveFilesRequest(files: FileUpdateDTO[]) {
        return this.ws.saveFilesRequest(files);
    }

    canDeactivate(): Observable<boolean> {

        return this.saveOnExit.confirm('Save changes?')
        .pipe(
            switchMap(
                mustSave => mustSave ? this.saveFiles().pipe(map(result => result.ok ?  true :  false)) : of(false)));
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
