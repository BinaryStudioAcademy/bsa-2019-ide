import { Injectable, OnDestroy } from '@angular/core';
import { DialogType } from 'src/app/models/common/auth-dialog-type';
import { MatDialog } from '@angular/material';
import { AuthenticationService } from '../auth.service/auth.service';
import { AuthDialogComponent } from 'src/app/modules/authorization/components/auth-dialog/auth-dialog.component';
import { takeUntil } from 'rxjs/operators';
import { User } from 'src/app/models/user';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthDialogService implements OnDestroy {

  private unsubscribe$ = new Subject<void>();

  public constructor(private dialog: MatDialog, private authService: AuthenticationService) {}

    public openAuthDialog(type: DialogType) {
        const dialog = this.dialog.open(AuthDialogComponent, {
            data: { dialogType: type },
            panelClass:'mypanelclass',
            minWidth: 300,
            autoFocus: true,
            backdropClass: 'dialog-backdrop',
            position: {
                top: '0'
            }
        });

        dialog
            .afterClosed()
            .pipe(takeUntil(this.unsubscribe$))
            .subscribe((result: User) => {
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
