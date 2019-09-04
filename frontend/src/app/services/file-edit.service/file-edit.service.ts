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
        this.hubConnection.on('changefilestate', (fileId: string, isOpen: boolean) => {
            this.openedFiles.next({ fileId: fileId, isOpen: isOpen });
            console.log(`file ${fileId} was changed to state ${isOpen}`)
        });
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

export class OpenedFile {
    fileId: string;
    isOpen: boolean;
}