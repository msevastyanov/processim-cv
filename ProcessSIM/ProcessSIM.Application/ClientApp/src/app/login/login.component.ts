import { Component } from '@angular/core';
import {AuthService} from "../services/auth.service";
import {SnackAlertComponent} from "../snack-alert/snack-alert.component";
import {MatSnackBar} from "@angular/material/snack-bar";
import {ActivatedRoute, Router} from "@angular/router";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent {
  title = 'login';

  username: string = "";
  password: string = "";

  constructor(private _authService: AuthService, private _snackBar: MatSnackBar, private route: ActivatedRoute, private router: Router) {
  }

  auth(): void {
    this._authService.auth({
      userName: this.username,
      password: this.password
    }).subscribe(httpResult => {
      if (httpResult.status === "success") {
        console.log('httpResult.data', httpResult.data)
        this._authService.setToken(httpResult.data.accessToken.value);
        this._authService.setIsLoggedIn(true, httpResult.data.userInfo);
        this.router.navigate(['/']);
      } else {
        this.openSnackBar(httpResult.message)
      }
    });
  }

  openSnackBar(text: string) {
    this._snackBar.openFromComponent(SnackAlertComponent, {
      data: text,
      duration: 4000,
    });
  }
}
