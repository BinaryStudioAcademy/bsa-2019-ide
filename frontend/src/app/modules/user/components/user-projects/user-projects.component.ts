import { Component, OnInit, Input } from '@angular/core';
import { UserDetailsDTO } from 'src/app/models/DTO/User/userDetailsDTO';
import { ProjectService } from 'src/app/services/project.service/project.service';
import { ProjectDescriptionDTO } from 'src/app/models/DTO/Project/projectDescriptionDTO';
import { ProjectUserPageDTO } from 'src/app/models/DTO/Project/projectUserPageDTO';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
    selector: 'app-user-projects',
    templateUrl: './user-projects.component.html',
    styleUrls: ['./user-projects.component.sass']
})
export class UserProjectsComponent implements OnInit {

    @Input()
    public userId: number;
    @Input()
    public isOwnProject: boolean;
    public projects: ProjectUserPageDTO[] = [];

    constructor(
        private projectService: ProjectService,
        private toastService: ToastrService,
        private router: Router
    ) { }

    ngOnInit() {
        if (this.isOwnProject) {
            this.projectService.getProjectsByUserId(this.userId)
                .subscribe(
                    (resp) => {
                        this.projects = resp.body;
                    },
                    (error) => {
                        this.toastService.error("Can not load user projects", "Error");
                    }
                );
        }
        else {
            this.projectService.getAssignedByUserId(this.userId)
                .subscribe(
                    (resp) => {
                        this.projects = resp.body;
                    },
                    (error) => {
                        this.toastService.error("Can not load user projects", "Error");
                    }
                );
        }
    }

    public goToProjectDetails(project: ProjectUserPageDTO) {
        this.router.navigate([`project/${project.id}`]);
    }

    public getUserAccess(number: number) {
        switch (number) {
            case 1:
                return "Can edit"
            case 2:
                return "can edit and build"
            case 3:
                return "Provide all access rights"
            default:
                return "Can read"
        }
    }

}
