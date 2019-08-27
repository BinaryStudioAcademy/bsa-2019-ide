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

    @Input() public project: ProjectInfoDTO;
    public usersData: ProjStat[];
    public totalFilesNum: number;
    public cols: any[];
    constructor(private projService: ProjectService) { }


    public OpenUserDetailedPage(Id: number) {
        console.log(Id);
        
    }

    ngOnInit() {
       

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
        
    }
}