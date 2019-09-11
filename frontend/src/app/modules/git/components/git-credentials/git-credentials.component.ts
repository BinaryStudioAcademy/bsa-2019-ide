import { Component, OnInit, Input } from '@angular/core';
import { ProjectInfoDTO } from 'src/app/models/DTO/Project/projectInfoDTO';
import { MenuItem } from 'primeng/api';
import { GitDialogService } from 'src/app/services/git-dialog/git-dialog.service';
import { CommandType } from '../../models/commang-type';

@Component({
  selector: 'app-git-credentials',
  templateUrl: './git-credentials.component.html',
  styleUrls: ['./git-credentials.component.sass']
})
export class GitCredentialsComponent implements OnInit {

    @Input() project:ProjectInfoDTO
    commands: MenuItem[];

    constructor(
        private gitDialogService: GitDialogService) { }

    ngOnInit() {
        console.log(this.project);

        this.commands = [
            {label:'Pull', icon: 'pi pi-cloud-download', command: () => {
                this.gitDialogService.show(this.project.id.toString(), CommandType.Pull);
            }},
            {label:'Commit', icon: 'pi pi-plus', command: () => {
                this.gitDialogService.show(this.project.id.toString(), CommandType.Commit);
            }},
            {label:'Push', icon: 'pi pi-cloud-upload', command: () => {
                this.gitDialogService.show(this.project.id.toString(), CommandType.Push);
            }}
        ];
    }

    isCredentials(): boolean{
        return this.project.gitCredential !== null;
    }

    addCredentials(){
        this.gitDialogService.show(this.project.id.toString(), CommandType.Add);
    }
}
