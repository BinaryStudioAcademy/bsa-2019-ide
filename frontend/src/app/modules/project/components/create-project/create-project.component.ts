import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-create-project',
  templateUrl: './create-project.component.html',
  styleUrls: ['./create-project.component.sass']
})
export class CreateProjectComponent implements OnInit {

  constructor(private fb:FormBuilder) { }

  private project:any;//ProjectDTO
  private languages:any;
  private projectTypes:any;
  private compilerTypes:any;

  public projectForm = this.fb.group({
  name: ['', Validators.required],
  description: ['', Validators.required],
  language: ['', Validators.required],
  projectType: ['', Validators.required],
  compilerType: ['', Validators.required],
  countOfSavedBuilds: ['', Validators.required],
  countOfbuildAttempts: ['', Validators.required]

  /*
  */
});

  onSubmit(){
    console.log(this.projectForm.value)
    //invoke post method in project service
  }

  ngOnInit(): void {
    this.languages = [
      {label: 'C#', value: 0},
      {label: 'TypeScript', value: 1}
    ]

    this.compilerTypes = [
      {label: '.Net Core', value: 0}
    ]

    this.projectTypes = [
      {label: 'Console App', value: 0},
      {label: 'Web App', value: 1},
      {label: 'Library', value: 2}
    ]
    
  }
}

