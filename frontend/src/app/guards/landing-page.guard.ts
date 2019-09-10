import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router, CanActivate } from '@angular/router';
import { Observable } from 'rxjs';
import { TokenService } from '../services/token.service/token.service';
import { map } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class LandingPageGuard implements CanActivate {

    constructor(
        private tokenService: TokenService,
        private router: Router
    ) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot)
        : boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
        return this.tokenService.IsAuthorized()
            .pipe(map(loggedIn => {
                if (loggedIn) {
                    this.router.navigate(['/dashboard']);
                }
                return !loggedIn;
            }));
    }
}
