import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';
import { ProjectInfoDTO } from 'src/app/models/DTO/Project/projectInfoDTO';
import { ActivatedRoute } from '@angular/router';
import { TokenService } from 'src/app/services/token.service/token.service';

@Component({
  selector: 'app-project-details',
  templateUrl: './project-details.component.html',
  styleUrls: ['./project-details.component.sass']
})
export class ProjectDetailsComponent implements OnInit {
    public project: ProjectInfoDTO;
    projectId: number;
    public userId:number;

    constructor(
      private route: ActivatedRoute,
      private tokenService: TokenService
    ) { }

    ngOnInit() {
        this.route.data.subscribe(data => {
            this.project = data['project'];
        });
        this.projectId=this.project.id;
        this.userId=this.tokenService.getUserId();
    }

    public isAuthor()
    {
        return this.project.authorId==this.userId;
    }
}
