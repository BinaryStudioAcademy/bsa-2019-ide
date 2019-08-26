import { Component, OnInit, Input } from '@angular/core';
import { ProjectUserPageDTO } from 'src/app/models/DTO/Project/ProjectUserPageDTO';

@Component({
  selector: 'app-user-pr-card',
  templateUrl: './user-pr-card.component.html',
  styleUrls: ['./user-pr-card.component.sass']
})
export class UserPrCardComponent implements OnInit {

  @Input() project: ProjectUserPageDTO;


  constructor(){ }

  ngOnInit() {

  }

}
