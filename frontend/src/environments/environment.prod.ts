export const environment = {
  production: true,
  apiUrl: '/api/',
  auth: {
    clientID: 'IasXhVfWZoWeKaWhw0E9NB9fpLtv6mnZ',
    domain: 'dev-um9n3nhv.eu.auth0.com', // e.g., you.auth0.com
    audience: 'https://dev-um9n3nhv.eu.auth0.com/api/v2/',
    auth0RedirectUri: 'allback', // URL to return to after auth0 login
    auth0ReturnTo: '', // URL to return to after auth0 logout
    scope: 'openid profile email'
  }
};
