import { Component, OnInit, Input, EventEmitter, Output, Injectable } from '@angular/core';
import { CollaboratorDTO } from 'src/app/models/DTO/User/collaboratorDTO';
import { UserAccess } from 'src/app/models/Enums/userAccess';
import { SelectItem } from 'primeng/api';
import { AddCollaboratorsComponent } from '../add-collaborators/add-collaborators.component';
import { ProjectSettingsComponent} from '../../../project/components/project-settings/project-settings.component';

@Component({
    selector: 'app-add-collaborators-list',
    templateUrl: './add-collaborators-list.component.html',
    styleUrls: ['./add-collaborators-list.component.sass']
})

@Injectable()
export class AddCollaboratorsListComponent implements OnInit {

    selectedAccess: UserAccess
    userAccess: SelectItem[];
    label: string;

    @Input() collaborators: CollaboratorDTO[];
    @Input() area: string;
    @Output() onChanged = new EventEmitter<CollaboratorDTO[]>();

    constructor(
        private addCollaboratorsComponent: AddCollaboratorsComponent,
        private projectSettingComponent: ProjectSettingsComponent
    ) { }

    ngOnInit() {
        this.userAccess = [
            { label: 'Can read', value: 0 },
            { label: 'Can write', value: 1 },
            { label: 'Can build', value: 2 },
            { label: 'Can run', value: 3 },
        ];
    }

    public delete(collaboratorId: number): void {
        console.log(this.area);
        if(this.area=="workspace")
        {
            this.addCollaboratorsComponent.delete(collaboratorId);
        }
        else{
            this.projectSettingComponent.delete(collaboratorId);
        }
    }

    // public change() {
    //     this.onChanged.emit(this.collaborators);
    // }

    public getUserAccess(user: CollaboratorDTO): SelectItem {
        switch (user.access) {
            case 0:
                this.label = "Can read"
                break;
            case 1:
                this.label = "Can write"
                break;
            case 2:
                this.label = "Can build"
                break;
            case 3:
                this.label = "Can run"
                break;
        }
        return { label: this.label, value: user.access };
    }

}