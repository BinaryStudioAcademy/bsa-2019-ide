import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';
import { ProjectInfoDTO } from 'src/app/models/DTO/Project/projectInfoDTO';
import { ActivatedRoute } from '@angular/router';
import { TokenService } from 'src/app/services/token.service/token.service';
import { EventService } from 'src/app/services/event.service/event.service';

@Component({
    selector: 'app-project-details',
    templateUrl: './project-details.component.html',
    styleUrls: ['./project-details.component.sass']
})
export class ProjectDetailsComponent implements OnInit {
    public project: ProjectInfoDTO;
    public projectId: number;
    public userId: number;

    constructor(
        private route: ActivatedRoute,
        private tokenService: TokenService,
        private eventService: EventService
    ) { }

    ngOnInit() {
        this.route.data.subscribe(data => {
            this.project = data['project'];
            this.eventService.currProjectSwitch({id:this.project.id, name: this.project.name});
        });
        this.projectId = this.project.id;
        this.userId = this.tokenService.getUserId();
    }

    public isAuthor() {
        return this.project.authorId == this.userId;
    }
}
