import { Component, OnInit, Input } from '@angular/core';
import { getLocaleDateTimeFormat } from '@angular/common';
import { ProjectInfoDTO } from 'src/app/models/DTO/Project/projectInfoDTO';
import { AuthenticationService } from 'src/app/services/auth.service/auth.service';
import { AccessModifier } from 'src/app/models/Enums/accessModifier';
import { UserDTO } from 'src/app/models/DTO/User/userDTO';

@Component({
  selector: 'app-project-details-info',
  templateUrl: './project-details-info.component.html',
  styleUrls: ['./project-details-info.component.sass']
})
export class ProjectDetailsInfoComponent implements OnInit {
   
    private authorId;

    @Input() project: ProjectInfoDTO;

    constructor(private authService:AuthenticationService) { }
    
    ngOnInit(): void {
        this.authService.getUser().subscribe((user:UserDTO)=>{
            this.authorId = user.id;
        });
    }

    IsAuthor():boolean{
        return this.authorId == this.project.authorId? true : false;
    }

    IsPublic():boolean{
        return this.project.accessModifier==AccessModifier.public? true : false;
    }
}
