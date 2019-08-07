import { AccessToken } from './access-token';

export interface AccessTokenDto {
    accessToken: AccessToken;
    refreshToken: string;
}