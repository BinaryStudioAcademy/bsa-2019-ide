import { Component, OnInit, Input } from '@angular/core';
import { ProjectDescription } from 'src/app/models/dto/project/project-description';

@Component({
  selector: 'app-projects-list',
  templateUrl: './projects-list.component.html',
  styleUrls: ['./projects-list.component.sass']
})
export class ProjectsListComponent implements OnInit {
  @Input() header: string;
  @Input() projects: ProjectDescription[];

  constructor() { }

  ngOnInit() { }

}
