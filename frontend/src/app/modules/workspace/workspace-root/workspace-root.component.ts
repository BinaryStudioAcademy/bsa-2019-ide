import { LeavePageDialogService } from './../../../services/leave-page-dialog.service';
import { FileUpdateDTO } from './../../../models/DTO/File/fileUpdateDTO';
import { WorkspaceService } from './../../../services/workspace.service';

import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';
import { ResizeEvent } from 'angular-resizable-element';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { EditorSectionComponent } from '../editor-section/editor-section.component';
import { Observable, of, Subscription } from 'rxjs';
import { switchMap } from 'rxjs/internal/operators/switchMap';
import { map } from 'rxjs/internal/operators/map';


import { HttpResponse } from '@angular/common/http';
import { FileService } from 'src/app/services/file.service/file.service';
import { MenuItem } from 'primeng/api';
import { catchError } from 'rxjs/internal/operators/catchError';
import { ProjectService } from 'src/app/services/project.service/project.service';
import { CollaborateService } from 'src/app/services/collaborator.service/collaborate.service';
import { ProjectInfoDTO } from 'src/app/models/DTO/Project/projectInfoDTO';
import { TokenService } from 'src/app/services/token.service/token.service';
import { RightsService } from 'src/app/services/rights.service/rights.service';
import { UserAccess } from 'src/app/models/Enums/userAccess';
import { ProjectUpdateDTO } from 'src/app/models/DTO/Project/projectUpdateDTO';
import { FileBrowserSectionComponent } from '../file-browser-section/file-browser-section.component';

@Component({
    selector: 'app-workspace-root',
    templateUrl: './workspace-root.component.html',
    styleUrls: ['./workspace-root.component.sass']
})
export class WorkspaceRootComponent implements OnInit, OnDestroy {

    public projectId: number;
    public userId: number;
    public access: UserAccess;
    private routeSub: Subscription;
    private project: ProjectInfoDTO;
    private authorId: number;

    @ViewChild(EditorSectionComponent, { static: false })
    private editor: EditorSectionComponent;

    @ViewChild('fileBrowser', {static: false})
    private fileBrowser: FileBrowserSectionComponent;
    
    constructor(
        private route: ActivatedRoute,
        private tr: ToastrService,
        private ws: WorkspaceService,
        private saveOnExit: LeavePageDialogService,
        private fileService: FileService,
        private rightService: RightsService,
        private collaborateService: CollaborateService,
        private projectService: ProjectService,
        private tokenService: TokenService) { }

    ngOnInit() {
        const userId = this.tokenService.getUserId();
        this.routeSub = this.route.params.subscribe(params => {
            this.projectId = params['id'];
        });
        this.projectService.getAuthorId(this.projectId)
            .subscribe(
            (resp) => {
                this.authorId = resp.body;
                console.log(this.authorId);
            });
        if (this.userId != this.authorId) {
            this.rightService.getUserRightById(userId, this.projectId)
                .subscribe(
                    (resp) => {
                        this.access = resp.body;
                    }
                )
        }
        this.projectService.getProjectById(this.projectId)
            .subscribe(
                (resp) => {
                    this.project = resp.body;
                },
                (error) => {
                    this.tr.error("Can't load selected project.", 'Error Message');
                }
            );
    }

    public IsBigger(number: number) {
        if (this.access >= number) {
            return true;
        }
        return false;
    }

    public isAuthor(): boolean {
        if (this.authorId == this.tokenService.getUserId()) {
            return true;
        }
        return false;
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

    public openModalWindow(): void {
        console.log(this.projectId);
        this.collaborateService.openDialogWindow(this.projectId);
    }

    public saveFiles(): Observable<HttpResponse<FileUpdateDTO>[]> {
        const openedFiles: FileUpdateDTO[] = this.editor.openedFiles.map(x => x.innerFile);
        openedFiles.forEach(file => {
            // file.updaterId = 0;
        });
        return this.saveFilesRequest(openedFiles);
    }

    public onSaveButtonClick(event) {
        if (!this.editor.anyFileChanged()) {
            return;
        }
        this.saveFiles().subscribe(
            success => {
                if (success.every(x => x.ok)) {
                    this.tr.success("Files saved", 'Success', { tapToDismiss: true });
                } else {
                    this.tr.error("Can't save files", 'Error', { tapToDismiss: true });
                }

            },
            error => this.tr.error("Can't save files", 'Error', { tapToDismiss: true }));
    }

    public onFilesSave(files: FileUpdateDTO[]) {
        files.forEach(file => {
            //file.updaterId = 0;
        });
        this.saveFilesRequest(files)
            .subscribe(
                success => {
                    if (success.every(x => x.ok)) {
                        this.tr.success("Files saved", 'Success', { tapToDismiss: true });
                        this.editor.confirmSaving(files.map(x => x.id));
                    } else {
                        this.tr.error("Can't save files", 'Error', { tapToDismiss: true });
                    }
                },
                error => { console.log(error); this.tr.error("Error: can't save files", 'Error', { tapToDismiss: true }) });
    }

    public expand(){
        this.fileBrowser.expandAll();
    }

    public collapse(){
        this.fileBrowser.collapseAll();        
    }

    private saveFilesRequest(files: FileUpdateDTO[]): Observable<HttpResponse<FileUpdateDTO>[]> {
        return this.ws.saveFilesRequest(files);
    }

    public canDeactivate(): Observable<boolean> {
        return !this.editor.anyFileChanged() ? of(true) : this.saveOnExit.confirm('Save changes?')
            .pipe(
                switchMap(
                    mustSave => mustSave ? this.saveFiles().pipe(map(result => result.every(x => x.ok) ? true : false)) : of(false)));
    }

    ngOnDestroy() {
        this.routeSub.unsubscribe();
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
