import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ProjectService } from 'src/app/services/project.service/project.service';
import { ProjectCreateDTO } from 'src/app/models/dto/project/projectCreateDTO';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-project',
  templateUrl: './create-project.component.html',
  styleUrls: ['./create-project.component.sass']
})
export class CreateProjectComponent implements OnInit, OnDestroy {
  
  constructor(
    private fb: FormBuilder,
    private projectService: ProjectService,
    private toastrService:ToastrService,
    private router:Router) { }
  
  private languages: any;
  private projectTypes: any;
  private compilerTypes: any;
  private project:ProjectCreateDTO;

  public projectForm = this.fb.group({
    name: ['', Validators.required],
    description: ['', Validators.required],
    language: ['', Validators.required],
    projectType: ['', Validators.required],
    compilerType: ['', Validators.required],
    countOfSavedBuilds: ['', Validators.required],
    countOfBuildAttempts: ['', Validators.required]
  });

  onSubmit() {

    this.project = {
      name: this.projectForm.get('name').value,
      description: this.projectForm.get('description').value,
      authorId: 1, //you need to path here id of your existing user
      language: this.projectForm.get('language').value,
      projectType: this.projectForm.get('projectType').value,
      compilerType: this.projectForm.get('compilerType').value,
      countOfSaveBuilds: this.projectForm.get('countOfSavedBuilds').value,
      countOfBuildAttempts: this.projectForm.get('countOfBuildAttempts').value
    };

    this.projectService.addProject(this.project)
       .subscribe(res => {
        this.toastrService.success('Project created');
        console.log(res);
         // {project.id}" server will return Id prop
        this.router.navigate([`/project/5`]);
       },
       error => {
         this.toastrService.error('error');
       });
  }

  ngOnInit(): void { //Maybe choose initializing
    this.languages = [
      {label: 'C#', value: 0},
      {label: 'TypeScript', value: 1}
    ];

    this.compilerTypes = [
      {label: '.Net Core', value: 0}
    ];

    this.projectTypes = [
      {label: 'Console App', value: 0},
      {label: 'Web App', value: 1},
      {label: 'Library', value: 2}
    ];
  }

  ngOnDestroy(): void {
    this.projectForm = null;
  }
}
