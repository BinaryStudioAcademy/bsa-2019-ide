export const environment = {
  production: true,
  apiUrl: '/api/',
  auth: {
    clientID: 'oDlrdb7kNboqqGbWPMzZvlxgHQul87Nh',
    domain: 'bsa-ide.eu.auth0.com', // e.g., you.auth0.com
    audience: 'https://bsa-ide.eu.auth0.com/api/v2/',
    auth0RedirectUri: 'callback', // URL to return to after auth0 login
    auth0ReturnTo: '', // URL to return to after auth0 logout
    scope: 'openid profile email'
  }
};
