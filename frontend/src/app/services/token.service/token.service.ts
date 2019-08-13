import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AuthenticationService } from '../auth.service/auth.service';

@Injectable({
    providedIn: 'root'
})
export class TokenService {

    constructor(private jwtService: JwtHelperService,
                private authService: AuthenticationService) { }

    IsAuthorized(): boolean {
        const tokenExpired = this.jwtService.isTokenExpired();
        return !tokenExpired;
    }
}

export function TokenGetter() {
    return localStorage.getItem('accessToken');
}
