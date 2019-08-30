import { ProjectService } from 'src/app/services/project.service/project.service';
import { FileSearchResultDTO } from './../../../models/DTO/File/fileSearchResultDTO';
import { WorkspaceService } from './../../../services/workspace.service';
import { ToastrService } from 'ngx-toastr';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { map, switchMap, tap } from 'rxjs/operators';
import { query } from '@angular/animations';
import { SearchFileService } from 'src/app/services/search-file.service/search-file.service';
import { forkJoin } from 'rxjs/internal/observable/forkJoin';
import { EventService } from 'src/app/services/event.service/event.service';
import { Observable } from 'rxjs';
import { FileDTO } from 'src/app/models/DTO/File/fileDTO';

@Component({
    selector: 'app-global-search-output',
    templateUrl: './global-search-output.component.html',
    styleUrls: ['./global-search-output.component.sass']
})
export class GlobalSearchOutputComponent implements OnInit {
    public isSpinner = true;
    public projectName;
    public query;
    public projectId;
    public fileSearchResults: FileSearchResultDTO[];
    public content;
    public filesToShow$;
    constructor(private route: ActivatedRoute,
        private searchFileService: SearchFileService,
        private toast: ToastrService,
        private ws: WorkspaceService,
        private projS: ProjectService,
        private router: Router,
       ) { }

    ngOnInit() {
        this.route.queryParams.pipe(switchMap(param => 
            {
                this.query = param['query']; 
                return this.searchFileService.findFilesGlobal(param['query']);
            })
            )
            .subscribe(response => {
                this.fileSearchResults = response.body;
                this.filesToShow$ = forkJoin(this.fileSearchResults
                    .map(r => this.ws.getFileById(r.fileId)
                    .pipe(
                        switchMap(f => 
                            this.getProjectNameFromId(f.body.projectId)
                            .pipe(
                                map(projName => 
                                        ({
                                            file:f.body,
                                            proj:projName
                                        })
                                    )
                                )
                        ),
                        tap(x => this.isSpinner = false)
                    ))
                )
                                        
            });

    }
    getProjectNameFromId(projectId) {
        return this.projS.getProjectById(projectId).pipe(map(pr  => { return pr.body.name}));
    }

    clicked(file){
        this.router.navigate([`/workspace/${file.projectId}`], {
            queryParams: {
              fileId: file.id,
            }});
    }

}
