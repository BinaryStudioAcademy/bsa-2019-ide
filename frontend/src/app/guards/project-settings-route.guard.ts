import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot, CanActivate, Router } from '@angular/router';
import { TokenService } from '../services/token.service/token.service';
import { ProjectService } from '../services/project.service/project.service';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ProjectSettingsRouteGuard implements CanActivate {
    constructor(
        private tokenService: TokenService,
        private projectService: ProjectService,
        private toastService: ToastrService,
        private router: Router
    ) {}

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> {
        const userId = this.tokenService.getUserId();
        const projectId = Number(route.paramMap.get('id'));

        return this.projectService.getProjectById(projectId).pipe(
            map((resp) => {
                const isAuthor = userId === resp.body.authorId;
                if (!isAuthor) {
                    this.toastService.error("Wrong author Id.","Access denied!")
                    this.router.navigate([`project/${projectId}`]);
                }
                return isAuthor;
            },
            (error) => {
                console.error(error.message);
                return false;
            })
        );
    }
}
