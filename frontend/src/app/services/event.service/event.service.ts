import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { UserDTO } from 'src/app/models/DTO/User/userDTO';

@Injectable({
  providedIn: 'root'
})
export class EventService {
    private onUserChanged = new Subject<UserDTO>();
    public userChangedEvent$ = this.onUserChanged.asObservable();

    public userChanged(user: UserDTO) {
        this.onUserChanged.next(user);
    }
}
