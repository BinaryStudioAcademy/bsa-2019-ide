import { Injectable } from '@angular/core';
import { HttpClientWrapperService } from '../http-client-wrapper.service';
import { UserDTO } from 'src/app/models/DTO/User/userDTO';
import { UserDetailsDTO } from 'src/app/models/DTO/User/userDetailsDTO';

@Injectable({
    providedIn: 'root'
})
export class UserService {

    public routePrefix = 'users';

    constructor(private httpService: HttpClientWrapperService) { }

    public getUserFromToken() {
        return this.httpService.getRequest<UserDTO>(`${this.routePrefix}/fromToken`);
    }

    public getUserDetailsFromToken() {
        return this.httpService.getRequest<UserDetailsDTO>(`${this.routePrefix}/details`);
    }

    public getUserById(id: number) {
        return this.httpService.getRequest<UserDTO>(`${this.routePrefix}`, { id });
    }

    public updateUser(user: UserDTO) {
        return this.httpService.putRequest<UserDTO>(`${this.routePrefix}`, user);
    }

    public copyUser({ email, firstName, lastName, id, nickName }: UserDTO) {
        return {
            firstName,
            email,
            lastName,
            id,
            nickName
        };
    }
}
