import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material';

@Injectable({ providedIn: 'root' })
export class SnackBarService {
    public constructor(private snackBar: MatSnackBar) {}

    public showErrorMessage(error: any) {
        this.snackBar.open(error, '', { duration: 3000, panelClass: 'error-snack-bar' });
    }

    public showUsualMessage(message: any) {
        this.snackBar.open(message, '', { duration: 3000, panelClass: 'usual-snack-bar' });
    }
}
