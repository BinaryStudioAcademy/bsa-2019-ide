import { Component, OnInit, Input } from '@angular/core';
import { SelectItem } from 'primeng/api';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UserDetailsDTO } from 'src/app/models/DTO/User/userDetailsDTO';
import {EditorSettingDTO} from 'src/app/models/DTO/Common/editorSettingDTO';
import { UserService } from 'src/app/services/user.service/user.service';

@Component({
    selector: 'app-editor-settings',
    templateUrl: './editor-settings.component.html',
    styleUrls: ['./editor-settings.component.sass']
})
export class EditorSettingsComponent implements OnInit {

    @Input() user: UserDetailsDTO;
    public editorOptions: EditorSettingDTO =
        {
            lineNumbers: "on",
            roundedSelection: false,
            scrollBeyondLastLine: false,
            readOnly: false,
            fontSize: 20,
            tabSize: 5,
            cursorStyle: "line",
            lineHeight: 20,
            theme: "vs",
        };
    public startEditorOptions: EditorSettingDTO;
    public editorSettingsForm: FormGroup;
    public themes: SelectItem[];
    public scrolls: SelectItem[];
    public cursorStyles: SelectItem[];
    public lineNumbers: SelectItem[];
    public settings: EditorSettingDTO;
    public hasDetailsSaveResponse=true;

    constructor(
        private formBuilder: FormBuilder,
        private userService: UserService
    ) { }

    ngOnInit() {
        this.editorSettingsForm = this.formBuilder.group({
            theme: [''],
            lineHeight: [''],
            cursorStyle: [''],
            tabSize: [''],
            fontSize: [''],
            lineNumbers: [''],
            roundedSelection: [''],
            scrollBeyondLastLine: ['']});
        this.themes = [
            { label: 'hc-black', value: 'hc-black' },
            { label: 'vs', value: 'vs' },
            { label: 'vs-dark', value: 'vs-dark' },
        ];
        this.scrolls = [
            { label: 'true', value: true },
            { label: 'false', value: false }
        ];
        this.cursorStyles=[
            { label: 'block', value: 'block' },
            { label: 'line', value: 'line' }
        ];
        this.lineNumbers=[
            { label: 'on', value: 'on' },
            { label: 'off', value: 'off' },
            { label: 'interval', value: 'interval' },
            { label: 'relative', value: 'relative' }
        ];
        this.InitializeEditorSettings(this.user);
    }

    public InitializeEditorSettings(userSettings: UserDetailsDTO): void
    {
        this.settings =JSON.parse(userSettings.editorSettings);
        if(!this.settings)
        {
            this.user.editorSettings=JSON.stringify(this.editorOptions);
            this.settings=this.editorOptions;
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
            tabSize: this.settings.tabSize});
        this.startEditorOptions=this.settings;
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
}
