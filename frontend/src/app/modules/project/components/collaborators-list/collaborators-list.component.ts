import { Component, OnInit, Input } from '@angular/core';
import { CollaboratorDTO } from 'src/app/models/DTO/User/collaboratorDTO';

@Component({
  selector: 'app-collaborators-list',
  templateUrl: './collaborators-list.component.html',
  styleUrls: ['./collaborators-list.component.sass']
})
export class CollaboratorsListComponent implements OnInit {

  @Input() collaborators: CollaboratorDTO[];
  constructor() { }

  ngOnInit() {
  }

}
