import {Injectable} from '@angular/core';
import {HttpInterceptor, HttpHandler, HttpRequest, HttpEvent, HttpResponse}
  from '@angular/common/http';

import {Observable} from "rxjs";
import {AuthService} from "../services/auth.service";

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor(private _authService: AuthService) {
  }

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    const token = this._authService.getAuthHeader();
    const modifiedReq = req.clone({
      headers: req.headers.set('Authorization', token),
    });
    return next.handle(modifiedReq);
  }
}
