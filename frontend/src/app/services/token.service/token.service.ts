import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { ReplaySubject, Observable, throwError } from 'rxjs';
import { AccessTokenDTO } from 'src/app/models/DTO/Authentification/accessTokenDTO';
import { map, catchError, share } from 'rxjs/operators';
import { HttpResponse } from '@angular/common/http';
import { AuthUserDTO } from 'src/app/models/DTO/User/authUserDTO';
import { UserRegisterDTO } from 'src/app/models/DTO/User/userRegisterDTO';
import { UserLoginDTO } from 'src/app/models/DTO/User/userLoginDTO';
import { HttpClientWrapperService } from '../http-client-wrapper.service';
import { UserDTO } from 'src/app/models/DTO/User/userDTO';
import { Router } from '@angular/router';

@Injectable({
    providedIn: 'root'
})
export class TokenService {
    private isAuthenticatedSubject = new ReplaySubject<boolean>(1);
    public isAuthenticatedEvent$ = this.isAuthenticatedSubject.asObservable();
    public isLoggedIn = false;

    constructor(private jwtService: JwtHelperService,
                private httpService: HttpClientWrapperService,
                private router: Router) {
                    if (this.areTokensExist()) {
                        this.isAuthenticatedSubject.next(true);
                    } else {
                        this.isAuthenticatedSubject.next(false);
                    }
                }

    public register(user: UserRegisterDTO) {
        return this._handleAuthResponse(this.httpService.postRequest<AuthUserDTO>(`register`, user));
    }

    public login(user: UserLoginDTO) {
        return this._handleAuthResponse(this.httpService.postRequest<AuthUserDTO>(`auth/login`, user));
    }

    IsAuthorized(): Observable<boolean> {
        return this.isAuthenticatedEvent$;
    }

    public logout() {
        this.isAuthenticatedSubject.next(false);
        this._removeTokensFromStorage();
        this._revokeTokens();
        this.router.navigate(['']);
    }

    public areTokensExist() {
        return localStorage.getItem('accessToken') && localStorage.getItem('refreshToken');
    }

    public refreshTokens() {
        return this.httpService.postRequest<AccessTokenDTO>(`token/refresh`, {
                accessToken: JSON.parse(localStorage.getItem('accessToken')),
                refreshToken: JSON.parse(localStorage.getItem('refreshToken'))
            })
            .pipe(
            map(token => {
                this._setTokens(token.body);
                return token.body;
            }));
    }

    public getAccessToken() {
        if (this.areTokensExist()) {
            return localStorage.getItem('accessToken');
        }
    }

    private _handleAuthResponse(observable: Observable<HttpResponse<AuthUserDTO>>) {
        return observable.pipe(
            map((resp) => {
                this._setTokens(resp.body.token);
                this.isLoggedIn = true;
                this.isAuthenticatedSubject.next(this.isLoggedIn);
                return resp.body.user;
            })
        );
    }

    private _setTokens(tokens: AccessTokenDTO) {
        if (tokens) {
            localStorage.setItem('accessToken', JSON.stringify(tokens.accessToken.token));
            localStorage.setItem('refreshToken', JSON.stringify(tokens.refreshToken));
        }
    }
    private _removeTokensFromStorage() {
        localStorage.removeItem('accessToken');
        localStorage.removeItem('refreshToken');
    }
    private _revokeTokens() {
        return this.httpService.postRequest<AccessTokenDTO>(`token/revoke`, {
            refreshToken: localStorage.getItem('refreshToken')
        });
    }

    public getUser(): UserDTO {
        const token = this.jwtService.decodeToken();
        if (token !== null) {
            const user: UserDTO = {
                email: token.email,
                id: token.id,
                firstName: token.firstName,
                lastName: token.lastName,
                nickName: token.nickName,
                photoLink: token.photoUrl
            };
            return user;
        }
        return null;
    }
    public getUserId(): number {
        const token = this.jwtService.decodeToken();
        if (token !== null) {
            return token.id;
        }
        return null;
    }
}

export function TokenGetter() {
    return localStorage.getItem('accessToken');
}
