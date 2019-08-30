import { Component, OnInit, Input } from '@angular/core';
import { ProjectDescriptionDTO } from 'src/app/models/DTO/Project/projectDescriptionDTO';
import { BuildService } from 'src/app/services/build.service/build.service';
import { TokenService } from 'src/app/services/token.service/token.service';
import { BuildDescriptionDTO } from 'src/app/models/DTO/Common/buildDescriptionDTO';

@Component({
    selector: 'app-user-build-history',
    templateUrl: './user-build-history.component.html',
    styleUrls: ['./user-build-history.component.sass']
})
export class UserBuildHistoryComponent implements OnInit {

    @Input()
    public projectId: number;
    public userProjects: ProjectDescriptionDTO[];
    public builds: BuildDescriptionDTO[] = [];
    constructor(
        private buildService: BuildService
    ) { }

    ngOnInit() {
        this.buildService.GetBuildsByProjectId(this.projectId)
            .subscribe(
                (resp) => {
                    console.log(resp.body);
                    this.builds = resp.body;
                },
                (error) => {
                    console.log(error);
                }
            );
    }

}
