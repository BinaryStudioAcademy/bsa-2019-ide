import { Injectable } from '@angular/core';
import { AccessTokenDto } from 'src/app/models/token/access-token-dto';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { HttpResponse } from '@angular/common/http';
import { UserRegisterDto } from 'src/app/models/auth/user-register-dto';
import { UserLoginDto } from 'src/app/models/auth/user-login-dto';
import { AuthUser } from 'src/app/models/auth/auth-user';
import { HttpService } from '../http.service/http.service';
import { User } from 'src/app/models/user';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  private user: User;

  constructor(private httpService: HttpService,) { }

  public register(user: UserRegisterDto) {
    return this._handleAuthResponse(this.httpService.postFullRequest<AuthUser>(`/register`, user));
}

public setUser(user: User) {
  this.user = user;
  //this.eventService.userChanged(user);
}

public login(user: UserLoginDto) {
    return this._handleAuthResponse(this.httpService.postFullRequest<AuthUser>(`/auth/login`, user));
}

public logout() {
    this.revokeRefreshToken();
    this.removeTokensFromStorage();
    this.user = undefined;
    //this.eventService.userChanged(undefined);
}

public areTokensExist() {
    return localStorage.getItem('accessToken') && localStorage.getItem('refreshToken');
}

public revokeRefreshToken() {
    return this.httpService.postFullRequest<AccessTokenDto>(`token/revoke`, {
        refreshToken: localStorage.getItem('refreshToken')
    });
}

public removeTokensFromStorage() {
    localStorage.removeItem('accessToken');
    localStorage.removeItem('refreshToken');
}

public refreshTokens() {
    return this.httpService
        .postFullRequest<AccessTokenDto>(`token/refresh`, {
            accessToken: JSON.parse(localStorage.getItem('accessToken')),
            refreshToken: JSON.parse(localStorage.getItem('refreshToken'))
        })
        .pipe(
            map((resp) => {
                this._setTokens(resp.body);
                return resp.body;
            })
        );
}

private _handleAuthResponse(observable: Observable<HttpResponse<AuthUser>>) {
    return observable.pipe(
        map((resp) => {
            this._setTokens(resp.body.token);
            this.user = resp.body.user;
            //this.eventService.userChanged(resp.body.user);
            return resp.body.user;
        })
    );
}

private _setTokens(tokens: AccessTokenDto) {
    if (tokens && tokens.accessToken && tokens.refreshToken) {
        localStorage.setItem('accessToken', JSON.stringify(tokens.accessToken.token));
        localStorage.setItem('refreshToken', JSON.stringify(tokens.refreshToken));
        //this.getUser();
    }
}
}
