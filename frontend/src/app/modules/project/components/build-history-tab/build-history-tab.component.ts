import { Component, OnInit, Input } from '@angular/core';
import { BuildDescriptionDTO } from 'src/app/models/DTO/Common/buildDescriptionDTO';

@Component({
    selector: 'app-build-history-tab',
    templateUrl: './build-history-tab.component.html',
    styleUrls: ['./build-history-tab.component.sass']
})
export class BuildHistoryTabComponent implements OnInit {

    @Input()
    public build: BuildDescriptionDTO;
    constructor() { }

    ngOnInit() {
    }

    public getBackgroundColor(build: BuildDescriptionDTO)
    {
        if(!build.buildFinished)
        {
            return "yellow";
        }
        if(build.buildStatus==0)
        {
            return "red";
        }
        return "green";
    }

}