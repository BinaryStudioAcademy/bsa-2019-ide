import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CommandType } from '../../models/commang-type';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/api';
import { GitService } from 'src/app/services/git.service/git.service';
import { ToastrService } from 'ngx-toastr';
import { GitMessageDTO } from 'src/app/models/DTO/Git/gitMessageDTO';
import { GitBranchDTO } from 'src/app/models/DTO/Git/gitBranchDTO';

@Component({
  selector: 'app-git-window',
  templateUrl: './git-window.component.html',
  styleUrls: ['./git-window.component.sass']
})
export class GitWindowComponent implements OnInit {

    public title:string;
    public projectId: string;
    public branches: any;
    public gitForm: FormGroup;
    
    public isPageLoaded: boolean = false;
    public hasDetailsSaveResponse: boolean = true;

    public gitMess: GitMessageDTO;
    public gitBr: GitBranchDTO;

    private commandType: CommandType;

    constructor(
        private ref: DynamicDialogRef,
        private config: DynamicDialogConfig,
        private fb: FormBuilder,
        private gitService: GitService,
        private toastrService: ToastrService) { }

  ngOnInit(): void {
        this.commandType = this.config.data.commandType;

        this.branches = [
            {label:'master', value:'master'}
        ];
        this.isPageLoaded = true;

        switch(this.config.data.commandType){
            case 0:{
                this.title = "Pull";
                this.gitForm = this.fb.group({
                    projectId: ['', [Validators.required]],
                    pullBranch: ['', Validators.required]});
                break;
            }
            case 1:{
                this.title = "Push";
                this.gitForm = this.fb.group({
                    projectId: ['', [Validators.required]],
                    pushBranch: ['', Validators.required]});
                break;
            }
            case 2:{
                this.title = "Commit";
                this.gitForm = this.fb.group({
                    projectId: ['', [Validators.required]],
                    message: ['', Validators.required]});
                break;
            }
        }

        this.Initialize();
    }

    public isPull() {
        return this.commandType == CommandType.Pull;
    }

    public isCommit() {
        return this.commandType == CommandType.Commit;
    }

    public isPush(){
        return this.commandType == CommandType.Push;
    }

    public onSubmit() {
        this.hasDetailsSaveResponse = false;

        if(this.isPull()){

            this.gitBr = {
                projectId: this.gitForm.get('projectId').value,
                branch: this.gitForm.get('pullBranch').value
            }

            this.gitService.pull(this.gitBr)
                .subscribe(res =>{
                    this.hasDetailsSaveResponse = true;
                    this.toastrService.success('pull');
                    this.close();
            }, error =>{
                this.toastrService.error('error');
                console.log(error);
            })
        }
        else if(this.isPush()){

            this.gitBr = {
                projectId: this.gitForm.get('projectId').value,
                branch: this.gitForm.get('pushBranch').value
            }

            this.gitService.push(this.gitBr)
            .subscribe(res =>{
                this.hasDetailsSaveResponse = true;
                this.toastrService.success('push');
                this.close();
            }, error =>{
                this.toastrService.error('error');
                console.log(error);
            })
        }
        else if(this.isCommit()){

            this.gitMess = {
                projectId: this.gitForm.get('projectId').value,
                message: this.gitForm.get('message').value
            }

            this.gitService.commit(this.gitMess)
                .subscribe(res =>{
                    this.hasDetailsSaveResponse = true;
                    this.toastrService.success('commit');
                    this.close();
            }, error =>{
                this.toastrService.error('error');
                console.log(error);
            })
        }
    }

    public close() {
        this.ref.close();
    }
    
    private Initialize() {
        this.gitForm.patchValue({ 
            projectId: this.config.data.projectId
        });
    }
    
}
