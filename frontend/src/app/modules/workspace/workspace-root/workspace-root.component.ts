import { LeavePageDialogService } from './../../../services/leave-page-dialog.service';
import { FileUpdateDTO } from './../../../models/DTO/File/fileUpdateDTO';
import { WorkspaceService } from './../../../services/workspace.service';

import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { EditorSectionComponent } from '../editor-section/editor-section.component';
import { Observable, of } from 'rxjs';
import { switchMap } from 'rxjs/internal/operators/switchMap';
import { map } from 'rxjs/internal/operators/map';

import { HttpResponse } from '@angular/common/http';
import { FileService } from 'src/app/services/file.service/file.service';
import { TokenService } from 'src/app/services/token.service/token.service';
import { ProjectDialogService } from 'src/app/services/proj-dialog.service/project-dialog.service';
import { ProjectType } from '../../project/models/project-type';
import { FileBrowserSectionComponent } from '../file-browser-section/file-browser-section.component';


// FOR REFACTOR
// last and facultative superior wish - to review and rearrange duties of editor-section, workspace-root, file-browser and links between them

@Component({
    selector: 'app-workspace-root',
    templateUrl: './workspace-root.component.html',
    styleUrls: ['./workspace-root.component.sass']
})
export class WorkspaceRootComponent implements OnInit {
    public projectId: number;
    public userId: number;
    public showFileBrowser=true;
    public large=false;

    @ViewChild(EditorSectionComponent, { static: false })
    private editor: EditorSectionComponent;

    @ViewChild('fileBrowser', {static: false})
    private fileBrowser: FileBrowserSectionComponent;
    
    constructor(
        private route: ActivatedRoute,
        private tr: ToastrService,
        private ws: WorkspaceService,
        private saveOnExit: LeavePageDialogService,
        private tokenService: TokenService,
        private fileService: FileService,
        private projectEditService: ProjectDialogService) { }

    ngOnInit() {
        this.projectId = Number(this.route.snapshot.paramMap.get('id'));
        this.userId = this.tokenService.getUserId();
    }

    public onFileSelected(fileId: string): void {
        if (this.editor.openedFiles.some(f => f.innerFile.id === fileId)) {
            this.editor.activeItem = this.editor.items.find(i => i.id === fileId);
            this.editor.code = this.editor.openedFiles.find(f => f.innerFile.id === fileId).innerFile.content;
            return;
        }

        this.ws.getFileById(fileId)
            .subscribe(
                (resp) => {
                    if (resp.ok) {
                        this.editor.AddFileToOpened(resp.body as FileUpdateDTO);
                        this.editor.items.push({ label: resp.body.name, icon: 'fa fa-fw fa-file', id: resp.body.id });
                        this.editor.activeItem = this.editor.items[this.editor.items.length - 1];
                        this.editor.code = resp.body.content;
                    } else {
                        this.tr.error("Can't load selected file.", 'Error Message');
                    }
                },
                (error) => {
                    this.tr.error("Can't load selected file.", 'Error Message');
                    console.error(error.message);
                }
            );
    }
   
    // FOR REFACTOR
    // onSaveButtonClick and onFilesSave do same things - need to create one method Save and calls it for this actions(save btn, tab close)
    // firsty BETTER to have method for save one file its more logical. And add than save all method. And for close tab use saveOne method!!!
    // this one calls on save btn click
    public onSaveButtonClick(ev) {
        if (!this.editor.anyFileChanged()) {
            return;
        }
        this.saveFiles().subscribe(
            (success) => {
                if (success.every(x => x.ok)) {
                    this.tr.success("Files saved", 'Success', { tapToDismiss: true });
                } else {
                    this.tr.error("Can't save files", 'Error', { tapToDismiss: true });
                }
            },
            (error) => {
                this.tr.error("Can't save files", 'Error', { tapToDismiss: true });
                console.error(error);
            }
        );
    }
    // this one calls on tab close
    public onFilesSave(files: FileUpdateDTO[]) {

        this.saveFilesRequest(files)
            .subscribe(
                success => {
                    if (success.every(x => x.ok)) {
                        this.tr.success("Files saved", 'Success', { tapToDismiss: true });
                        // FOR REFACTOR
                        // "confirmSaving" method invert isChanged flag, 
                        // but here in calls for closed tab, so it calls for undefind obj so it throw exeption
                        // refactor it for call only for opened files and mabe rename it
                        // this.editor.confirmSaving(files.map(x => x.id));
                    } else {
                        this.tr.error("Can't save files", 'Error', { tapToDismiss: true });
                    }
                },
                error => { console.log(error); this.tr.error("Error: can't save files", 'Error', { tapToDismiss: true }) });
    }
    // FOR REFACTOR
  
    public hideFileBrowser(): void
    {
        this.showFileBrowser= !this.showFileBrowser;
    }

    public expand(){
        this.fileBrowser.expandAll();
    }

    public collapse(){
        this.fileBrowser.collapseAll();        
    }

    public editProjectSettings() {
        this.projectEditService.show(ProjectType.Update, this.projectId);
    }

    // FOR REFACTOR
    // saveFilesRequest and saveFiles do the same refactor for one method
    // this one calls on save btn click
    private saveFilesRequest(files: FileUpdateDTO[]): Observable<HttpResponse<FileUpdateDTO>[]> {
        return this.ws.saveFilesRequest(files);
    }
    // this one calls on tab close
    public saveFiles(): Observable<HttpResponse<FileUpdateDTO>[]> {
        const openedFiles: FileUpdateDTO[] = this.editor.openedFiles.map(x => x.innerFile);

        return this.saveFilesRequest(openedFiles);
    }
    // FOR REFACTOR

    canDeactivate(): Observable<boolean> {
        return !this.editor.anyFileChanged() ? of(true) : this.saveOnExit.confirm('Save changes?')
            .pipe(
                switchMap(
                    mustSave => mustSave ? this.saveFiles().pipe(map(result => result.every(x => x.ok) ? true : false)) : of(false)));
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
