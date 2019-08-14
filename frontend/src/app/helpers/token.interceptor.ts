import { Injectable, Injector } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpSentEvent, HttpHeaderResponse,
     HttpProgressEvent, HttpUserEvent, HttpResponse, HttpErrorResponse, HttpEvent } from '@angular/common/http';
import { TokenService } from '../services/token.service/token.service';
import { BehaviorSubject, Observable, throwError } from 'rxjs';
import { catchError, switchMap, finalize, filter, take } from 'rxjs/operators';
import { AccessTokenDTO } from '../models/DTO/Authentification/accessTokenDTO';


@Injectable()
export class RefreshTokenInterceptor implements HttpInterceptor {

  constructor(private injector: Injector) { }

  isRefreshingToken = false;
  tokenSubject: BehaviorSubject<string> = new BehaviorSubject<string>(null);

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        console.log(request);
        return next.handle(request).pipe(
            catchError(error => {
                const tokenService = this.injector.get(TokenService);
                if (error.status === 400) {
                    tokenService.logout();
                    return throwError(error);
                }
                if (error.status !== 401) {
                    return throwError(error);
                }
                if (request.url.includes('refresh') ||
                    request.url.includes('revoke') ||
                    request.url.includes('login')) {
                    if (request.url.includes('refreshtoken')) {
                        tokenService.logout();
                    }
                    return throwError(error);
                }
                return this.handle401Error(request, next);
            }));
    }

    private handle401Error(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        const tokenService = this.injector.get(TokenService);
        if (!this.isRefreshingToken) {
            this.isRefreshingToken = true;
            this.tokenSubject.next(null);
            return tokenService.refreshTokens()
                .pipe(
                    switchMap((accessToken: AccessTokenDTO) => {
                        this.isRefreshingToken = false;
                        if (accessToken) {
                            this.tokenSubject.next(accessToken.accessToken);
                            return next.handle(request);
                        }
                        tokenService.logout();
                        return throwError(accessToken);
                    }),
                    catchError(err => {
                        this.isRefreshingToken = false;
                        tokenService.logout();
                        return throwError(err);
                    }));
        } else {
            console.log('unrefreshToken');
            this.isRefreshingToken = false;
            return this.tokenSubject
                .pipe(filter(token => token != null),
                take(1),
                switchMap(() => {
                    return next.handle(request);
                }));
        }
    }
}
