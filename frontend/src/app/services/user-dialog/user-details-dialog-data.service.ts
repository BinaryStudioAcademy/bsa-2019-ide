import { Injectable } from '@angular/core';
import { UserDetailsDTO } from 'src/app/models/DTO/User/userDetailsDTO';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserDetailsDialogDataService {

    private readonly _users = new BehaviorSubject<UserDetailsDTO>(null);
    public readonly todos$ = this._users.asObservable();
    private set users(val: UserDetailsDTO) {
        this._users.next(val);
    }

    addProject(user: UserDetailsDTO) {
        this.users = user;
    }
    
    removeTodo(id: number) {
        this.users = null;
    }
}
