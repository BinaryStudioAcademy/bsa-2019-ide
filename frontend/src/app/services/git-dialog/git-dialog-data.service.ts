import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { GitMessageDTO } from 'src/app/models/DTO/Git/gitMessageDTO';

@Injectable({
  providedIn: 'root'
})
export class GitDialogDataService {

    private readonly _git = new BehaviorSubject<GitMessageDTO>(null);
    public readonly todos$ = this._git.asObservable();
    private set git(val: any) {
        this._git.next(val);
    }

    gitCommand(git: GitMessageDTO) {
        this.git = git;
    }
    
    removeTodo(id: number) {
        this.git = null;
    }
}
