import { Component, OnInit, Input } from '@angular/core';
import { UserComment } from '../../model/userComment';

@Component({
  selector: 'app-comment-card',
  templateUrl: './comment-card.component.html',
  styleUrls: ['./comment-card.component.sass']
})
export class CommentCardComponent implements OnInit {
    @Input() comment: UserComment;
    constructor() { }

    ngOnInit() {
    }
}
