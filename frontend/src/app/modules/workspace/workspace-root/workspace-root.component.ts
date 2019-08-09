
import { Component, OnInit } from '@angular/core';
import { ResizeEvent } from 'angular-resizable-element';
@Component({
  selector: 'app-workspace-root',
  templateUrl: './workspace-root.component.html',
  styleUrls: ['./workspace-root.component.sass']
})
export class WorkspaceRootComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }
  public style: object = {};
 
  validate(event: ResizeEvent): boolean {
    const MIN_DIMENSIONS_PX: number = 50;
    if (
      event.rectangle.width &&
      event.rectangle.height &&
      (event.rectangle.width < MIN_DIMENSIONS_PX ||
        event.rectangle.height < MIN_DIMENSIONS_PX)
    ) {
      return false;
    }
    return true;
  }
 
  onResizeEnd(event: ResizeEvent): void {
    this.style = {
      position: 'fixed',
      left: `${event.rectangle.left}px`,
      top: `${event.rectangle.top}px`,
      width: `${event.rectangle.width}px`,
      height: `${event.rectangle.height}px`
    };
}
}
