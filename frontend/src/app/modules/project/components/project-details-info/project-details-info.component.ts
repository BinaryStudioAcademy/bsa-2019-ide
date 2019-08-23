import { HttpClientWrapperService } from './../../../../services/http-client-wrapper.service';
import { Component, OnInit, Input } from '@angular/core';
import { getLocaleDateTimeFormat } from '@angular/common';
import { ProjectInfoDTO } from 'src/app/models/DTO/Project/projectInfoDTO';
import { AccessModifier } from 'src/app/models/Enums/accessModifier';
import { UserDTO } from 'src/app/models/DTO/User/userDTO';
import { TokenService } from 'src/app/services/token.service/token.service';
import { ProjectService } from 'src/app/services/project.service/project.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ProjectDialogService } from 'src/app/services/proj-dialog.service/project-dialog.service';
import { ProjectType } from '../../models/project-type';
import { HttpResponse } from '@angular/common/http';
import { CollaboratorDTO } from 'src/app/models/DTO/User/collaboratorDTO';

@Component({
    selector: 'app-project-details-info',
    templateUrl: './project-details-info.component.html',
    styleUrls: ['./project-details-info.component.sass']
})
export class ProjectDetailsInfoComponent implements OnInit {
    public collaborators: CollaboratorDTO[]=[];
    public startCollaborators: CollaboratorDTO[]=[];
    private authorId: number;

    @Input() project: ProjectInfoDTO;

    constructor(
        private tokenService: TokenService,
        private projectService: ProjectService,
        private router: Router,
        private toastService: ToastrService,
        private projectSettingsService: ProjectDialogService
    ) { }

    ngOnInit(): void {
        this.authorId = this.tokenService.getUserId();
        this.projectService.getProjectCollaborators(this.project.id)
                .subscribe(
                    (resp) => {
                        this.SetCollaboratorsFromResponse(resp);
                    },
                    (error) => {
                        this.toastService.error("'Can\'t load project collaborators.', 'Error Message:'");
                        console.error(error.message);
                    }
                );
    }

    IsAuthor(): boolean {
        return this.authorId === this.project.authorId;
    }

    private SetCollaboratorsFromResponse(resp: HttpResponse<CollaboratorDTO[]>): void {
        this.collaborators = resp.body;
        this.collaborators.forEach(element => {
            let newElement: CollaboratorDTO =
            {
                id: element.id,
                access: element.access,
                nickName: element.nickName
            }
            this.startCollaborators.push(newElement);
        });
    }

    IsPublic(): boolean {
        return this.project.accessModifier === AccessModifier.public;
    }

    getRemovingHeader() {
        return 'Delete project "' + this.project.name + '"?';
    }

    public onTriggerExport() {
        this.projectService.exportProject(this.project.id)
            .subscribe(
            (result) => {
                const keys = result.headers.keys();

                const contentDespoHeader = !!keys.find(x => x == "content-disposition")
                    ? result.headers.get(keys.find(x => x == "content-disposition"))
                    : null;

                const fileName = !!contentDespoHeader
                    ? contentDespoHeader.split(';')[1].trim().split('=')[1] 
                    : "file.zip";

                const blob = new Blob([result.body], {
                    type: 'application/zip'
                });
                const link = document.createElement('a');
                link.href = URL.createObjectURL(blob);
                link.download = fileName;
                link.click();
            },
            (error) => {
                    this.toastService.error("Error: can not download", 'Error');
                    console.log(error);
            });


    }
    remove(event: boolean) {
        if (event) {
            this.projectService.deleteProject(this.project.id)
                .subscribe(
                    (resp) => {
                        this.router.navigate(['/dashboard']);
                        this.toastService.success('Project "' + this.project.name + '" was successfully deleted');
                    },
                    (error) => {
                        this.toastService.error('Please, try again later', 'Ooops, smth goes wrong');
                        console.error(error.message);
                    });
        } else {
        }
    }
    public showSettings() {
        this.projectSettingsService.show(ProjectType.Update, this.project.id);
    }
}
