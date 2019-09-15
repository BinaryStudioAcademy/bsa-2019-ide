import { Injectable } from '@angular/core';
import { SelectedFile } from 'src/app/modules/workspace/file-browser-section/file-browser-section.component';

@Injectable({
  providedIn: 'root'
})
export class FileSaverService {
    private projectId: number;
    private locked: boolean = true;

    constructor() { }

    public setProjectId(projectId: number) {
        this.projectId = projectId;
    }

    public addOpenedFile(file: SelectedFile) {
        if (this.projectId === 0)
            return;
        let files: SelectedFile[] = JSON.parse(localStorage.getItem('project' + this.projectId));

        if(files === null)
            files = [];
        else if(files.find(f => f.fileId === file.fileId))
            return;

        files.push(file);
        localStorage.setItem('project' + this.projectId, JSON.stringify(files));
    }

    public removeOpenedFile(fileId: string) {
        if (this.projectId === 0)
            return;
        let files: SelectedFile[] = JSON.parse(localStorage.getItem('project' + this.projectId));

        if(files === null)
            return;
        files = files.filter(f => f.fileId !== fileId);

        if(files.length > 0)
            localStorage.setItem('project' + this.projectId, JSON.stringify(files));
        else 
            localStorage.removeItem('project' + this.projectId);
    }

    public getAllOpenedFilesForProject() {
        var files: SelectedFile[] = JSON.parse(localStorage.getItem('project' + this.projectId));

        return files !== null ? files : [];
    }

    public unlockSelections() {
        this.locked = false;
    }

    public setSelected(fileId: string) {
        if (!this.locked) {
            localStorage.setItem(`project${this.projectId}active`, fileId);
        }
    }

    public removeSelected() {
        localStorage.removeItem(`project${this.projectId}active`);
    }

    public getSelected() {
        return localStorage.getItem(`project${this.projectId}active`);
    }
}
