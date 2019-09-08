import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UserUpdateDTO } from 'src/app/models/DTO/User/userUpdateDTO';
import { UserDialogType } from '../models/project-dialog-type';
import { DynamicDialogRef, DynamicDialogConfig } from 'primeng/api';
import { ToastrService } from 'ngx-toastr';
import { HttpResponse } from '@angular/common/http';
import { UserService } from 'src/app/services/user.service/user.service';
import { TokenService } from 'src/app/services/token.service/token.service';
import { UserDetailsDTO } from 'src/app/models/DTO/User/userDetailsDTO';
import { UserChangePasswordDTO } from 'src/app/models/DTO/User/userChangePasswordDTO';

@Component({
  selector: 'app-user-dialog-window',
  templateUrl: './user-dialog-window.component.html',
  styleUrls: ['./user-dialog-window.component.sass']
})
export class UserDialogWindowComponent implements OnInit {
    public title: string;
    public firstName: string;
    public lastName: string;
    public nickName: string;
    public email: string;
    public gitHubUrl: string;
    public birthday: Date;
    
    public userForm: FormGroup;
    
    public isPageLoaded: boolean = false;
    public hasDetailsSaveResponse: boolean = true;

    public userUpdatePassword: UserChangePasswordDTO;
    public userUpdateInfo: UserUpdateDTO;

    private userUpdateStartState: UserUpdateDTO;
    private userDialogType: UserDialogType;

    constructor(
        private ref: DynamicDialogRef,
        private config: DynamicDialogConfig,
        private fb: FormBuilder,
        private tokenService: TokenService,
        private userService: UserService,
        private toastrService: ToastrService) { }

  ngOnInit(): void {
        this.userDialogType = this.config.data.userDialogType;
        this.title = this.userDialogType === UserDialogType.UpdateInfo ? 'Edit profile info' : 'Change password';

        if (this.isUpdateInfo()) {

            this.userForm = this.fb.group({
                firstName: ['', [Validators.required]],
                lastName: ['', Validators.required],
                nickName: ['', [Validators.required, Validators.maxLength(32)]],
                gitHubUrl: ['', Validators.pattern("^[-a-zA-Z0-9._:\/]+$")],
                birthday: ['']
            });

            this.userService.getUserDetailsFromToken()
                .subscribe(
                    (resp) => {
                        this.Initialize(resp);
                        this.isPageLoaded = true;
                    },
                    (error) => {
                        this.toastrService.error('Can\'t load user details.', 'Error Message:');
                        console.error(error.message);
                    });
        }

        if(this.isUpdatePassword()){
            this.userForm = this.fb.group({
                password: ['', [Validators.required]],
                newPassword: ['', Validators.required],
                repeatPassword: ['', Validators.required]
            }, {validator: this.checkPasswords });

            this.isPageLoaded = true;
        }
    }

    checkPasswords(group: FormGroup) { 
        let pass = group.get('newPassword').value;
        let confirmPass = group.get('repeatPassword').value;
    
        return pass === confirmPass ? null : { notSame: true }     
    }

    public userItemIsNotChange(): boolean {
        return this.IsUserNotChange();
    }

    public IsUserNotChange(): boolean {
        return this.userForm.get('firsName').value === this.userUpdateStartState.firstName
        && this.userForm.get('lastName').value === this.userUpdateStartState.lastName
        && this.userForm.get('nickName').value === this.userUpdateStartState.nickName
        && this.userForm.get('gitHubUrl').value === this.userUpdateStartState.gitHubUrl
        && this.userForm.get('birthday').value === this.userUpdateStartState.birthday;
    }

    public isUpdateInfo() {
        return this.userDialogType === UserDialogType.UpdateInfo;
    }

    public isUpdatePassword(){
        return this.userDialogType === UserDialogType.UpdatePassword;
    }

    public onSubmit() {
        this.hasDetailsSaveResponse = false;

        if(this.isUpdateInfo()) {
            this.getValuesForUpdateInfo();
            this.userService.updateProfile(this.userUpdateInfo)
                .subscribe(res => {
                        this.toastrService.success("Your profile info was successfully updated");
                        this.hasDetailsSaveResponse = true;
                        window.location.reload();
                        this.close();
                    },
                    error => {
                        this.toastrService.error('An error occured while updating the profile');                        
                        this.hasDetailsSaveResponse = true;
                    })
        }
        
        if(this.isUpdatePassword()){
            this.getValuesForUpdatePassword();
            this.userService.updatePassword(this.userUpdatePassword)
            .subscribe(res => {
                this.toastrService.success("Your password was updated");
                this.hasDetailsSaveResponse = true;
                this.close();
            },
            error => {
                this.toastrService.error('Incorrect password');                        
                this.hasDetailsSaveResponse = true;
            })
        }
    }

    public close() {
        this.ref.close();
    }
    
    private Initialize(resp: HttpResponse<UserDetailsDTO>) {
        this.userUpdateStartState = resp.body;
        this.userForm.patchValue({ 
            firstName: this.userUpdateStartState.firstName,
            lastName: this.userUpdateStartState.lastName,
            nickName: this.userUpdateStartState.nickName,
            gitHubUrl: this.userUpdateStartState.gitHubUrl,
            birthday: this.userUpdateStartState.birthday.toString()=='0001-01-01T00:00:00'? null : new Date(this.userUpdateStartState.birthday)
        });//if(this.user.birthday.toString()=='0001-01-01T00:00:00')
    }
    
    private getValuesForUpdateInfo() {
        const birthday = new Date(this.userForm.get('birthday').value);
        this.userUpdateInfo = {
            id: this.tokenService.getUserId(),
            firstName: this.userForm.get('firstName').value,
            lastName: this.userForm.get('lastName').value,
            nickName: this.userForm.get('nickName').value,
            gitHubUrl: this.userForm.get('gitHubUrl').value,
            birthday:  birthday === null ? new Date('0001-01-01T00:00:00') : birthday
        }
        this.userUpdateInfo.birthday.setHours(birthday.getHours()-birthday.getTimezoneOffset()/60);
    }

    private getValuesForUpdatePassword(){
        this.userUpdatePassword = {
            password: this.userForm.get('password').value,
            newPassword: this.userForm.get('newPassword').value
        }
    }
}
