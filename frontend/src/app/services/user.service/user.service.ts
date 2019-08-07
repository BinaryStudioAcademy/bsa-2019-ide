import { Injectable } from '@angular/core';
import { HttpService } from 'src/app/services/http.service/http.service';
import { User } from 'src/app/models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  public routePrefix = 'users';

  constructor(private httpService: HttpService) { }

  public getUserFromToken() {
    return this.httpService.getFullRequest<User>(`${this.routePrefix}/fromToken`);
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
