import { HttpClientWrapperService } from './../../../../services/http-client-wrapper.service';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { InfoService } from 'src/app/services/info.service/info.service';
import { LikedProjectsInLanguageDTO } from 'src/app/models/DTO/Project/likedProjectsInLanguageDTO';
import { WebSiteInfo } from 'src/app/models/DTO/Common/webSiteInfo';

@Component({
  selector: 'app-landing-root',
  templateUrl: './landing-root.component.html',
  styleUrls: ['./landing-root.component.sass']
})
export class LandingRootComponent implements OnInit {
    private MAX_DESCRIPTION_LENGTH = 47;
    menuItems: { name: string, url?: string }[];
    shownProjects: LikedProjectsInLanguageDTO;
    allLikedProjects: LikedProjectsInLanguageDTO[];
    smthWrong = true;
    noInfo = true;
    constructor( private infoService: InfoService) { }
    active: number;
    websiteInfo: WebSiteInfo;

    ngOnInit() {
        this.menuItems = [
            { name: 'C#', url: 'https://static2.tgstat.com/public/images/channels/_0/cd/cdeed628be15b12e5f376ed6432d0dfb.jpg' },
            { name: 'TypeScript', url: 'https://pbs.twimg.com/profile_images/1149708719178993664/3Hb8W4aX.png' },
            { name: 'JavaScript', url: 'https://seeklogo.com/images/N/nodejs-logo-FBE122E377-seeklogo.com.png' },
            { name: 'Go', url: 'https://miro.medium.com/max/1200/1*yh90bW8jL4f8pOTZTvbzqw.png' }
        ];
        this.infoService.getMostLikedProjects()
            .subscribe(data => {
                    this.allLikedProjects = this.makeDescriptionShorter(data.body);
                    this.smthWrong = false;
                    this.shownProjects = this.allLikedProjects.find(x => x.projectType === 1);
                    this.active = 1;
                }, error => this.smthWrong = true);
        this.infoService.getWebSiteStats()
            .subscribe(data => {
                console.log(data.body)
                this.websiteInfo = data.body;
                this.noInfo = false;
            }, error => this.noInfo = true);
    }

    showProjects(i) {
        this.active = i;
        this.shownProjects = this.allLikedProjects.find(x => x.projectType === i);
    }

    private makeDescriptionShorter(projects: LikedProjectsInLanguageDTO[]) {
        const MAX_LENGTH = this.MAX_DESCRIPTION_LENGTH + 3;
        projects.forEach(element => {
            element.likedProjects.forEach(project => {
                if (project.projectDescription.length > MAX_LENGTH) {
                    project.projectDescription = project.projectDescription.substr(0, this.MAX_DESCRIPTION_LENGTH) + '...';
                }
            });
        });
        return projects;
    }
}
