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
import { ProjectInfoDTO } from 'src/app/models/DTO/Project/projectInfoDTO';
import { TokenService } from 'src/app/services/token.service/token.service';
import { ProjectDialogService } from 'src/app/services/proj-dialog.service/project-dialog.service';
import { ProjectType } from '../../project/models/project-type';
import { RightsService } from 'src/app/services/rights.service/rights.service';
import { UserAccess } from 'src/app/models/Enums/userAccess';
import { ProjectUpdateDTO } from 'src/app/models/DTO/Project/projectUpdateDTO';
import { FileBrowserSectionComponent } from '../file-browser-section/file-browser-section.component';
import { FileDTO } from 'src/app/models/DTO/File/fileDTO';
import { HotkeyService } from 'src/app/services/hotkey.service/hotkey.service';
import { FileRenameDTO } from '../../../models/DTO/File/fileRenameDTO';

@Component({
    selector: 'app-workspace-root',
    templateUrl: './workspace-root.component.html',
    styleUrls: ['./workspace-root.component.sass']
})
export class WorkspaceRootComponent implements OnInit, OnDestroy {

    public projectId: number;
    public userId: number;
    public access: UserAccess;
    public showFileBrowser = true;
    public showSearch = false;
    public large = false;
    public canRun = false;
    public canBuild = false;
    public canEdit = false;
    public expandFolder=false;
    public project: ProjectInfoDTO;

    private routeSub: Subscription;
    private authorId: number;

    @ViewChild(EditorSectionComponent, { static: false })
    private editor: EditorSectionComponent;

    @ViewChild('fileBrowser', { static: false })
    private fileBrowser: FileBrowserSectionComponent;

    constructor(
        private route: ActivatedRoute,
        private tr: ToastrService,
        private workSpaceService: WorkspaceService,
        private saveOnExit: LeavePageDialogService,
        private fileService: FileService,
        private rightService: RightsService,
        private projectService: ProjectService,
        private projectEditService: ProjectDialogService,
        private tokenService: TokenService,
        private hotkeys: HotkeyService) { 
            this.hotkeys.addShortcut({keys: 'shift.h'})
        .subscribe(()=>{
            this.hideFileBrowser();
        });
        }

    ngOnInit() {
        const userId = this.tokenService.getUserId();
        this.routeSub = this.route.params.subscribe(params => {
            this.projectId = params['id'];
        });
        this.projectService.getAuthorId(this.projectId)
            .subscribe(
                (resp) => {
                    this.authorId = resp.body;
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
        this.setUserAccess();
    }

    public getProjectColor(): string
    {
        return this.project.color;
    }

    public setUserAccess() {
        switch (this.access) {
            case 1:
                this.canEdit = true;
                break;
            case 2:
                this.canEdit = true;
                this.canBuild = true;
                break;
            case 3:
                this.canEdit = true;
                this.canBuild = true;
                this.canRun = true;
                break;
            default:
                break
        }
    }

    public isAuthor(): boolean {
        if (this.authorId == this.tokenService.getUserId()) {
            return true;
        }
        return false;
    }

    public onFileRenaming(fileUpdate: FileRenameDTO) {
        const tab = this.editor.tabs.find(x => x.id === fileUpdate.id);
        if (tab !== undefined) {
            tab.label = fileUpdate.name;
        }
    }

    public onFileSelected(fileId: string): void {
        if (this.editor.openedFiles.some(f => f.innerFile.id === fileId)) {
            this.editor.activeItem = this.editor.tabs.find(i => i.id === fileId);
            this.editor.code = this.editor.openedFiles.find(f => f.innerFile.id === fileId).innerFile.content;
            return;
        }

        this.workSpaceService.getFileById(fileId)
            .subscribe(
                (resp) => {
                    if (resp.ok) {
                        const { id, name, content, folder, updaterId } = resp.body as FileDTO;
                        const fileUpdateDTO: FileUpdateDTO = { id, name, content, folder };
                        this.editor.AddFileToOpened(fileUpdateDTO);
                        this.editor.tabs.push({ label: name, icon: 'fa fa-fw fa-file', id: id });
                        this.editor.activeItem = this.editor.tabs[this.editor.tabs.length - 1];
                        this.editor.code = content;
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

    public onFilesSave(files?: FileUpdateDTO[]) {
        if (!this.editor.anyFileChanged()) {
            return;
        }
        this.saveFilesRequest(files)
            .subscribe(
                success => {
                    if (success.every(x => x.ok)) {
                        this.tr.success("Files saved", 'Success', { tapToDismiss: true });
                    } else {
                        this.tr.error("Can't save files", 'Error', { tapToDismiss: true });
                    }
                },
                error => { console.log(error); this.tr.error("Error: can't save files", 'Error', { tapToDismiss: true }) });
    }

    public hideSearchField(): void {
        this.showSearch = !this.showSearch;
    }

    public hideFileBrowser(): void
    {
        this.showFileBrowser= !this.showFileBrowser;
    }
    
    public editProjectSettings() {
        this.projectEditService.show(ProjectType.Update, this.projectId);
    }

    private saveFilesRequest(files?: FileUpdateDTO[]): Observable<HttpResponse<FileUpdateDTO>[]> {
        if(!files)
        {
            files = this.editor.openedFiles.map(x => x.innerFile);         
        }
        return this.workSpaceService.saveFilesRequest(files);
    }

    canDeactivate(): Observable<boolean> {
        return !this.editor.anyFileChanged() ? of(true) : this.saveOnExit.confirm('Save changes?')
            .pipe(
                switchMap(
                    mustSave => mustSave ? this.saveFilesRequest().pipe(map(result => result.every(x => x.ok) ? true : false)) : of(false)));
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
