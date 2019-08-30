import { ProjectService } from 'src/app/services/project.service/project.service';
import { FileSearchResultDTO } from './../../../models/DTO/File/fileSearchResultDTO';
import { WorkspaceService } from './../../../services/workspace.service';
import { ToastrService } from 'ngx-toastr';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { map, switchMap, tap, catchError, timeout, mergeMap, take } from 'rxjs/operators';
import { query } from '@angular/animations';
import { SearchFileService } from 'src/app/services/search-file.service/search-file.service';
import { forkJoin } from 'rxjs/internal/observable/forkJoin';
import { EventService } from 'src/app/services/event.service/event.service';
import { Observable, of, interval, throwError } from 'rxjs';
import { FileDTO } from 'src/app/models/DTO/File/fileDTO';

@Component({
    selector: 'app-global-search-output',
    templateUrl: './global-search-output.component.html',
    styleUrls: ['./global-search-output.component.sass']
})
export class GlobalSearchOutputComponent implements OnInit {
    public isSpinner = false;
    public projectName: string;
    public query;
    public fileSearchResults: FileSearchResultDTO[];
    public filesToShow$;
    constructor(private route: ActivatedRoute,
        private searchFileService: SearchFileService,
        private toast: ToastrService,
        private ws: WorkspaceService,
        private projS: ProjectService,
        private router: Router,
    ) { }

    ngOnInit() {
        this.route.queryParams.pipe(switchMap(param => {
            this.query = param['query'];
            return this.searchFileService.findFilesGlobal(param['query']);
        })
        ).pipe(tap(x => this.isSpinner = true), timeout(60000))
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
                                                file: f.body,
                                                proj: projName
                                            })
                                        )
                                    )
                            ),
                            tap(x => this.isSpinner = false),

                        ))
                )

            }, error => { this.isSpinner = false; console.log(error) });

    }
    public getProjectNameFromId(projectId: number) {
        return this.projS.getProjectById(projectId).pipe(map(pr => { return pr.body.name }));
    }

   public  clicked(file) {
        this.router.navigate([`/workspace/${file.projectId}`], {
            queryParams: {
                fileId: file.id,
            }
        });
    }

}
