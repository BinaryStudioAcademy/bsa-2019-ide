import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-comment-card',
  templateUrl: './comment-card.component.html',
  styleUrls: ['./comment-card.component.sass']
})
export class CommentCardComponent implements OnInit {
    @Input() comment: Comment;
    constructor() { }

    ngOnInit() {
    }
}
