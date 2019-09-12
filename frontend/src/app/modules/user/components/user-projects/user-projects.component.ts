import { Component, OnInit, Input } from '@angular/core';
import { UserDetailsDTO } from 'src/app/models/DTO/User/userDetailsDTO';
import { ProjectService } from 'src/app/services/project.service/project.service';
import { ProjectDescriptionDTO } from 'src/app/models/DTO/Project/projectDescriptionDTO';
import { ProjectUserPageDTO } from 'src/app/models/DTO/Project/projectUserPageDTO';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-user-projects',
  templateUrl: './user-projects.component.html',
  styleUrls: ['./user-projects.component.sass']
})
export class UserProjectsComponent implements OnInit {

    @Input()
    public userId: number;
    @Input()
    public isOwnProject: boolean;
    public projects: ProjectUserPageDTO[]=[];

  constructor(
      private projectService: ProjectService,
      private toastService: ToastrService
  ) { }

  ngOnInit() {
      if(this.isOwnProject)
      {
      this.projectService.getProjectsByUserId(this.userId)
        .subscribe(
            (resp)=>{
                this.projects=resp.body;
            },
            (error)=>{
                this.toastService.error("Can not load user projects", "Error");
            }
        );
    }
    else{
        this.projectService.getAssignedByUserId(this.userId)
        .subscribe(
            (resp)=>{
                this.projects=resp.body;
            },
            (error)=>{
                this.toastService.error("Can not load user projects", "Error");
            }
        );
    }
  }

}
