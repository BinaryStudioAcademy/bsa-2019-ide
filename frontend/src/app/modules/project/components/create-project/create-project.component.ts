import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Project } from 'src/app/models/project/project';
import { ProjectService } from 'src/app/services/project.service/project.service';

@Component({
  selector: 'app-create-project',
  templateUrl: './create-project.component.html',
  styleUrls: ['./create-project.component.sass']
})
export class CreateProjectComponent implements OnInit {

  constructor(private fb: FormBuilder, private projectService: ProjectService) { }
  private languages: any;
  private projectTypes: any;
  private compilerTypes: any;

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
    console.log(this.projectForm.value);

    const project: Project = {
      id: 0,
      name: this.projectForm.get('name').value,
      description: this.projectForm.get('description').value,
      authorId: 222, //get current author Id
      language: this.projectForm.get('language').value,
      projectType: this.projectForm.get('projectType').value,
      compilerType: this.projectForm.get('compilerType').value,
      countOfSaveBuilds: this.projectForm.get('countOfSavedBuilds').value,
      countOfBuildAttempts: this.projectForm.get('countOfBuildAttempts').value,
      gitCredentialId: 222, // Set smth here
    };
    console.log(project);
    // this.projectService.addProject(project)
    //   .subscribe(x => console.log(x));
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
}

