import { Component, OnInit } from '@angular/core';
import { InfoService } from 'src/app/services/info.service/info.service';
import { WebSiteInfo } from 'src/app/models/DTO/Common/webSiteInfo';
import { AuthDialogService } from 'src/app/services/auth-dialog.service/auth-dialog.service';
import { DialogType } from 'src/app/modules/authorization/models/auth-dialog-type';
import { UserComment } from '../../model/userComment';
import { LikedProjectDTO } from 'src/app/models/DTO/Project/likedProjectDTO';
import { FileService } from 'src/app/services/file.service/file.service';
import { FilesRestrictionsDTO } from 'src/app/models/DTO/File/filesRestrictionsDTO';

@Component({
    selector: 'app-landing-root',
    templateUrl: './landing-root.component.html',
    styleUrls: ['./landing-root.component.sass']
})
export class LandingRootComponent implements OnInit {
    private MAX_DESCRIPTION_LENGTH = 197;
    menuItems: { name: string, url?: string }[];
    likedProjects: LikedProjectDTO[];
    smthWrong = true;
    noInfo = true;

    constructor(private infoService: InfoService,
        private authDialogService: AuthDialogService,
        private fileService: FileService) { }

    active: number;
    websiteInfo: WebSiteInfo;
    comments: UserComment[];

    public filesRestrictions: FilesRestrictionsDTO;

    ngOnInit() {
        this.menuItems = [
            { name: 'C#', url: 'https://static2.tgstat.com/public/images/channels/_0/cd/cdeed628be15b12e5f376ed6432d0dfb.jpg' },
            { name: 'TypeScript', url: 'https://pbs.twimg.com/profile_images/1149708719178993664/3Hb8W4aX.png' },
            { name: 'JavaScript', url: 'https://seeklogo.com/images/N/nodejs-logo-FBE122E377-seeklogo.com.png' },
            { name: 'Go', url: 'https://miro.medium.com/max/1200/1*yh90bW8jL4f8pOTZTvbzqw.png' }
        ];

        this.comments = [
            {
                nickName: "Chloe Hughes",
                userLogo: "https://i2.wp.com/therighthairstyles.com/wp-content/uploads/2014/03/8-choppy-collarbone-cut.jpg?zoom=2.625&resize=392%2C392&ssl=1",
                comment: "Great IDE. From the first minute of work I fell in love with its interface and ease of use. But in spite of its simplicity, it is functional enough to contain everything that I and my team needed to develop our project. In the future I will use it and advise my friends. Special thanks for being able to modify user rights, as this has helped us avoid unwanted errors."
            },
            {
                nickName: "Scarlett Taylor",
                userLogo: "https://www.byrdie.com/thmb/2GjM8wfjyf_SYPaoKBS7BUwtog0=/700x700/filters:no_upscale():max_bytes(150000):strip_icc()/cdn.cliqueinc.com__cache__posts__203689__model-no-makeup-beauty-203689-1498178880204-main.700x0c-f5d1127548db42d8b690deeaf4cb7efd.jpg",
                comment: "I decided to try this ide because I heard a lot of good things about her. The first thing I want to praise is this wonderful landing page, at first glance, you can understand that the work was done qualitatively and makes you want to know what the rest of the application looks like. Also a pretty good interface and a lot of cool features that I haven't encountered in others ides)"
            },
            {
                nickName: "Bleiz Evans",
                userLogo: "https://images.squarespace-cdn.com/content/v1/5b8d399350a54f309702e849/1536812643965-5V7TRGGBJI77XNYVANAS/ke17ZwdGBToddI8pDm48kP06O0_IHyRXSOOiqwgWaApZw-zPPgdn4jUwVcJE1ZvWEtT5uBSRWt4vQZAgTJucoTqqXjS3CfNDSuuf31e0tVEHLRkg2cosQUGLeQ33UzXdgIxPDaVwE3LlEpL74qP4JVW4jCyXLPvvdR287iymYt8/biokris-600x601-300x300.jpg?format=300w",
                comment: "For a long time I could not find a suitable ide for myself until I met this one. She is really wonderful. It contains everything I needed and even a little more)) It is easy to use and the user-friendly interface is one of its few advantages over other ides I worked on. And I can't help but notice the opportunity for collaboration with other users."
            }
        ]

        this.infoService.getMostLikedProjects()
            .subscribe(data => {
                this.likedProjects = this.makeDescriptionShorter(data.body);
                this.smthWrong = false;
                this.active = 1;
            }, error => this.smthWrong = true);
        this.infoService.getWebSiteStats()
            .subscribe(data => {
                this.websiteInfo = data.body;
                this.noInfo = false;
            }, error => this.noInfo = true);

        this.fileService.getRestrictions()
            .subscribe(response => {
                console.log(response.body);
                this.filesRestrictions = response.body;
            })
    }

    public Authorize() {
        this.authDialogService.openAuthDialog(DialogType.SignUp);
    }

    public OnProjectCardClick(project: LikedProjectDTO) {
        this.authDialogService.openAuthDialog(DialogType.SignIn, project.projectId);
    }

    private makeDescriptionShorter(projects: LikedProjectDTO[]) {
        const MAX_LENGTH = this.MAX_DESCRIPTION_LENGTH + 3;
        projects.forEach(project => {
            if (project.projectDescription.length > MAX_LENGTH) {
                project.projectDescription = project.projectDescription.substr(0, this.MAX_DESCRIPTION_LENGTH) + '...';
            }
        });
        return projects;
    }
}
