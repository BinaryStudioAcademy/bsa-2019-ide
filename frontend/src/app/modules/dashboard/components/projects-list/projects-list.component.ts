import { Component, OnInit, Input } from '@angular/core';
import { ProjectDescriptionDTO } from 'src/app/models/dto/project/projectDescriptionDTO';

@Component({
  selector: 'app-projects-list',
  templateUrl: './projects-list.component.html',
  styleUrls: ['./projects-list.component.sass']
})
export class ProjectsListComponent implements OnInit {
  @Input() header: string;
  @Input() projects: ProjectDescriptionDTO[];

  constructor() { }

  ngOnInit() { }

}
