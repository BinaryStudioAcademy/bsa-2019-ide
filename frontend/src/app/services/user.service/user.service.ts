import { Injectable } from '@angular/core';
import { HttpClientWrapperService } from '../http-client-wrapper.service';
import { UserDTO } from 'src/app/models/DTO/User/userDTO';
import { UserDetailsDTO } from 'src/app/models/DTO/User/userDetailsDTO';
import { UserNicknameDTO } from 'src/app/models/DTO/User/userNicknameDTO';
import { Observable } from 'rxjs';
import { HttpResponse } from '@angular/common/http';
import { VerificationTokenDTO } from 'src/app/models/DTO/Common/verificationTokenDTO';
import { EmailDTO } from 'src/app/models/DTO/Common/emailDTO';
import { UserUpdateDTO } from 'src/app/models/DTO/User/userUpdateDTO';
import { ImageUploadBase64DTO } from 'src/app/models/DTO/Image/imageUploadBase64DTO';
import { UserChangePasswordDTO } from 'src/app/models/DTO/User/userChangePasswordDTO';

@Injectable({
    providedIn: 'root'
})
export class UserService {

    public routePrefix = 'users';

    constructor(private httpService: HttpClientWrapperService) { }

    public getUserFromToken() {
        return this.httpService.getRequest<UserDTO>(`${this.routePrefix}/fromToken`);
    }

    public getUsersNickName(): Observable<HttpResponse<UserNicknameDTO[]>>{
        return this.httpService.getRequest<UserNicknameDTO[]>(`${this.routePrefix}/nickname`);
    }

    public getUserDetailsFromToken() {
        return this.httpService.getRequest<UserDetailsDTO>(`${this.routePrefix}/details`);
    }

    public getUserById(id: number) {
        return this.httpService.getRequest<UserDTO>(`${this.routePrefix}`, { id });
    }

    public getUserInformationById(id: number) {
        return this.httpService.getRequest<UserDetailsDTO>(`${this.routePrefix}/${id}`);
    }

    public updateUser(user: UserDTO) {
        return this.httpService.putRequest<UserDTO>(`${this.routePrefix}`, user);
    }

    public updateProfile(user: UserUpdateDTO){
        return this.httpService.putRequest<UserUpdateDTO>(`${this.routePrefix}/profile`, user);
    }

    public confirmEmail(token: VerificationTokenDTO) {
        return this.httpService.putRequest("email", token);
    }

    public recoverPassword(email: EmailDTO) {
        return this.httpService.putRequest("email/recover", email);
    }

    public updateProfilePhoto(image:ImageUploadBase64DTO){
        return this.httpService.putRequest(`${this.routePrefix}/photo`, image);
    }

    public deleteProfilePhoto(){
        return this.httpService.deleteRequest(`${this.routePrefix}/photo/del`);
    }

    public updatePassword(pass:UserChangePasswordDTO){
        return this.httpService.putRequest(`${this.routePrefix}/password`, pass);
    }

    public copyUser({ email, firstName, lastName, id, nickName }: UserDTO) {
        return {
            firstName,
            email,
            lastName,
            id,
            nickName
        };
    }
}
