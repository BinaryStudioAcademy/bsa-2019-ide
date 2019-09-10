import { EventService } from './../../../services/event.service/event.service';
import { LeavePageDialogService } from './../../../services/leave-page-dialog.service';
import { FileUpdateDTO } from './../../../models/DTO/File/fileUpdateDTO';
import { WorkspaceService } from './../../../services/workspace.service';

import { Component, OnInit, ViewChild, OnDestroy, AfterViewInit, OnChanges, ChangeDetectorRef, AfterContentInit, HostListener } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { EditorSectionComponent } from '../editor-section/editor-section.component';
import { Observable, of, Subscription, Subject, Observer } from 'rxjs';
import { switchMap } from 'rxjs/internal/operators/switchMap';
import { map } from 'rxjs/internal/operators/map';

import { HttpResponse } from '@angular/common/http';
import { FileService } from 'src/app/services/file.service/file.service';
import { ProjectService } from 'src/app/services/project.service/project.service';
import { ProjectInfoDTO } from 'src/app/models/DTO/Project/projectInfoDTO';
import { TokenService } from 'src/app/services/token.service/token.service';
import { ProjectDialogService } from 'src/app/services/proj-dialog.service/project-dialog.service';
import { ProjectType } from '../../project/models/project-type';
import { RightsService } from 'src/app/services/rights.service/rights.service';
import { UserAccess } from 'src/app/models/Enums/userAccess';
import { FileBrowserSectionComponent, SelectedFile } from '../file-browser-section/file-browser-section.component';
import { FileDTO } from 'src/app/models/DTO/File/fileDTO';
import { HotkeyService } from 'src/app/services/hotkey.service/hotkey.service';
import { FileRenameDTO } from '../../../models/DTO/File/fileRenameDTO';
import { BuildService } from 'src/app/services/build.service';
import { Language } from 'src/app/models/Enums/language';
import { EditorSettingDTO } from 'src/app/models/DTO/Common/editorSettingDTO';
import { SignalRService } from 'src/app/services/signalr.service/signal-r.service';
import { filter, throwIfEmpty, tap, takeUntil, delay, distinctUntilChanged } from 'rxjs/operators';
import { ErrorHandlerService } from 'src/app/services/error-handler.service/error-handler.service';
import { AccessModifier } from 'src/app/models/Enums/accessModifier';
import { ConfirmationService } from 'primeng/api';
import { FileEditService } from 'src/app/services/file-edit.service/file-edit.service';
import { TerminalService } from 'primeng/components/terminal/terminalservice';
import { FileSaverService } from 'src/app/services/workspace-file-saver.service/file-saver.service';
import { TouchSequence } from 'selenium-webdriver';


@Component({
    selector: 'app-workspace-root',
    templateUrl: './workspace-root.component.html',
    styleUrls: ['./workspace-root.component.sass']
})
export class WorkspaceRootComponent implements OnInit, OnDestroy, AfterViewInit, OnChanges {
    public confirmationOnLeavePage$: Observable<boolean>;
    ngOnChanges(changes: import("@angular/core").SimpleChanges): void {
        throw new Error("Method not implemented.");
    }
    public prepareQuery;
    public projectId: number;
    public userId: number;
    public access: UserAccess;
    public showFileBrowser = true;
    public showSearchField = false;
    public large = false;
    public canRun = false;
    public canBuild = false;
    public canNotEdit = false;
    public expandFolder = false;
    public project: ProjectInfoDTO;
    public options: EditorSettingDTO;
    public inputItems: string[];
    public connectionId: string;
    public isInputTerminalOpen = false;
    public isSaveButtonDisabled;
    public isSaveAllButtonDisabled;

    private routeSub: Subscription;
    private authorId: number;

    private isDown: boolean;
    private workspaceWidth: number;
    private startHorPos: number;
    private movingRight: number;

    private ngUnsubscribe: Subject<void> = new Subject<void>();

    public eventsSubject: Subject<void> = new Subject<void>();
    public isOpenedConnection: boolean = null;

    @ViewChild(EditorSectionComponent, { static: false })
    private editor: EditorSectionComponent;

    @ViewChild(FileBrowserSectionComponent, { static: false })
    private fileBrowser: FileBrowserSectionComponent;

    @HostListener('window:beforeunload', ['$event'])
    beforeunloadHandler(event) {
        if(!this.isSaveAllButtonDisabled){
            event.preventDefault();
            event.returnValue = '';
        }

    }

    constructor(
        private route: ActivatedRoute,
        private toast: ToastrService,
        private workSpaceService: WorkspaceService,
        private saveOnExit: LeavePageDialogService,
        private rightService: RightsService,
        private projectService: ProjectService,
        private projectEditService: ProjectDialogService,
        private tokenService: TokenService,
        private hotkeys: HotkeyService,
        private buildService: BuildService,
        private eventService: EventService,
        private cdr: ChangeDetectorRef,
        private signalRService: SignalRService,
        private errorHandlerService: ErrorHandlerService,
        private confirmationService: ConfirmationService,
        private fileEditService: FileEditService,
        private fileSaverService: FileSaverService) {

        this.hotkeys.addShortcut({ keys: 'control.h' })
            .subscribe(() => {
                this.hideFileBrowser();
            });
        this.hotkeys.addShortcut({ keys: 'control.b' })
            .subscribe(() => {
                this.onBuild();
            });
        this.hotkeys.addShortcut({ keys: 'control.r' })
            .subscribe(() => {
                this.onRun();
            });

            //Save file Ctrl+S
        this.hotkeys.addShortcut({ keys: 'control.s' })
            .subscribe(() => {
                this.onSaveButtonClick();
            });
            //Save All Ctrl+Shift+S
        this.hotkeys.addShortcut({ keys: 'control.shift.s' })
            .subscribe(() => {
                this.onSaveButtonClick();
            });
    }

    ngAfterViewInit() {

        this.route.queryParams.pipe(takeUntil(this.ngUnsubscribe)).subscribe(params => {
            if (!!params['query']) {
                this.fileBrowser.curSearch = params['query'];
                this.showSearchField = true;
                this.cdr.detectChanges();
            }
        });



    }

    public OnChange(event: boolean) {
        if (event) {
            this.inputItems = null;
            this.isInputTerminalOpen = false;
        }
    }

    ngOnInit() {
        this.eventService.isNotSaveDataAllTabsObserve$.pipe(distinctUntilChanged())
        .subscribe(x => {this.isSaveAllButtonDisabled = !x});
        this.eventService.isNotSaveDataOneTabObserve$.subscribe(x => this.isSaveButtonDisabled = !x);

        this.confirmationOnLeavePage$ = Observable.create((observer: Observer<boolean>) => {
            this.confirmationService.confirm({
                message: 'Save changes on page?',
                accept: () => {
                    const files = this.editor.openedFiles.filter(f => f.isChanged).map(x => x.innerFile);
                    this.saveFilesRequest(files).pipe(takeUntil(this.ngUnsubscribe))
                        .subscribe(
                            response => {
                                if (response.every(x => x.ok)) {
                                    this.toast.success("Files saved", 'Success', { tapToDismiss: true });
                                    this.editor.confirmSaving(files.map(f => f.id));
                                } else {
                                    this.toast.error("Can't save files", 'Error', { tapToDismiss: true });
                                }

                            observer.next(true);
                        },
                        error => { this.toast.error(this.errorHandlerService.getExceptionMessage(error), 'Error', { tapToDismiss: true }); observer.next(true); }
                    )
                },
                reject: () => {
                    observer.next(true);
                }
            });
        });

        this.eventService.initComponentFinished$.pipe(takeUntil(this.ngUnsubscribe))
            .pipe(
                filter(m => m === "EditorSectionComponent"),
                switchMap(() => {
                    return this.route.queryParams;
                }),
                filter(params => !!params['fileId']),
                map(params => params['fileId']))
            .subscribe(fileId => this.onFileSelected(fileId));


        this.userId = this.tokenService.getUserId();

        this.routeSub = this.route.params.subscribe(params => {
            this.projectId = params['id'];
            this.fileSaverService.setProjectId(this.projectId);
        });

        this.projectService.getProjectById(this.projectId).pipe(takeUntil(this.ngUnsubscribe))
            .subscribe(
                (resp) => {
                    this.project = resp.body;
                    this.eventService.currProjectSwitch({ id: this.project.id, name: this.project.name });
                    this.authorId = resp.body.authorId;
                    this.options = this.project.editorProjectSettings;
                    this.setRights();
                    this.loadFiles();
                    this.startConnection();
                },
                () => {
                    this.toast.error("Can't load selected project.", 'Error Message');
                }
            );
    }

    private setRights() {
        if (this.project.authorId != this.userId)
            this.rightService.getUserRightById(this.userId, this.projectId)
                .subscribe(
                    (resp) => {
                        this.access = resp.body;
                        this.setUserAccess();
                    }
                );
    }

    private startConnection() {
        this.fileEditService.startConnection(this.userId, this.project.id);
        this.fileEditService.isConnected.pipe(takeUntil(this.ngUnsubscribe)).subscribe(state => {
            this.isOpenedConnection = state;
        });
        this.fileEditService.openedFiles.pipe(takeUntil(this.ngUnsubscribe)).subscribe(x =>
            {
                if (x.userId !== this.userId) {
                    // console.log('its somebodyth else file');
                    this.fileBrowser.changeFileState(x.fileId, x.isOpen, x.nickName);
                    this.editor.changeFileState(x.fileId, true);
                    if (!x.isOpen && this.editor.contains(x.fileId)) {
                        this.fileEditService.openFile(x.fileId, this.project.id);
                    }
                } else if(x.userId === this.userId && this.editor.contains(x.fileId)) {
                    // console.log("it's my own file");
                    this.editor.changeFileState(x.fileId, false);
                    this.workSpaceService.getFileById(x.fileId).subscribe(resp => {
                        this.editor.updateFile({content: resp.body.content, id: resp.body.id, name: null, folder: null, isOpen: false, updater: null, language: null});
                    })
                    this.editor.changeReadOnlyState(false);
                }
            });
    }

    private findAllOccurence(substring?: string) {
        if (substring == null)
            return;
        setTimeout(() => {
            this.editor.hightlineMatches(substring);
        }, 500)
    }

    public getProjectColor(): string {
        return this.project.color;
    }

    public Settings() {
        const a = this.workSpaceService.show(this.project);
        a.subscribe(
            (resp) => {
                if (resp) {
                    this.options = resp as EditorSettingDTO;
                }
            }
        );
    }

    public setUserAccess() {
        switch (this.access) {
            case 0:
                this.canNotEdit = true;
                break;
            case 2:
                this.canNotEdit = false;
                this.canBuild = true;
                break;
            case 3:
                this.canNotEdit = false;
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

    public onFileSelected(selectedFile: SelectedFile): void {
        this.fileSaverService.addOpenedFile(selectedFile);

        if (this.editor && this.editor.openedFiles.some(f => f.innerFile.id === selectedFile.fileId)) {
            this.editor.activeItem = this.editor.tabs.find(i => i.id === selectedFile.fileId);
            this.editor.code = this.editor.openedFiles.find(f => f.innerFile.id === selectedFile.fileId).innerFile.content;
            this.editor.monacoOptions.language = this.editor.openedFiles.find(f => f.innerFile.id === selectedFile.fileId).innerFile.language;
            this.findAllOccurence(selectedFile.filterString);
            return;
        }
        this.loadFile(selectedFile);
    }

    private sortTabs: Subject<boolean> = new Subject<boolean>();
    private openedFiles: number;
    private filesCount: number;

    private loadFiles() {
        const files = this.fileSaverService.getAllOpenedFilesForProject();
        const filesCount = files.length;
        this.filesCount = filesCount;
        this.openedFiles = 0;
        if (filesCount > 0)
            this.sortTabs.subscribe(() => {
                    this.openedFiles++;
                    if(this.openedFiles === this.filesCount) {
                        this.sortTabs.complete();
                        this.editor.sortTabs();
                    }
                });
        setTimeout(() => {
            files.forEach(file => {
                this.loadFile(file, false);
            });
        }, 1000); 
    }

    private loadFile(file: SelectedFile, onBrowserSelect: boolean = true) {
        this.workSpaceService.getFileById(file.fileId)
            .subscribe(
                (resp) => {
                    if (resp.ok) {
                        const { id, name, content, folder, updaterId, isOpen, updater, language } = resp.body as FileDTO;
                        const fileUpdateDTO: FileUpdateDTO = { id, name, content, folder, isOpen, updaterId, updater, language };
                        var tabName = name;

                        this.editor.AddFileToOpened(fileUpdateDTO);
                        this.editor.monacoOptions.readOnly = fileUpdateDTO.isOpen;
                        this.editor.addActiveTab(tabName, file.fileIcon, id);

                        if(onBrowserSelect) {
                            this.fileBrowser.selectedItem.label = tabName;
                            this.editor.code = content;
                        }
                        if (this.showFileBrowser) {
                            document.getElementById('workspace').style.width = ((this.workspaceWidth) / this.maxSize()) + '%';
                        }
                        this.findAllOccurence(file.filterString);
                    } else {
                        this.toast.error("Can't load selected file", 'Error Message');
                    }
                },
                (error) => {
                    this.toast.error("Can't load selected file.", 'Error Message');
                    console.error(error.message);
                },
                () => {
                    this.fileEditService.openFile(file.fileId, this.project.id);
                    if (!onBrowserSelect) {
                        this.sortTabs.next();
                    }
                }
            );
    }

    public onBuild() {
        this.buildService.buildProject(this.project.id).pipe(takeUntil(this.ngUnsubscribe)).subscribe(
            (response) => {
                this.toast.info('Build was started', 'Info Message', { tapToDismiss: true });
            },
            (error) => {
                console.log(error);
                this.toast.error(this.errorHandlerService.getExceptionMessage(error), 'Error Message', { tapToDismiss: true });
            }
        );
    }

    public onRun() {
        if (this.project.language !== Language.cSharp) {
            this.toast.info('Only C# project available for run', 'Info Message', { tapToDismiss: true });
            return;
        }

        this.connectionId = this.signalRService.getConnectionId();
        if (this.connectionId == null) {
            this.toast.error('Please check your internet connection and refresh page before run', 'Info Message', { tapToDismiss: true });
            return;
        }

        this.buildService.runProject(this.project.id, this.connectionId).subscribe(
            (resp) => {
                this.inputItems = resp.body;
                this.isInputTerminalOpen = true;
                if (!this.inputItems || this.inputItems.length == 0) {
                    this.toast.info('Run was started', 'Info Message', { tapToDismiss: true });
                }
            },
            (error) => {
                console.log(error);
                this.toast.error('Something bad happened(', 'Error Message', { tapToDismiss: true });
            }
        )
    }

    public onFileClosed(evt: { file: FileUpdateDTO, mustSave: boolean }) {
        if (evt.mustSave) {
            this.onFilesSave([evt.file]);
        }
        this.fileEditService.closeFile(evt.file.id);
    }

    public onSaveButtonClick() {
        const fileToSave = this.editor.getFileFromActiveItem();

        if (fileToSave.isChanged) {
            this.onFilesSave([fileToSave.innerFile]);
        }
    }

    public onSaveAllButtonClick() {
        if (!this.editor.anyFileChanged()) {
            return;
        }

        const files = this.editor.openedFiles.filter(f => f.isChanged).map(x => x.innerFile);
        this.onFilesSave(files);
    }

    public onFilesSave(files: FileUpdateDTO[]) {
        this.saveFilesRequest(files).pipe(takeUntil(this.ngUnsubscribe))
            .subscribe(
                (success) => {
                    if (success.every(x => x.ok)) {
                        this.toast.success("Files saved", 'Success', { tapToDismiss: true });
                        this.editor.confirmSaving(files.map(f=> f.id));
                    } else {
                        this.toast.error("Can't save files", 'Error', { tapToDismiss: true });
                    }
                },
                (error) => {
                    this.toast.error(this.errorHandlerService.getExceptionMessage(error), 'Error', { tapToDismiss: true });
                });
    }

    public hideSearchField() {
        this.showSearchField = !this.showSearchField;
    }

    public hideFileBrowser() {
        this.showFileBrowser = !this.showFileBrowser;
        if (!this.showFileBrowser && this.showSearchField) {
            this.showFileBrowser = true;
        }
        if (this.showFileBrowser) {
            this.showSearchField = false;
        }
        if (!this.showFileBrowser) {
            this.workspaceWidth = document.getElementById('workspace').offsetWidth;
            document.getElementById('workspace').style.width = '100%';
        } else {
            document.getElementById('workspace').style.width = ((this.workspaceWidth - 1) / this.maxSize() * 100) + '%';
        }
    }

    public editProjectSettings() {
        this.projectEditService.show(ProjectType.Update, this.projectId);
    }

    public expand() {
        this.eventsSubject.next();
    }

    public refresh() {
        this.fileBrowser.ngOnInit();
    }

    public saveFilesRequest(files: FileUpdateDTO[]): Observable<HttpResponse<FileUpdateDTO>[]> {
        return this.workSpaceService.saveFilesRequest(files);
    }

    public draggableDown(e: MouseEvent) {
        e.preventDefault();
        this.isDown = true;
        this.startHorPos = e.x;
    }

    public draggableMove(e: MouseEvent) {
        if (this.isDown) {
            e.preventDefault();
            this.movingRight = e.x - this.startHorPos;
            this.startHorPos = e.x;
            let browserElement = document.getElementById('browser');
            let workspaceElement = document.getElementById('workspace');
            let width = browserElement.offsetWidth + this.movingRight;
            browserElement.style.width = (width / this.maxSize() * 100) + '%';
            workspaceElement.style.width = (this.calc(width) / this.maxSize() * 100) + '%';
            this.workspaceWidth = workspaceElement.offsetWidth;
        }
    }

    public draggableUp(e: MouseEvent) {
        if (e.type === 'mouseup') {
            this.isDown = false;
        }
        else if (e.y < 100 || e.x < 50) {
            this.isDown = false;
        }
    }

    private maxSize() {
        return document.getElementById('container').offsetWidth;
    }

    private calc(size: number): number {
        return document.getElementById('container').offsetWidth - size - 5;
    }

    canDeactivate(): Observable<boolean> {
        return !this.editor.anyFileChanged() ? of(true) : this.confirmationOnLeavePage$
    }

    ngOnDestroy() {
        this.routeSub.unsubscribe();
        this.fileEditService.openedFiles.unsubscribe();
        this.fileEditService.closeProject(this.project.id);
        this.signalRService.deleteConnectionIdListener();
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }
}
