import { Component, OnInit, Inject } from '@angular/core';
import { takeUntil } from 'rxjs/operators';
import { DialogType } from 'src/app/modules/authorization/models/auth-dialog-type';
import { Subject } from 'rxjs';
import { DynamicDialogRef, DynamicDialogConfig } from 'primeng/api';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { TokenService } from 'src/app/services/token.service/token.service';
import { UserService } from 'src/app/services/user.service/user.service';
import { SignalRService } from 'src/app/services/signalr.service/signal-r.service';
import { EditorSettingDTO } from 'src/app/models/DTO/Common/editorSettingDTO';

@Component({
    selector: 'app-auth-dialog',
    templateUrl: './auth-dialog.component.html',
    styleUrls: ['./auth-dialog.component.sass']
})
export class AuthDialogComponent implements OnInit {

    public editorOptions: EditorSettingDTO =
        {
            lineNumbers: "on",
            roundedSelection: false,
            scrollBeyondLastLine: false,
            readOnly: false,
            fontSize: 20,
            tabSize: 5,
            cursorStyle: "line",
            lineHeight: 20,
            theme: "vs",
            language: ""
        };
    public dialogType = DialogType;
    public firstName: string;
    public lastName: string;
    public password: string;
    public avatar: string;
    public email: string;
    public nickName: string;
    public isRecoverPassword: boolean = false;
    public emailRegexp = new RegExp('^[^.]{0}[a-zA-Z0-9._]{1,35}[^.]{0}@[^-]{0}[a-zA-Z0-9]{1,17}[^-]{0}[.]{1}[a-zA-Z]{1,17}$');
    public namesRegexp = new RegExp("[а-яА-Яa-zA-ZіІїЇ]{2,32}");
    public nickNameRegexp = new RegExp("[a-zA-Z0-9]{2,32}");
    public passwordRegexp = new RegExp("[а-яА-Яa-zA-Z0-9]{8,16}");

    public display: boolean = false;
    public hidePass = true;
    public title: string;
    public isSpinner = false;
    private unsubscribe$ = new Subject<void>();

    constructor(
        public ref: DynamicDialogRef,
        public config: DynamicDialogConfig,
        private router: Router,
        private tokenService: TokenService,
        private toast: ToastrService,
        private userService: UserService,
        private signalRService: SignalRService
    ) { }

    public ngOnInit() {
        this.title = this.config.data.dialogType === DialogType.SignIn ? 'Log in your account' : 'Create your account';
    }


    public ngOnDestroy() {
        this.unsubscribe$.next();
        this.unsubscribe$.complete();
    }

    public close() {
        this.ref.close();
    }


    public signIn() {
        this.isSpinner = true;
        this.tokenService
            .login({ email: this.email, password: this.password })
            .pipe(takeUntil(this.unsubscribe$))
            .subscribe(
                (result) => {
                    this.isSpinner = false; 
                    this.ref.close(); 
                    this.toast.success('You have successfully signed in!', `Wellcome, ${result.firstName} ${result.lastName}!`);
                    this.router.navigate(['dashboard']);
                    this.signalRService.addToGroup(this.tokenService.getUserId());
                },
                (error) => {
                    this.isSpinner = false;
                    const message = !!error.message ? error.message : error.statusText;
                    this.toast.error(message, 'Error Message');
                }
            );        
    }

    public signUp() {
        let user = {
            id: 0,
            firstName: this.firstName,
            lastName: this.lastName,
            nickName: this.nickName,
            password: this.password,
            email: this.email,
            editorSettings: this.editorOptions
        };
        this.tokenService
            .register(user)
            .pipe(takeUntil(this.unsubscribe$))
            .subscribe(
                (result) => {
                    this.ref.close();
                    this.router.navigate(['dashboard']);
                    this.signalRService.addToGroup(this.tokenService.getUserId());
                },
                (error) => this.toast.error("Invalid input data", 'Error Message'),
                () => {
                    this.toast.success('You have successfully registered!');
                    this.toast.info('Please, confirm your email');
                });
                
    }

    public isDataFull() {
        return this.email !== undefined && this.emailRegexp.test(this.email) 
            && this.password !== undefined && this.passwordRegexp.test(this.password)
            && (this.config.data.dialogType === DialogType.SignIn
            || (this.lastName !== undefined && this.namesRegexp.test(this.lastName)
            && this.nickName !== undefined && this.nickNameRegexp.test(this.nickName)
            && this.firstName !== undefined && this.namesRegexp.test(this.firstName)));
    }

    public recoverPassword() {
        if(!this.isRecoverPassword) {
            this.isRecoverPassword = true;
            this.title = 'Recover password';
        } else {
            this.isSpinner = true;
            if(!this.emailRegexp.test(this.email)){
                this.toast.error('Please, enter correct email');
                return;
            }
            this.userService.recoverPassword({ email: this.email })
                .subscribe((data) => {
                    this.toast.success('Letter with new password was sent to your mail!');
                    this.ref.close();
                    this.isSpinner = false;
                }, 
                (error) => {
                    console.log(error);
                    this.toast.error('User with such email doesn\'t exist');
                    this.isSpinner = false;
                })
        }
    }
}
