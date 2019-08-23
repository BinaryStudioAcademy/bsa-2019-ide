import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UserUpdateDTO } from 'src/app/models/DTO/User/userUpdateDTO';
import { UserDialogType } from '../models/project-dialog-type';
import { DynamicDialogRef, DynamicDialogConfig } from 'primeng/api';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { UserDetailsDialogDataService } from 'src/app/services/user-dialog/user-details-dialog-data.service';
import { HttpResponse } from '@angular/common/http';
import { UserDTO } from 'src/app/models/DTO/User/userDTO';
import { UserService } from 'src/app/services/user.service/user.service';
import { TokenService } from 'src/app/services/token.service/token.service';
import { UserDetailsDTO } from 'src/app/models/DTO/User/userDetailsDTO';

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
    
    public userForm: FormGroup;
    
    public isPageLoaded: boolean = false;
    public hasDetailsSaveResponse: boolean = true;

    //public updatePhoto: UserUpdatePhotoDTO;
    public userUpdateInfo: UserUpdateDTO;

    private userUpdateStartState: UserUpdateDTO;
    private userDialogType: UserDialogType;

    constructor(private ref: DynamicDialogRef,
        private config: DynamicDialogConfig,
        private fb: FormBuilder,
        private tokenService: TokenService,
        private userService: UserService,
        private toastrService: ToastrService,
        private dialogService: UserDetailsDialogDataService) { }

  ngOnInit(): void {
        this.userDialogType = this.config.data.userDialogType;
        this.title = this.userDialogType === UserDialogType.UpdateInfo ? 'Edit profile info' : 'Edit profile photo';

        if (this.IsUpdateInfo()) {

            this.userForm = this.fb.group({
                firstName: ['', [Validators.required]],
                lastName: ['', Validators.required],
                nickName: ['', Validators.required],
                gitHubUrl: ['', Validators.required]
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
        } else {
            //update photo
        }
    }

    public userItemIsNotChange(): boolean {
        return this.IsUserNotChange();
    }

    public IsUserNotChange(): boolean {
        return this.userForm.get('firsName').value === this.userUpdateStartState.firstName
        && this.userForm.get('lastName').value === this.userUpdateStartState.lastName
        && this.userForm.get('nickName').value === this.userUpdateStartState.nickName
        && this.userForm.get('gitHubUrl').value === this.userUpdateStartState.gitHubUrl;
    }

    public IsUpdateInfo() {
        return this.userDialogType === UserDialogType.UpdateInfo;
    }

    public onSubmit() {
        if(this.IsUpdateInfo()) {
            this.getValuesForUpdateInfo();
            this.userService.updateUser(this.userUpdateInfo)
                .subscribe(res => {
                        this.toastrService.success("Your profile info was updated");
                        this.hasDetailsSaveResponse = true;
                        this.close();
                    },
                    error => {
                        this.toastrService.error('error');                        
                        this.hasDetailsSaveResponse = true;
                    })
        } else {
            this.hasDetailsSaveResponse = false;
            /*
            if (!this.IsUserNotChange()) {
                this.getValuesForPhotoUpdate();
                this.userService.updatePhoto(this.projectUpdate)
                .subscribe(
                    (resp) => {
                        this.hasDetailsSaveResponse = true;
                        this.toastrService.success('New details have successfully saved!');
                        this.dialogService.addProject(this.projectInfoToProjectDesc(resp.body));
                        this.close();
                    },
                    (error) => {
                        this.hasDetailsSaveResponse = true;
                        this.toastrService.error('Can\'t save new project details', 'Error Message');
                        console.error(error.message);
                    }
                );*/
            }
        }
    
    public close() {
        this.ref.close();
    }
    
    private Initialize(resp: HttpResponse<UserDetailsDTO>) {
        this.userUpdateStartState = resp.body;
        console.log(this.userUpdateStartState);
        this.userForm.patchValue({ 
            firstName: this.userUpdateStartState.firstName,
            lastName: this.userUpdateStartState.lastName,
            nickName: this.userUpdateStartState.nickName,
            gitHubUrl: this.userUpdateStartState.gitHubUrl
        });
    }
    
    private getValuesForUpdateInfo() {
        this.userUpdateInfo = {
            id: this.tokenService.getUserId(),
            firstName: this.userForm.get('firstName').value,
            lastName: this.userForm.get('lastName').value,
            nickName: this.userForm.get('nickName').value,
            gitHubUrl: this.userForm.get('gitHubUrl').value,
        }
    }
}
