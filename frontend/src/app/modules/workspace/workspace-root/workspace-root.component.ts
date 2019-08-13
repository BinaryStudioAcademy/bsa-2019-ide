
import { Component, OnInit } from '@angular/core';
import { ResizeEvent } from 'angular-resizable-element';
import { ActivatedRoute } from '@angular/router';



@Component({
  selector: 'app-workspace-root',
  templateUrl: './workspace-root.component.html',
  styleUrls: ['./workspace-root.component.sass']
})
export class WorkspaceRootComponent implements OnInit {
  public projectId: number;

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.projectId = Number(this.route.snapshot.paramMap.get('id'));
    if (!this.projectId) {
      console.error('Id in URL is not a number!');
      return;
    }
  }


// *********code below for resizing blocks***************
//   public style: object = {};

//   validate(event: ResizeEvent): boolean {
//     const MIN_DIMENSIONS_PX: number = 50;
//     if (
//       event.rectangle.width &&
//       event.rectangle.height &&
//       (event.rectangle.width < MIN_DIMENSIONS_PX ||
//         event.rectangle.height < MIN_DIMENSIONS_PX)
//     ) {
//       return false;
//     }
//     return true;
//   }

//   onResizeEnd(event: ResizeEvent): void {
//     this.style = {
//       position: 'fixed',
//       left: `${event.rectangle.left}px`,
//       top: `${event.rectangle.top}px`,
//       width: `${event.rectangle.width}px`,
//       height: `${event.rectangle.height}px`
//     };
// }
}
