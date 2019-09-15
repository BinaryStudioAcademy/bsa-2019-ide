import { Injectable } from '@angular/core';
import { Subject, Observable, BehaviorSubject } from 'rxjs';
import { UserDTO } from 'src/app/models/DTO/User/userDTO';
import { SearchProjectDTO } from 'src/app/models/DTO/Project/searchProjectDTO';

@Injectable({
    providedIn: 'root'
})
export class EventService {
    public createProjectModal = new Subject<boolean>();
    public onCreateProjectModal$ = this.createProjectModal.asObservable();
    
    public isNotSavedDataAllTabs = new BehaviorSubject(false);
    public isNotSavedDataOneTab = new BehaviorSubject(false);
    public isNotSaveDataAllTabsObserve$ = this.isNotSavedDataAllTabs.asObservable();
    public isNotSaveDataOneTabObserve$ = this.isNotSavedDataOneTab.asObservable();
    private onUserChanged = new Subject<UserDTO>();
    private currProjectChangedEmitter = new Subject<SearchProjectDTO>();
    private initComponentFinishedEmitter = new Subject<string>();
    
    public userChangedEvent$: Observable<UserDTO> = this.onUserChanged.asObservable();
    public currProjectChanged$: Observable<SearchProjectDTO> = this.currProjectChangedEmitter.asObservable();
    public initComponentFinished$: Observable<string> = this.initComponentFinishedEmitter.asObservable();

    public userChanged(user: UserDTO) {
        this.onUserChanged.next(user);
    }

    public componentAfterInit(message: string) {
        this.initComponentFinishedEmitter.next(message);
    }

    public currProjectSwitch(proj: SearchProjectDTO) {
        this.currProjectChangedEmitter.next(proj);
    }


}
