import { Component, OnInit, Input } from '@angular/core';
import { ProjectDescriptionDTO } from 'src/app/models/DTO/Project/projectDescriptionDTO';

@Component({
  selector: 'app-user-pr-card',
  templateUrl: './user-pr-card.component.html',
  styleUrls: ['./user-pr-card.component.sass']
})
export class UserPrCardComponent implements OnInit {

  @Input() project: ProjectDescriptionDTO;


  constructor(){ }

  ngOnInit() {

  }

}
