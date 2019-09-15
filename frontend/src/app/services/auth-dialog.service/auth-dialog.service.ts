import { Injectable, OnDestroy } from '@angular/core';
import { DialogType } from 'src/app/modules/authorization/models/auth-dialog-type';
import { AuthDialogComponent } from 'src/app/modules/authorization/components/auth-dialog/auth-dialog.component';
import { Subject } from 'rxjs';
import { DialogService } from 'primeng/components/common/api';

@Injectable({
    providedIn: 'root'
})
export class AuthDialogService implements OnDestroy {

    private unsubscribe$ = new Subject<void>();

    public constructor(private dialogService: DialogService) { }

    public openAuthDialog(type: DialogType, id?: number) {
        const dialog = this.dialogService.open(AuthDialogComponent, {
            data: {
                dialogType: type,
                projectId: id
            },
            width: '40%',
            contentStyle: {
                'border-radius': '5px',
                'padding': '2%'
            },
            showHeader: false,
            closeOnEscape: true
        });
    }

    public ngOnDestroy() {
        this.unsubscribe$.next();
        this.unsubscribe$.complete();
    }
}
