import { User } from '../user';
import { AccessTokenDto } from '../token/access-token-dto';

export interface AuthUser {
    user: User;
    token: AccessTokenDto;
}