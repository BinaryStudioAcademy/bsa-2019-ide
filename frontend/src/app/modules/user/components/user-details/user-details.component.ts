import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service/user.service';
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
  constructor(private userService: UserService) { }

  ngOnInit() {
      this.user = this.userService.getUserDetails();
  }
  expandImage(imageUrl : string){
      this.isImageExpended = true;
      console.log(imageUrl);
  }
  colapseImage(){
      this.isImageExpended = false;
  }
}
