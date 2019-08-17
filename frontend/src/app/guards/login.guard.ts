import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, CanActivate, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { TokenService } from '../services/token.service/token.service';
import { map } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class LoginGuard implements CanActivate {

    constructor(
        private tokenService: TokenService,
        private toastService: ToastrService,
        private router: Router
    ) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot)
                : boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
        return this.tokenService.IsAuthorized()
            .pipe(map(loggedIn => {
                if (!loggedIn) {
                    this.toastService.error("Please log in.","Access denied!")
                    this.router.navigate(['/']);
                }
                return loggedIn;
            }));
    }
}
