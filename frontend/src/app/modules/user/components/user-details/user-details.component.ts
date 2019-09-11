import { Component, OnInit, ViewChild } from '@angular/core';
import { UserService } from 'src/app/services/user.service/user.service';
import { MenuItem, ConfirmationService } from 'primeng/api';
import { UserDetailsDTO } from 'src/app/models/DTO/User/userDetailsDTO';
import { UserDialogType } from '../models/project-dialog-type';
import { UserDetailsDialogService } from 'src/app/services/user-dialog/user-details-dialog.service';
import { ImageCropperComponent, ImageCroppedEvent } from 'ngx-image-cropper';
import { ImageUploadBase64DTO } from 'src/app/models/DTO/Image/imageUploadBase64DTO';
import { ToastrService } from 'ngx-toastr';
import { TokenService } from 'src/app/services/token.service/token.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-user-details',
  templateUrl: './user-details.component.html',
  styleUrls: [
    "./user-details.component.sass"
    ]
})
export class UserDetailsComponent implements OnInit {
  user : UserDetailsDTO;
  image : ImageUploadBase64DTO;
  isImageExpended: boolean = false;
  isUserPage: boolean = false;
  actions: MenuItem[];
  public showEditorSettings=false;

  imageChangedEvent: any = '';
  croppedImage: any = '';
  selected: boolean = false;
  showCropper: boolean = false;
  hasDetailsSaveResponse: boolean = false;

  @ViewChild(ImageCropperComponent, null) imageCropper: ImageCropperComponent;

  isChangeAvatar = false;
  
  constructor(
      private userService: UserService,
      private tokenService: TokenService,
      private activateRoute: ActivatedRoute,
      private toastrService: ToastrService,
      private confirmationService: ConfirmationService,
      private userDialogService: UserDetailsDialogService) { }

  ngOnInit() {
      
      let id = this.activateRoute.snapshot.params['id'];

      this.userService.getUserInformationById(id).subscribe(response =>{
        this.user = response.body;
        this.isUserPage= id == this.tokenService.getUserId()? true : false;

        if (!this.user.url){
            this.user.url = './assets/img/user-default-avatar.png';
        }

        if(this.user.birthday.toString()=='0001-01-01T00:00:00')
        {
            this.user.birthday=null;
        }
      });
     
      this.actions = [
        {label: 'Change Image', icon: 'pi pi-cloud-upload', command: () => {
            this.userPhotoUpdate();
        }},
        {label: 'Delete Image', icon: 'pi pi-trash', command: () => {
            this.confirm();
        }},
        {label: 'Update Info', icon: 'pi pi-refresh', command: () => {
            this.userInfoUpdate();
        }},
        {label: 'Change password', icon: 'pi pi-key ', command: () => {
            this.userPasswordUpdate();
        }}
    ];
  }

  public confirm() {
    this.confirmationService.confirm({
        message: 'Do you want to remove your avatar?',
        header: 'Delete Confirmation',
        icon: 'pi pi-info-circle',
        accept: () => {
            this.DeleteProfilePhoto();
        },
        reject: () => {
            this.toastrService.info("Ok, your avatar won`t be removed");
        }
    });
}

  public showEditorSettingsForUser()
  {
      this.showEditorSettings=!this.showEditorSettings;
  }
  expandImage(imageUrl : string){
      this.isImageExpended = true;
  }

  public userPhotoUpdate(){
      this.isChangeAvatar = true;
  }

  public userInfoUpdate() {
    this.userDialogService.show(UserDialogType.UpdateInfo);
}

  public userPasswordUpdate() {
    this.userDialogService.show(UserDialogType.UpdatePassword);
  }

  fileChangeEvent($event){
    this.imageChangedEvent = event;
  }

  imageCropped(event: ImageCroppedEvent) {
    this.image = {base64: event.base64};
    this.selected = true;
  }

  public close() {
    this.isChangeAvatar = false;
    }

  imageLoaded() {
    this.showCropper = true;
  }

  loadImageFailed () {
    this.toastrService.error("An error occured while uploading photo");
  }

  UpdateProfilePhoto(event){
    this.hasDetailsSaveResponse = true;
    this.userService.updateProfilePhoto(this.image).subscribe(resp =>{
        this.toastrService.success('photo successfully updated');
        this.hasDetailsSaveResponse = false;
        this.isChangeAvatar = false;
        this.showCropper = false;
        this.selected = false;
        this.ngOnInit();
    },error =>{
        this.toastrService.error('can`t update photo');
    });
  }

  DeleteProfilePhoto(){
    this.userService.deleteProfilePhoto().subscribe(resp =>{
        this.toastrService.success('photo successfully deleted');
        this.ngOnInit();
    },error =>{
        this.toastrService.error('can`t delete photo');
    });
  }

}
