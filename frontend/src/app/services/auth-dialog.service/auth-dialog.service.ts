import { Injectable, OnDestroy } from '@angular/core';
import { DialogType } from 'src/app/modules/authorization/models/auth-dialog-type';
import { AuthenticationService } from '../auth.service/auth.service';
import { AuthDialogComponent } from 'src/app/modules/authorization/components/auth-dialog/auth-dialog.component';
import { takeUntil } from 'rxjs/operators';
import { UserDTO } from 'src/app/models/User/userDTO';
import { Subject } from 'rxjs';
import { DialogService } from 'primeng/components/common/api';

@Injectable({
  providedIn: 'root'
})
export class AuthDialogService implements OnDestroy {

  private unsubscribe$ = new Subject<void>();


  public constructor( private authService: AuthenticationService,
    private dialogService: DialogService)
    {}

    public openAuthDialog(type: DialogType) {
        const dialog = this.dialogService.open(AuthDialogComponent, {
            data: { dialogType: type },
            width: '40%',
            contentStyle: {
              "border-radius" : "5px",
              "padding": "2%"
            },
            showHeader : false          
        });

        dialog
        .onClose
        .pipe(takeUntil(this.unsubscribe$))
        .subscribe((result: UserDTO) => {
          if (result) {
              this.authService.setUser(result);
          }
      });
    }

    public ngOnDestroy() {
      this.unsubscribe$.next();
      this.unsubscribe$.complete();
  }
}
