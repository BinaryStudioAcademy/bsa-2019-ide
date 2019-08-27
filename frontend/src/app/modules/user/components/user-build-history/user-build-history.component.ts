import { Component, OnInit, Input } from '@angular/core';
import { ProjectDescriptionDTO } from 'src/app/models/DTO/Project/projectDescriptionDTO';
import { BuildDTO } from 'src/app/models/DTO/Common/buildDTO';
import { BuildService } from 'src/app/services/build.service/build.service';
import { TokenService } from 'src/app/services/token.service/token.service';
import { BuildDescriptionDTO } from 'src/app/models/DTO/Common/buildDescriptionDTO';

@Component({
    selector: 'app-user-build-history',
    templateUrl: './user-build-history.component.html',
    styleUrls: ['./user-build-history.component.sass']
})
export class UserBuildHistoryComponent implements OnInit {


    public userProjects: ProjectDescriptionDTO[];
    public builds: BuildDescriptionDTO[] = [];
    public userId: number;
    constructor(
        private buildService: BuildService,
        private tokenService: TokenService
    ) { }

    ngOnInit() {
        this.userId = this.tokenService.getUserId();
        this.buildService.GetBuildsByUserId(this.userId)
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
