import {Component, OnInit} from '@angular/core';
import {AuthService} from "./services/auth.service";
import {MatSnackBar} from "@angular/material/snack-bar";
import {ActivatedRoute, Router} from "@angular/router";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {
  title = 'app';

  constructor(private _authService: AuthService, private router: Router) {
  }

  ngOnInit(): void {
    const isLoggedIn = this._authService.checkAuth();

    if (!isLoggedIn)
      this.router.navigate(['/login']);
  }
}
