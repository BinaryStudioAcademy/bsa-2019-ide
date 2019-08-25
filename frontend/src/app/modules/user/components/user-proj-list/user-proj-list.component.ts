import { Component, OnInit, Input } from '@angular/core';
import { ProjectService } from 'src/app/services/project.service/project.service';
import { ProjectUserPageDTO } from 'src/app/models/DTO/Project/projectUserPageDTO';

@Component({
  selector: 'app-user-proj-list',
  templateUrl: './user-proj-list.component.html',
  styleUrls: ['./user-proj-list.component.sass']
})
export class UserProjListComponent implements OnInit {

  @Input() userId:number;
  public mprojects: ProjectUserPageDTO[];
  public aprojects: ProjectUserPageDTO[];

  constructor(private projectService:ProjectService) { }

  ngOnInit() {
    this.projectService.getProjectsByUserId(this.userId)
    .subscribe(resp => {
        this.mprojects = resp.body;
    }, error =>{
        console.log('can`t load projects');
    });

    this.projectService.getAssignedByUserId(this.userId)
    .subscribe(resp => {
        this.aprojects = resp.body;
    }, error =>{
        console.log('can`t load projects');
    });
  }

}
