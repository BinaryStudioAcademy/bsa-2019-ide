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
import { saveAs } from 'file-saver';

@Component({
    selector: 'app-project-details-info',
    templateUrl: './project-details-info.component.html',
    styleUrls: ['./project-details-info.component.sass']
})
export class ProjectDetailsInfoComponent implements OnInit {
    private authorId: number;

    @Input() project: ProjectInfoDTO;

    constructor(
        private tokenService: TokenService,
        private projectService: ProjectService,
        private router: Router,
        private toastService: ToastrService,
        private projectSettingsService: ProjectDialogService,

    ) { }

    ngOnInit(): void {
        this.authorId = this.tokenService.getUserId();
    }

    IsAuthor(): boolean {
        return this.authorId === this.project.authorId;
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
                console.log(result);
                const blob = new Blob([result.body], {
                    type: 'application/zip'
                });

                saveAs(blob, `${this.project.name}.zip`);
            },
            (error) => {
                 this.toastService.error('Error: can not download', 'Error Message', {tapToDismiss: true});
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
