import { ProjectService } from './../../../../services/project.service/project.service';
import { Component, OnInit, Input } from '@angular/core';
import { ProjectInfoDTO } from 'src/app/models/DTO/Project/projectInfoDTO';

export interface ProjStat {
    userId: string,
    userName: string,
    updatedFiles: number,
    createdFiles: number,
    isAuthor: boolean

}

@Component({
    selector: 'app-project-details-user-statistics',
    templateUrl: './project-details-user-statistics.component.html',
    styleUrls: ['./project-details-user-statistics.component.sass']
})
export class ProjectDetailsUserStatisticsComponent implements OnInit {

    @Input() project: ProjectInfoDTO;
    public usersData: ProjStat[];
    public totalFilesNum;
    public cols: any[];
    constructor(private projService: ProjectService) { }


    public OpenUserDetailedPage(Id: number) {
        console.log(Id);
        //here will be redirection to user details page
    }

    ngOnInit() {
        /*
        this.projectSerive.getUserStatistics().subscribe((res) =>
          {
            this.userstatistics = res;
          }, error => {
              this.messageService.error('Couldn`t load users statistics');
            });
        */
        console.log(`project id: ${this.project.id}`);
        //let statData =  this.projService.getUsersOfProjectStatistics(this.project);

        this.projService.getAuthorOfProjectStatistics(this.project).subscribe(res => {
            const { id, name, updatedFiles, createdFiles, totalFilesNum } = res;
            this.totalFilesNum = totalFilesNum;
            this.usersData = [{ userId: id.toString(), userName: name, updatedFiles, createdFiles, isAuthor:true }]
        });
        this.projService.getUsersOfProjectStatistics(this.project).subscribe(res => {
            const statData = res.map(x => (
                {
                    userId: x.id.toString(),
                    userName: x.name,
                    updatedFiles: x.updatedFiles,
                    createdFiles: x.createdFiles,
                    isAuthor:false
                }))
            this.usersData = [...this.usersData, ...statData];
        });
        this.cols = [
            { field: 'userName', header: 'User name' },
            {field: 'isAuthor', header: 'Project Role'},
            { field: 'updatedFiles', header: 'Updated files' },
            { field: 'createdFiles', header: 'Created files' },

        ];
        // this.usersData = [
        //     { userId: "1", userName: "username", updatedFiles: 2, createdFiles: 3,  },
        //     { userId: "1", userName: "username", updatedFiles: 2, createdFiles: 3,  }
        // ]
        // this.userstatistics = [
        //     { id: 1, avatar: 'http://www.dsnews.ua/static/img/s/d/sddefault_771x517.jpg', name: 'Username', codelines: 10, successfulBuilds: 5, failedBuilds: 10 },
        //     { id: 2, avatar: 'http://www.dsnews.ua/static/img/s/d/sddefault_771x517.jpg', name: 'Username', codelines: 10, successfulBuilds: 5, failedBuilds: 10 },
        //     { id: 3, avatar: 'http://www.dsnews.ua/static/img/s/d/sddefault_771x517.jpg', name: 'Username', codelines: 10, successfulBuilds: 5, failedBuilds: 10 },
        //     { id: 4, avatar: 'http://www.dsnews.ua/static/img/s/d/sddefault_771x517.jpg', name: 'Username', codelines: 10, successfulBuilds: 5, failedBuilds: 10 },
        //     { id: 5, avatar: 'http://www.dsnews.ua/static/img/s/d/sddefault_771x517.jpg', name: 'Username', codelines: 10, successfulBuilds: 5, failedBuilds: 10 },
        //     { id: 6, avatar: 'http://www.dsnews.ua/static/img/s/d/sddefault_771x517.jpg', name: 'Username', codelines: 10, successfulBuilds: 5, failedBuilds: 10 }
        // ]
    }
}