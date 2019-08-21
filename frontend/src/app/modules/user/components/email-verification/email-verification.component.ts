import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { filter } from 'rxjs/operators';
import { UserService } from 'src/app/services/user.service/user.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-email-verification',
  templateUrl: './email-verification.component.html',
  styleUrls: ['./email-verification.component.sass']
})
export class EmailVerificationComponent implements OnInit {
    public isError: boolean;

    constructor(private route: ActivatedRoute,
                private router: Router,
                private userService: UserService,
                private toastrService: ToastrService) { }

    ngOnInit() {
        this.route.queryParams
            .subscribe(params => {
                if (params.vcd !== undefined) {
                   this.confirmEmail(params.vcd);
                } else {
                    this.router.navigate(['/dashboard']);
                }
            });
    }

    private confirmEmail(token: string) {
        this.userService.confirmEmail({ token: token })
            .subscribe((data) => {
                this.toastrService.success('Your email was successfully verified');
                this.router.navigate(['/dashboard']);
            },
            (error) => {
                this.toastrService.error('Oooops, something goes wrong, try again later');
                this.isError = true;
                console.log(error);
            })
    }
}
