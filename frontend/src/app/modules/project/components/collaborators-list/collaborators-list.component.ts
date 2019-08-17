import { Component, OnInit, Input,EventEmitter,Output } from '@angular/core';
import { CollaboratorDTO } from 'src/app/models/DTO/User/collaboratorDTO';
import { UserAccess } from 'src/app/models/Enums/userAccess';
import { SelectItem } from 'primeng/api';

@Component({
    selector: 'app-collaborators-list',
    templateUrl: './collaborators-list.component.html',
    styleUrls: ['./collaborators-list.component.sass']
})
export class CollaboratorsListComponent implements OnInit {

    selectedAccess: UserAccess
    userAccess: SelectItem[];
    label: string;

    @Input() collaborators: CollaboratorDTO[];
    @Output() onChanged = new EventEmitter<CollaboratorDTO[]>();

    constructor() { }

    public change() {
        this.onChanged.emit(this.collaborators);
    }

    ngOnInit() {
        this.userAccess = [
            { label: 'Can read', value: 0 },
            { label: 'Can write', value: 1 },
            { label: 'Can build', value: 2 },
            { label: 'Can run', value: 3 },
        ];
    }

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
        return { label:this.label,value:user.access};
    }

}
