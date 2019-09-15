import { Component, OnInit, Input } from '@angular/core';
import { SelectItem, DynamicDialogRef, DynamicDialogConfig } from 'primeng/api';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UserDetailsDTO } from 'src/app/models/DTO/User/userDetailsDTO';
import { EditorSettingDTO } from 'src/app/models/DTO/Common/editorSettingDTO';
import { UserService } from 'src/app/services/user.service/user.service';
import { ToastrService } from 'ngx-toastr';
import { ProjectInfoDTO } from 'src/app/models/DTO/Project/projectInfoDTO';
import { ProjectService } from 'src/app/services/project.service/project.service';
import { EditorSettingsService } from 'src/app/services/editor-settings.service/editor-settings.service';
import { TokenService } from 'src/app/services/token.service/token.service';
import { Route, Router } from '@angular/router';

@Component({
    selector: 'app-editor-settings',
    templateUrl: './editor-settings.component.html',
    styleUrls: ['./editor-settings.component.sass']
})
export class EditorSettingsComponent implements OnInit {

    @Input() user: UserDetailsDTO;
    project: ProjectInfoDTO;
    public editorOptions: EditorSettingDTO = {
        lineNumbers: "on",
        roundedSelection: false,
        scrollBeyondLastLine: false,
        readOnly: false,
        fontSize: 20,
        tabSize: 5,
        cursorStyle: "line",
        lineHeight: 20,
        theme: "vs",
        language:""
    };
    public startEditorOptions: EditorSettingDTO;
    public editorSettingsForm: FormGroup;
    public themes: SelectItem[];
    public scrolls: SelectItem[];
    public cursorStyles: SelectItem[];
    public lineNumbers: SelectItem[];
    public settingsUpdate: EditorSettingDTO;
    public settings: EditorSettingDTO;
    public hasDetailsSaveResponse = true;
    public IsWorkspace = false;

    constructor(
        private config: DynamicDialogConfig,
        private formBuilder: FormBuilder,
        private userService: UserService,
        private ref: DynamicDialogRef,
        private toastService: ToastrService,
        private projectService: ProjectService,
        private editorSettingsService: EditorSettingsService,
        private tokenService: TokenService,
        private router: Router
    ) { }

    ngOnInit() {
        this.editorSettingsForm = this.formBuilder.group({
            theme: ['', Validators.required],
            lineHeight: ['', Validators.required],
            cursorStyle: ['', Validators.required],
            tabSize: ['', Validators.required],
            fontSize: ['', Validators.required],
            lineNumbers: ['', Validators.required],
            roundedSelection: ['', Validators.required],
            scrollBeyondLastLine: ['', Validators.required]
        });
        this.themes = [
            { label: 'hc-black', value: 'hc-black' },
            { label: 'vs', value: 'vs' },
            { label: 'vs-dark', value: 'vs-dark' },
        ];
        this.scrolls = [
            { label: 'true', value: true },
            { label: 'false', value: false }
        ];
        this.cursorStyles = [
            { label: 'block', value: 'block' },
            { label: 'line', value: 'line' }
        ];
        this.lineNumbers = [
            { label: 'on', value: 'on' },
            { label: 'off', value: 'off' },
            { label: 'interval', value: 'interval' },
            { label: 'relative', value: 'relative' }
        ];
        if (this.config.data) {
            this.project = this.config.data.project;
            this.settings = this.project.editorProjectSettings;
            this.IsWorkspace = true;
        }
        else {
            this.settings = this.user.editorSettings;
        }
        this.InitializeEditorSettings();
    }

    public close() {
        this.ref.close();
    }

    // public SaveToAllUserProjects() {
    //     this.ref.close();
    // }

    public onSubmit(event) {
        if (!this.IsSettingsNotChange()) {
            this.hasDetailsSaveResponse = false;
            this.getValuesForEditorSettingsUpdate();
            if (!event) {
                console.log('send first')
                this.editorSettingsService.UpdateEditorSettings(this.settingsUpdate)
                    .subscribe(
                        (resp) => {
                            this.hasDetailsSaveResponse = true;
                            this.toastService.success('New details have successfully saved!');
                            this.startEditorOptions = this.settingsUpdate;
                            this.ref.close(this.settingsUpdate);
                            //this.router.navigate([`workspace/${this.project.id}`]);
                        },
                        (error) => {
                            this.hasDetailsSaveResponse = true;
                            this.toastService.error('Can\'t save new editor settings', 'Error Message');
                        }
                    );
            }
            else{
                console.log('send second')
                const userId=this.tokenService.getUserId();
                this.editorSettingsService.UpdateAllUserProjectEditorSettings(this.settingsUpdate,userId)
                    .subscribe(
                        (resp) => {
                            this.hasDetailsSaveResponse = true;
                            this.toastService.success('New details have successfully saved!');
                            this.startEditorOptions = this.settingsUpdate;
                            this.ref.close(this.settingsUpdate);
                        },
                        (error) => {
                            this.hasDetailsSaveResponse = true;
                            this.toastService.error('Can\'t save new editor settings', 'Error Message');
                        }
                    );        
            }
        }
    }

    public InitializeEditorSettings(): void {
        if (!this.settings) {
            this.user.editorSettings = this.editorOptions;
            this.settings = this.editorOptions;
            this.userService.updateUser(this.user).subscribe();
        }
        this.editorSettingsForm.setValue({
            theme: this.settings.theme,
            cursorStyle: this.settings.cursorStyle,
            fontSize: this.settings.fontSize,
            lineHeight: this.settings.lineHeight,
            lineNumbers: this.settings.lineNumbers,
            roundedSelection: this.settings.roundedSelection,
            scrollBeyondLastLine: this.settings.scrollBeyondLastLine,
            tabSize: this.settings.tabSize
        });
        this.startEditorOptions = this.settings;
    }

    public IsSettingsNotChange(): boolean {
        return this.editorSettingsForm.get('theme').value === this.startEditorOptions.theme
            && this.editorSettingsForm.get('cursorStyle').value === this.startEditorOptions.cursorStyle
            && this.editorSettingsForm.get('fontSize').value === this.startEditorOptions.fontSize
            && this.editorSettingsForm.get('lineHeight').value === this.startEditorOptions.lineHeight
            && this.editorSettingsForm.get('lineNumbers').value === this.startEditorOptions.lineNumbers
            && this.editorSettingsForm.get('roundedSelection').value === this.startEditorOptions.roundedSelection
            && this.editorSettingsForm.get('scrollBeyondLastLine').value === this.startEditorOptions.scrollBeyondLastLine
            && this.editorSettingsForm.get('tabSize').value === this.startEditorOptions.tabSize
    }

    private getValuesForEditorSettingsUpdate() {
        this.settingsUpdate = {
            readOnly: false,
            id: this.settings.id,
            theme: this.editorSettingsForm.get('theme').value,
            fontSize: this.editorSettingsForm.get('fontSize').value,
            lineHeight: this.editorSettingsForm.get('lineHeight').value,
            lineNumbers: this.editorSettingsForm.get('lineNumbers').value,
            roundedSelection: this.editorSettingsForm.get('roundedSelection').value,
            scrollBeyondLastLine: this.editorSettingsForm.get('scrollBeyondLastLine').value,
            tabSize: this.editorSettingsForm.get('tabSize').value,
            cursorStyle: this.editorSettingsForm.get('cursorStyle').value,
            language: null
        }
        if (this.config.data) {
            this.project.editorProjectSettings = this.settingsUpdate;
            return;
        }
        this.user.editorSettings = this.settingsUpdate;
    }
}
