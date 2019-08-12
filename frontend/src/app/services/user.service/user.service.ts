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

    public getUserDetails() : UserDetailsDTO{
        return {
            firstName: "Dima",
            lastName: "Afanasiev",
            nickname: "coolman2019",
            imageUrl: "http://bootdey.com/img/Content/avatar/avatar6.png",
            githubUrl: "https://github.com/kotsabiukmv98",
            birthday:  "September 6, 2000",
            registredAt: "May 28, 2009, at 5:11 am",
            lastActiveAt: "Des 8, 2000, at 3:51 pm"
        }
    }
}
