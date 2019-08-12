import { Component, OnInit } from '@angular/core';
import {MenuItem} from 'primeng/api';
import { Router } from '@angular/router';
import {UserDTO} from '../../../../models/DTO/User/userDTO'
import {AuthenticationService} from "../../../../services/auth.service/auth.service"
import { switchMap, takeUntil } from 'rxjs/operators';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-dashboard-root',
  templateUrl: './dashboard-root.component.html',
  styleUrls: ['./dashboard-root.component.sass']
})
export class DashboardRootComponent implements OnInit {
  items: string[][];
  isActive: Array<boolean> = [];
  public authorizedUser: UserDTO;
  private unsubscribe$ = new Subject<void>();

  constructor(private authService: AuthenticationService,
    private router: Router) { }

  ngOnInit() {
    this.items = [
      ['All projects', '/dashboard/'],
      ['My projects', '/dashboard/myProjects'],
      ['Assigned projects', '/dashboard/assignedProjects']
    ];

    this.getUser();
    this.isActive[0] = true;
  }

  redirect(i: number) {
    this.isActive = [];
    this.isActive[i] = true;
    this.router.navigate([this.items[i][1]]);
  }

  private getUser() {
    this.authService
        .getUser()
        .pipe(takeUntil(this.unsubscribe$))
        .subscribe((user) => (this.authorizedUser = user));
}
}
