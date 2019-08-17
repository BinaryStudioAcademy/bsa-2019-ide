import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-add-collaborators',
  templateUrl: './add-collaborators.component.html',
  styleUrls: ['./add-collaborators.component.sass']
})
export class AddCollaboratorsComponent implements OnInit {

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
  }

}
