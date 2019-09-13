import { Component, OnInit, OnDestroy } from '@angular/core';
import { AuthService } from '../services/auth/auth.service';
import { TokenService } from '../services/token.service/token.service';
import { flatMap, takeUntil, catchError } from 'rxjs/operators';
import { Router } from '@angular/router';
import { EditorSettingDTO } from '../models/DTO/Common/editorSettingDTO';
import { Subject, of, throwError } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { SignalRService } from '../services/signalr.service/signal-r.service';
import { ErrorHandlerService } from '../services/error-handler.service/error-handler.service';

@Component({
  selector: 'app-callback',
  templateUrl: './callback.component.html',
  styleUrls: ['./callback.component.sass']
})
export class CallbackComponent implements OnInit, OnDestroy {

  private unsubscribe$ = new Subject<void>();

  constructor(private auth: AuthService,
    private tokenService: TokenService,
    private router: Router,
    private toast: ToastrService,
    private signalRService: SignalRService,
    private errorHandlerService: ErrorHandlerService) {
  }
  /*
      email: ""
  email_verified: true
  family_name: ""
  given_name: ""
  locale: "uk"
  name: ""
  nickname: ""
  picture: ""
  sub: ""
  updated_at: ""
   */
  ngOnInit() {
    this.auth.handleLoginCallback()
      .pipe(
        takeUntil(this.unsubscribe$),
        flatMap(x => {
          console.log("x", x)
          let user = {
            id: 0,
            firstName: x.given_name,
            lastName: x.family_name,
            nickName: x.nickname,
            password: "12345678",
            email: x.email,
            picture: x.picture
          };
          return this.tokenService.register(user).pipe(catchError(e => throwError(user)))
        }),
        catchError(x => {
          return this.tokenService.login({ email: x.email, password: x.password })
        })
      )
      .subscribe(x => {
        console.log(x);
        this.router.navigate(['dashboard']);
        this.signalRService.addToGroup(this.tokenService.getUserId());
        // if (this.config.data.projectId) {
        // 	this.router.navigate([`project/${this.config.data.projectId}`]);
        // }
      }, (error) => {
        this.router.navigate(['/']);
        this.toast.error("Invalid input data", this.errorHandlerService.getExceptionMessage(error))
      },
        () => {
          this.toast.success('You have successfully signed in!'/*, `Wellcome, ${result.firstName} ${result.lastName}!`*/);
          // this.toast.info('Please, confirm your email');
        }
      );
  }

  public ngOnDestroy() {
    // this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }
}
