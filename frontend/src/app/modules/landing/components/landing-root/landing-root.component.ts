import { Component, OnInit } from '@angular/core';
import { InfoService } from 'src/app/services/info.service/info.service';
import { LikedProjectsInLanguageDTO } from 'src/app/models/DTO/Project/likedProjectsInLanguageDTO';
import { WebSiteInfo } from 'src/app/models/DTO/Common/webSiteInfo';
import { AuthDialogService } from 'src/app/services/auth-dialog.service/auth-dialog.service';
import { DialogType } from 'src/app/modules/authorization/models/auth-dialog-type';
import { Comment } from '../../model/comment';

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
    constructor(private infoService: InfoService,
                private authDialogService: AuthDialogService) { }
    active: number;
    websiteInfo: WebSiteInfo;
    comments: Comment[];
    
    ngOnInit() {
        this.menuItems = [
            { name: 'C#', url: 'https://static2.tgstat.com/public/images/channels/_0/cd/cdeed628be15b12e5f376ed6432d0dfb.jpg' },
            { name: 'TypeScript', url: 'https://pbs.twimg.com/profile_images/1149708719178993664/3Hb8W4aX.png' },
            { name: 'JavaScript', url: 'https://seeklogo.com/images/N/nodejs-logo-FBE122E377-seeklogo.com.png' },
            { name: 'Go', url: 'https://miro.medium.com/max/1200/1*yh90bW8jL4f8pOTZTvbzqw.png' }
        ];

        this.comments = [
            {
                nickName: "user1",
                userLogo: "https://cdn2.f-cdn.com/contestentries/1253680/6977519/5a803282619ba_thumb900.jpg",
                comment: "Lorem Ipsum - это текст-\"рыба\", часто используемый в печати и вэб-дизайне. Lorem Ipsum является стандартной \"рыбой\" для текстов на латинице с начала XVI века. В то время некий безымянный печатник создал большую коллекцию размеров и форм шрифтов, используя Lorem Ipsum для распечатки образцов. Lorem Ipsum не только успешно пережил без заметных изменений пять веков, но и перешагнул в электронный дизайн"
            },
            {
                nickName: "user1",
                userLogo: "https://cdn2.f-cdn.com/contestentries/1253680/6977519/5a803282619ba_thumb900.jpg",
                comment: "Lorem Ipsum - это текст-\"рыба\", часто используемый в печати и вэб-дизайне. Lorem Ipsum является стандартной \"рыбой\" для текстов на латинице с начала XVI века. В то время некий безымянный печатник создал большую коллекцию размеров и форм шрифтов, используя Lorem Ipsum для распечатки образцов. Lorem Ipsum не только успешно пережил без заметных изменений пять веков, но и перешагнул в электронный дизайн"
            },
            {
                nickName: "user1",
                userLogo: "https://cdn2.f-cdn.com/contestentries/1253680/6977519/5a803282619ba_thumb900.jpg",
                comment: "Lorem Ipsum - это текст-\"рыба\", часто используемый в печати и вэб-дизайне. Lorem Ipsum является стандартной \"рыбой\" для текстов на латинице с начала XVI века. В то время некий безымянный печатник создал большую коллекцию размеров и форм шрифтов, используя Lorem Ipsum для распечатки образцов. Lorem Ipsum не только успешно пережил без заметных изменений пять веков, но и перешагнул в электронный дизайн"
            }
        ]

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

    public Authorize() {
        this.authDialogService.openAuthDialog(DialogType.SignUp);
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
