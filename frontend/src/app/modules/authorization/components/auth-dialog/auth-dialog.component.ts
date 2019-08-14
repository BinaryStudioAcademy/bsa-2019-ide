import { Component, OnInit, Inject } from '@angular/core';
import { takeUntil } from 'rxjs/operators';
import { DialogType } from 'src/app/modules/authorization/models/auth-dialog-type';
import { AuthenticationService } from 'src/app/services/auth.service/auth.service';
import { Subject } from 'rxjs';
import { DynamicDialogRef, DynamicDialogConfig } from 'primeng/api';
import { UserRegisterDTO } from '../../../../models/DTO/User/userRegisterDTO';
import { NavMenuComponent } from 'src/app/nav-menu/nav-menu.component';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
    selector: 'app-auth-dialog',
    templateUrl: './auth-dialog.component.html',
    styleUrls: ['./auth-dialog.component.sass']
})
export class AuthDialogComponent implements OnInit {

    public dialogType = DialogType;
    public firstName: string;
    public lastName: string;
    public password: string;
    public avatar: string;
    public email: string;
    public nickName: string;
    private nav: NavMenuComponent;

    public display: boolean = false;
    public hidePass = true;
    public title: string;
    public isSpinner = false;
    private unsubscribe$ = new Subject<void>();
    providers: [AuthenticationService];

    constructor(
        private authService: AuthenticationService,
        public ref: DynamicDialogRef,
        public config: DynamicDialogConfig,
        private router: Router,
        private toast: ToastrService
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
        this.authService
            .login({ email: this.email, password: this.password })
            .pipe(takeUntil(this.unsubscribe$))
            .subscribe(result => {this.isSpinner = false; this.ref.close()},
                error => { 
                    this.isSpinner = false;
                    this.toast.error("The email or password is incorrect", "Error Message");
                },
                () => this.toast.success("You have successfully signed in!")
            );
        this.router.navigate(['/']);
    }

    public signUp() {
        let user = {
            id: 0,
            firstName: this.firstName,
            lastName: this.lastName,
            nickName: this.nickName,
            password: this.password,
            email: this.email
        };
        this.authService
            .register(user)
            .pipe(takeUntil(this.unsubscribe$))
            .subscribe(result => this.ref.close(),
                error => this.toast.error("registering failded", "Error Message"),
                () => this.toast.success("You have successfully registered!"));
    }
}
