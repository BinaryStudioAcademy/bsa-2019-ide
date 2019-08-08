import { Injectable } from '@angular/core';
import { HttpClientWrapperService } from '../http-client-wrapper.service';
import { UserDTO } from 'src/app/models/User/userDTO';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  public routePrefix = 'users';

  constructor(private httpService: HttpClientWrapperService) { }

  public getUserFromToken() {
    return this.httpService.getRequest<UserDTO>(`${this.routePrefix}/fromToken`);
  }

  public copyUser({email, firstName, lastName, id,nickName }: UserDTO) {
    return {
        firstName,
        email,
        lastName,
        id,
        nickName
    };
}
}
