import { Component, OnInit, Input, EventEmitter, Output, Injectable } from '@angular/core';
import { CollaboratorDTO } from 'src/app/models/DTO/User/collaboratorDTO';
import { UserAccess } from 'src/app/models/Enums/userAccess';
import { SelectItem } from 'primeng/api';
import { AddCollaboratorsComponent } from '../add-collaborators/add-collaborators.component';
import { ProjectWindowComponent } from '../../../project/components/project-window/project-window.component';

@Component({
    selector: 'app-add-collaborators-list',
    templateUrl: './add-collaborators-list.component.html',
    styleUrls: ['./add-collaborators-list.component.sass']
})

@Injectable()
export class AddCollaboratorsListComponent implements OnInit {

    public selectedAccess: UserAccess
    public userAccess: SelectItem[];
    public label: string;

    @Input() collaborators: CollaboratorDTO[];
    @Input() area: string;

    constructor(
        private addCollaboratorsComponent: AddCollaboratorsComponent,
        private projectSettingComponent: ProjectWindowComponent
    ) { }

    ngOnInit() {
        this.userAccess = [
            { label: 'Can read', value: 0 },
            { label: 'Can edit', value: 1 },
            { label: 'Can edit and build', value: 2 },
            { label: 'Provide all access rights', value: 3 },
        ];
    }

    public delete(collaboratorId: number): void {
        if(this.area=="workspace")
        {
            this.addCollaboratorsComponent.delete(collaboratorId);
        }
        else{
            this.projectSettingComponent.delete(collaboratorId);
        }
    }
}
