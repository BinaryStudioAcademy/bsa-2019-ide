import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service/user.service';
import { MenuItem } from 'primeng/api';
import { UserDetailsDTO } from 'src/app/models/DTO/User/userDetailsDTO';

@Component({
  selector: 'app-user-details',
  templateUrl: './user-details.component.html',
  styleUrls: [
    "./user-details.component.sass"
    ]
})
export class UserDetailsComponent implements OnInit {
  private user : UserDetailsDTO;
  private isImageExpended: boolean = false;
  private actions: MenuItem[];


  constructor(private userService: UserService) { }
  ngOnInit() {
      this.userService.getUserFromToken().subscribe(response =>{
        this.user = response.body;
        console.log(this.user);
      });
      this.actions = [
        {label: 'Change Image', icon: 'pi pi-cloud-upload', command: () => {
            // this.update();
        }},
        {label: 'Delete Image', icon: 'pi pi-trash', command: () => {
            // this.delete();
        }},
        {label: 'Update Info', icon: 'pi pi-refresh', command: () => {
            // this.delete();
        }},
        {label: 'Change password', icon: 'pi pi-key ', command: () => {
            // this.delete();
        }}
    ];
  }
  expandImage(imageUrl : string){
      this.isImageExpended = true;
  }
}
