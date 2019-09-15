import { Injectable, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import * as auth0 from 'auth0-js';

import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';

(window as any).global = window;

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  // Create Auth0 web auth instance

  auth0 = new auth0.WebAuth({
    clientID: environment.auth.clientID,
    domain: environment.auth.domain,
    responseType: 'token',
    redirectUri: window.location.href + environment.auth.auth0RedirectUri,
    //sso: false,
    audience: environment.auth.audience,
  });

  // Store authentication data
  expiresAt: number;
  userProfile: any;
  accessToken: string;
  authenticated: boolean;
  isUser: boolean;
  isEmployer: boolean;

  constructor(public router: Router) { }

  public login() {
    this.auth0.authorize();
  }

  // Looks for result of authentication in URL hash; result is processed in parseHash.
  public handleLoginCallback(): Observable<any> {
    return Observable.create(observer => this.auth0.parseHash((err, authResult) => {
      if (authResult && authResult.accessToken) {
        window.location.hash = '';
        this.getUserInfo(authResult).subscribe(x => observer.next(x));
        localStorage.setItem('token', authResult.accessToken);
      } else if (err) {
        console.log(`Error: ${err.error}`);
        console.log('er');
      }
    }));
  }

  getAccessToken() {
    this.auth0.checkSession({}, (err, authResult) => {
      if (authResult && authResult.accessToken) {
        this.getUserInfo(authResult);
      }
    });
  }

  // Use access token to retrieve user's profile and set session
  getUserInfo(authResult): Observable<any> {
    return Observable.create(observer => this.auth0.client.userInfo(authResult.accessToken, (err, profile) => {
      if (profile) {
        this.setSession(authResult, profile);
        console.log(profile);
        observer.next(profile)
      }
    }));
  }

  // Save authentication data and update login status subject
  private setSession(authResult, profile): void {
    this.expiresAt = authResult.expiresIn * 1000 + Date.now();
    this.accessToken = authResult.accessToken;
    this.userProfile = profile;
    this.authenticated = true;
  }

  // Log out of Auth0 session
  // Ensure that returnTo URL is specified in Auth0
  // Application settings for Allowed Logout URLs
  public logout(): void {
    this.auth0.logout({
      returnTo: window.location.href,
      clientID: environment.auth.clientID
    });
  }

  // Checks whether the expiry time for the user's Access Token has passed and that user is signed in locally.
  get isLoggedIn(): boolean {
    return Date.now() < this.expiresAt && this.authenticated;
  }
}
