import { Injectable } from '@angular/core';
import { ProjectDescriptionDTO } from 'src/app/models/DTO/Project/projectDescriptionDTO';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProjDialogDataService {
    
    private readonly _projects = new BehaviorSubject<ProjectDescriptionDTO>(null);
    public readonly todos$ = this._projects.asObservable();
    private set projects(val: ProjectDescriptionDTO) {
        this._projects.next(val);
    }

    addProject(project: ProjectDescriptionDTO) {
        this.projects = project;
    }
    
    removeTodo(id: number) {
        this.projects = null;
    }    
}
