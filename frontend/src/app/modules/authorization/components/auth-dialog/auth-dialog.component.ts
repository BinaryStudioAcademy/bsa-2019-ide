import { Component, OnInit, Inject } from '@angular/core';
import { takeUntil } from 'rxjs/operators';
import { DialogType } from 'src/app/models/common/auth-dialog-type';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { AuthenticationService } from 'src/app/services/auth.service/auth.service';
import { Subject } from 'rxjs';
import { SnackBarService } from 'src/app/services/snack.service/snack-bar.service';

@Component({
  selector: 'app-auth-dialog',
  templateUrl: './auth-dialog.component.html',
  styleUrls: ['./auth-dialog.component.sass']
})
export class AuthDialogComponent implements OnInit {

  public dialogType = DialogType;
  public userName: string;
  public password: string;
  public avatar: string;
  public email: string;

  public hidePass = true;
  public title: string;
  private unsubscribe$ = new Subject<void>();

  constructor(
      private dialogRef: MatDialogRef<AuthDialogComponent>,
      @Inject(MAT_DIALOG_DATA) public data: any,
      private authService: AuthenticationService,
      private snackBarService: SnackBarService
  ) {}

  public ngOnInit() {
      this.title = this.data.dialogType === DialogType.SignIn ? 'Lon in your account' : 'Create your account';
  }

  public ngOnDestroy() {
      this.unsubscribe$.next();
      this.unsubscribe$.complete();
  }

  public close() {
      this.dialogRef.close(false);
  }

  public signIn() {
      this.authService
          .login({ email: this.email, password: this.password })
          .pipe(takeUntil(this.unsubscribe$))
          .subscribe((response) => this.dialogRef.close(response), (error) => console.log(this.snackBarService.showErrorMessage(error)));
  }

  public signUp() {
      this.authService
          .register({ userName: this.userName, password: this.password, email: this.email })
          .pipe(takeUntil(this.unsubscribe$))
          .subscribe((response) => this.dialogRef.close(response), (error) => this.snackBarService.showErrorMessage(error));
  }

}
