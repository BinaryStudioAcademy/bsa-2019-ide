import { Component, OnInit } from '@angular/core';
import { getLocaleDateTimeFormat } from '@angular/common';

@Component({
  selector: 'app-project-details-info',
  templateUrl: './project-details-info.component.html',
  styleUrls: ['./project-details-info.component.sass']
})
export class ProjectDetailsInfoComponent implements OnInit {

  public project:any;

  constructor() { }

  ngOnInit() {
    this.project = {
        id:0,
        name:'Online IDE',
        description:'lorem ipsun',
        createdAt:'2016-01-17T:08:44:29+0100',
        language:'CSharp',
        projectType: 'Web',
        compilerType: 'NetCore',
        projectLink: '',
        countOfSaveBuilds: '5',
        countOfBuildAttempts: '10',
        author: 'username',
        gitCredentials:[{provider:'provider', url:'https://github.com/BinaryStudioAcademy/bsa-2019-ide.git'},
                        {provider:'provider', url:'https://github.com/BinaryStudioAcademy/bsa-2019-ide.git'}],
        logo:'https://miro.medium.com/max/1200/1*u9Rw2zT1kQl0I0Oa-9vc_g.png'
    }
  }

}
