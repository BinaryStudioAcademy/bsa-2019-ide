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
    public getLikesSymbolsByWidth() {
        const width = document.body.offsetWidth;
        if (width >= 1920)
            return 24;
        if (width >= 1500)
            return 18;
        if (width >= 1250)
            return 14;
        if (width >= 1000)
            return 12;
        else 
            return 8;
    }
}
