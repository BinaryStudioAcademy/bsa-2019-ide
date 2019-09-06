import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import * as signalR from "@aspnet/signalr";
import { BehaviorSubject, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FileEditService {
    public openedFiles: Subject<OpenedFile> = new Subject<OpenedFile>();
    private hubConnection: signalR.HubConnection;

    public startConnection = (userId: number, projectId: number) => {
        this.hubConnection = new signalR.HubConnectionBuilder()
            .withUrl(`${environment.apiUrl}filesedit`)
            .build();

        this.hubConnection
            .start()
            .then(() => {
                this.addProjectFilesListener();
                this.connect(userId, projectId);
                this.addChangeFileListener();
                console.log(`SignalR file for project ${projectId} Connection started`);
            })
            .catch(err => console.log('Error while starting connection: ' + err))
    }

    private connect(userId: number, projectId: number): void {
        this.hubConnection.invoke("Connect", userId, projectId)
            .catch((error) => console.log("Error while connecting: " + error));
    }

    private addChangeFileListener(): void {
        this.hubConnection.on('changefilestate', (fileId: string, userId: number, isOpen: boolean, nickName: string) => {
            this.openedFiles.next({ fileId: fileId, isOpen: isOpen, userId: userId, nickName: nickName });
            console.log(`file ${fileId} was changed to state ${isOpen}`)
        });
    }

    private addProjectFilesListener(): void {
        this.hubConnection.on("getProjectchangesFiles", (files: OpenedFile[]) => {
            console.log(files);
            files.forEach(f => {
                this.openedFiles.next(f);
            });
            this.hubConnection.off("getProjectchangesFiles");
        })
    }

    public openFile(fileId: string, projectId: number): void {
        this.hubConnection.invoke("OpenFile", fileId, projectId)
            .catch((error) => console.log("Error while opening file: " + error));
    }

    public closeFile(fileId: string): void {
        this.hubConnection.invoke("CloseFile", fileId)
            .catch((error) => console.log("Error while closing file: " + error));
    }

    public closeProject(projectId: number): void {
        this.hubConnection.invoke("CloseProject", projectId)
            .catch((error) => console.log("Error while closing file: " + error));
    }

    public deleteConnectionIdListener()
    {
        this.hubConnection.off('changeFileState');
    } 
}

export interface OpenedFile {
    fileId: string;
    isOpen: boolean;
    userId: number;
    nickName: string;
}