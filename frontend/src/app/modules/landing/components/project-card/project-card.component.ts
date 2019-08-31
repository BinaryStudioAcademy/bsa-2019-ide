import { Component, OnInit, Input } from '@angular/core';
import { LikedProjectDTO } from 'src/app/models/DTO/Project/likedProjectDTO';

@Component({
  selector: 'app-project-card',
  templateUrl: './project-card.component.html',
  styleUrls: ['./project-card.component.sass']
})
export class ProjectCardComponent implements OnInit {
    @Input() project: LikedProjectDTO;
    constructor() { }

    ngOnInit() {
    }
}
