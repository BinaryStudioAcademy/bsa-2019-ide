import { Component, OnInit, Inject } from '@angular/core';
import { takeUntil } from 'rxjs/operators';
import { DialogType } from 'src/app/modules/authorization/models/auth-dialog-type';
import { AuthenticationService } from 'src/app/services/auth.service/auth.service';
import { Subject } from 'rxjs';
import { DynamicDialogRef, DynamicDialogConfig } from 'primeng/api';

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

  public display: boolean=false;
  public hidePass = true;
  public title: string;
  private unsubscribe$ = new Subject<void>();
  providers: [AuthenticationService];

  constructor(
      private authService: AuthenticationService,
      public ref: DynamicDialogRef, 
      public config: DynamicDialogConfig
  ) {}

  public ngOnInit() {
      this.title = this.config.data.dialogType === DialogType.SignIn ? 'Lon in your account' : 'Create your account';         
  }
  

  public ngOnDestroy() {
      this.unsubscribe$.next();
      this.unsubscribe$.complete();
  }

  public close()
  {
      this.ref.close();
  }


  public signIn() {
      this.authService
          .login({ email: this.email, password: this.password })
          .pipe(takeUntil(this.unsubscribe$))
          .subscribe(result=>this.ref.close());
  }

  public signUp() {
       this.authService
         .register({ id: 0, firstName: this.firstName,lastName:this.lastName, password: this.password, email: this.email })
          .pipe(takeUntil(this.unsubscribe$))
          .subscribe(result=>this.ref.close());
  }
}
