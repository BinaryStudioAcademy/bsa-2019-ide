import { User } from 'src/app/models/user';
import { AccessTokenDto } from 'src/app/models/token/access-token-dto';

export interface AuthUser {
    user: User;
    token: AccessTokenDto;
}