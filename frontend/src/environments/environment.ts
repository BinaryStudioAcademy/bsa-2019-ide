// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  apiUrl: 'https://localhost:44352/',
  auth: {
    clientID: 'IasXhVfWZoWeKaWhw0E9NB9fpLtv6mnZ',
    domain: 'dev-um9n3nhv.eu.auth0.com', // e.g., you.auth0.com
    audience: 'https://dev-um9n3nhv.eu.auth0.com/api/v2/',
    auth0RedirectUri: 'callback', // URL to return to after auth0 login
    auth0ReturnTo: '', // URL to return to after auth0 logout
    scope: 'openid profile email'
  }
};

/*vscode - apiUrl:'https://localhost:5001'*/
/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
