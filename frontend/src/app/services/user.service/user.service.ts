import { Injectable } from '@angular/core';
import { HttpClientWrapperService } from '../http-client-wrapper.service';
import { User } from 'src/app/models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  public routePrefix = 'users';

  constructor(private httpService: HttpClientWrapperService) { }

  public getUserFromToken() {
    return this.httpService.getRequest<User>(`${this.routePrefix}/fromToken`);
  }

  public copyUser({email, firstName, lastName, id }: User) {
    return {
        firstName,
        email,
        lastName,
        id
    };
}
}
