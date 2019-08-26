import { Component, OnInit } from '@angular/core';

export interface ProjStat {
    userId: string,
    userName: string,
    updatedFiles: number,
    createdFiles:  number,
    successBuilds: number
}

@Component({
    selector: 'app-project-details-user-statistics',
    templateUrl: './project-details-user-statistics.component.html',
    styleUrls: ['./project-details-user-statistics.component.sass']
})
export class ProjectDetailsUserStatisticsComponent implements OnInit {

    public usersData: ProjStat[];
    public cols: any[];
    constructor() { }

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
       this.cols = [
        { field: 'userName', header: 'User name' },
        { field: 'updatedFiles', header: 'Updated files' },
        { field: 'createdFiles', header: 'Created files' },
        { field: 'successBuilds', header: 'Successful builds' }
    ];
        this.usersData = [
            { userId : "1", userName : "username", updatedFiles : 2, createdFiles : 3, successBuilds: 4},
            { userId : "1", userName : "username", updatedFiles : 2, createdFiles : 3, successBuilds: 2}
        ]
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