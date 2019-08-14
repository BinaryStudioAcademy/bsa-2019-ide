import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, CanActivate } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthenticationService } from '../services/auth.service/auth.service';
import { TokenService } from '../services/token.service/token.service';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class LoginGuard implements CanActivate {

    constructor(private authenticationService: AuthenticationService,
                private tokenService: TokenService) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot)
                : boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
        return this.tokenService.IsAuthorized()
            .pipe(map(loggedIn => {
                return loggedIn;
            }));
    }
}
