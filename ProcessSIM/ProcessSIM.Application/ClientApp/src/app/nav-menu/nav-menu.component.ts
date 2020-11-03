import { Component } from '@angular/core';
import {AuthService} from "../services/auth.service";
import {MatDialog} from "@angular/material/dialog";
import {ConfirmDialog} from "../confirm-dialog/confirm-dialog.component";
import {Router} from "@angular/router";

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isLoggedIn: boolean = false;
  userInfo: any = null;
  userRole: string = null;

  constructor(private _authService: AuthService, public dialog: MatDialog, private router: Router) {
    this._authService.isLoggedIn.subscribe((value) => {
      this.isLoggedIn = value;
    });
    this._authService.userInfo.subscribe((value) => {
      this.userInfo = value;
    });
    this._authService.userRole.subscribe((value) => {
      this.userRole = value;
    });
  }

  logout() {
    const dialogRef = this.dialog.open(ConfirmDialog, {
      width: '250px',
    });

    dialogRef.afterClosed().subscribe(result => {
      if (!result)
        return;

      this._authService.logout();
      this.router.navigate(['/login']);
    });
  }

}
