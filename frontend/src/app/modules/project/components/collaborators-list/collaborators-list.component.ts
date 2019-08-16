import { Component, OnInit, Input } from '@angular/core';
import { UserNicknameDTO } from 'src/app/models/DTO/User/userNicknameDTO';

@Component({
  selector: 'app-collaborators-list',
  templateUrl: './collaborators-list.component.html',
  styleUrls: ['./collaborators-list.component.sass']
})
export class CollaboratorsListComponent implements OnInit {

  @Input() collaborators: UserNicknameDTO[];
  constructor() { }

  ngOnInit() {
  }

}
