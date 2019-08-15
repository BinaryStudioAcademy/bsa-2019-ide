import { HttpClientWrapperService } from './../../../../services/http-client-wrapper.service';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { InfoService } from 'src/app/services/info.service/info.service';
import { LikedProjectsInLanguageDTO } from 'src/app/models/DTO/Project/likedProjectsInLanguageDTO';

@Component({
  selector: 'app-landing-root',
  templateUrl: './landing-root.component.html',
  styleUrls: ['./landing-root.component.sass']
})
export class LandingRootComponent implements OnInit {
    menuItems: { name: string, url?: string }[];
    shownProjects: LikedProjectsInLanguageDTO;
    allLikedProjects: LikedProjectsInLanguageDTO[];
    smthWrong = true;
    constructor( private infoService: InfoService) { }
    active: number;

    ngOnInit() {
        this.menuItems = [
            { name: 'C#', url: 'https://static2.tgstat.com/public/images/channels/_0/cd/cdeed628be15b12e5f376ed6432d0dfb.jpg' },
            { name: 'TypeScript', url: 'https://pbs.twimg.com/profile_images/1149708719178993664/3Hb8W4aX.png' },
            { name: 'JavaScript', url: 'https://seeklogo.com/images/N/nodejs-logo-FBE122E377-seeklogo.com.png' },
            { name: 'Go', url: 'https://miro.medium.com/max/1200/1*yh90bW8jL4f8pOTZTvbzqw.png' }
        ];
        this.infoService.getMostLikedProjects()
            .subscribe(data => {
                    this.allLikedProjects = data.body;
                    this.smthWrong = false;
                    this.shownProjects = this.allLikedProjects.find(x => x.projectType === 1);
                    this.active = 1;
                }, error => this.smthWrong = true);
    }

    showProjects(i) {
        this.active = i;
        this.shownProjects = this.allLikedProjects.find(x => x.projectType === i);
    }
}
