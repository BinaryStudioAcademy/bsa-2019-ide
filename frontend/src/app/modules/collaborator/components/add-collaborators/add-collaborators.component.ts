import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserNicknameDTO } from '../../../../models/DTO/User/userNicknameDTO';
import { UserService } from 'src/app/services/user.service/user.service';
import { CollaboratorDTO } from 'src/app/models/DTO/User/collaboratorDTO';
import { ProjectService } from 'src/app/services/project.service/project.service';
import { DynamicDialogRef, DynamicDialogConfig } from 'primeng/api';

@Component({
  selector: 'app-add-collaborators',
  templateUrl: './add-collaborators.component.html',
  styleUrls: ['./add-collaborators.component.sass']
})
export class AddCollaboratorsComponent implements OnInit {

    public collaborator: UserNicknameDTO;
    filterCollaborators: UserNicknameDTO[];
    newCollaborators: CollaboratorDTO[];

  constructor(private route: ActivatedRoute,
    private userService: UserService,
    private projectService: ProjectService,
    public config: DynamicDialogConfig,
    public ref: DynamicDialogRef,) { }

  ngOnInit() {
      this.projectService.getProjectCollaborators(11).subscribe(projectCollaborators=>
        this.newCollaborators=projectCollaborators.body);
  }

  public close(): void
  {
    this.ref.close();
  }

  public filterCollarator(event): void {
    const query = event.query;
    this.userService.getUsersNickName().subscribe(collaborator => {
        this.filterCollaborators = this.filter(query, collaborator.body);
    });
}

public checkCollaborator(collaborator: UserNicknameDTO): void {
    this.collaborator=null;
    console.log(collaborator);
    //this.router.navigate([`/project/${project.id}`]);
}

public filter(query, collaborators: UserNicknameDTO[]): UserNicknameDTO[] {
    const filtered: UserNicknameDTO[] = [];
    for (let i = 0; i < collaborators.length; i++) {
        const collaborator = collaborators[i];
        if (collaborator.nickName.toLowerCase().indexOf(query.toLowerCase()) !== -1) {
            filtered.push(collaborator);
        }
    }
    if (filtered.length === 0)
    {
        const notFound:UserNicknameDTO = {
            id:0,
            nickName: "We couldn’t find any project matching " + query
        }
        filtered.push(notFound);
    }
    return filtered;
}

}
