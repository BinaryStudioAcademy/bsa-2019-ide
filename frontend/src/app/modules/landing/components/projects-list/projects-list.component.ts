import { Component, OnInit, Input } from '@angular/core';
import { LikedProjectDTO } from 'src/app/models/DTO/Project/likedProjectDTO';

@Component({
  selector: 'app-projects-list',
  templateUrl: './projects-list.component.html',
  styleUrls: ['./projects-list.component.sass']
})
export class ProjectsListComponent implements OnInit {
    @Input() projects: LikedProjectDTO[];
    constructor() { }

    ngOnInit() {
    }

}
