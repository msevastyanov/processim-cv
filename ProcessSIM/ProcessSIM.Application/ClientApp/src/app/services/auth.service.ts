import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {Observable, Subject} from 'rxjs';

import { environment } from '../../environments/environment';
import {IJsonResult} from "../models/jsonResult.interface";
import {ILogin} from "../models/login.interface";

@Injectable()
export class AuthService {
  authUrl = `${environment.apiUrl}/auth`;
  isLoggedIn: Subject<any> = new Subject<any>();
  userInfo: Subject<any> = new Subject<any>();
  userRole: Subject<any> = new Subject<any>();

  constructor(private _http: HttpClient) { }

  auth(data: ILogin): Observable<IJsonResult> {
    return this._http.post<IJsonResult>(`${this.authUrl}/login`, data);
  }

  setToken(accessToken) {
    localStorage.setItem('accessToken', accessToken);
  }

  getUserInfo() {
    let accessTokenParsed = this.parseJwt(localStorage.getItem('accessToken'));
    return {
      username: accessTokenParsed['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'],
      userrole: accessTokenParsed['http://schemas.microsoft.com/ws/2008/06/identity/claims/role']
    }
  }

  setIsLoggedIn(isLogged: boolean, userInfo: any) {
    this.isLoggedIn.next(isLogged);
    this.userInfo.next(userInfo);
    const info = this.getUserInfo();
    this.userRole.next(info.userrole);
    localStorage.setItem('userInfo', JSON.stringify(userInfo));
  }

  logout() {
    this.isLoggedIn.next(false);
    this.userInfo.next(null);
    this.userRole.next(null);
    this.removeTokens();
  }

  getAccessToken() {
    return localStorage.getItem('accessToken')
  }

  getStorageUserInfo() {
    return JSON.parse(localStorage.getItem('userInfo'))
  }

  getAuthHeader() {
    return `Bearer ${this.getAccessToken()}`
  }

  parseJwt(token) {
    let base64Url = token.split('.')[1]
    let base64 = base64Url.replace('-', '+').replace('_', '/')
    return JSON.parse(window.atob(base64))
  }

  removeTokens() {
    localStorage.removeItem('accessToken');
    localStorage.removeItem('userInfo');
  }

  checkAuth() {
    const token = this.getAccessToken();
    const userInfo = this.getStorageUserInfo();
    if (!token || !userInfo)
      return false;

    this.isLoggedIn.next(true);
    this.userInfo.next(userInfo);
    this.userRole.next(null);
    const info = this.getUserInfo();
    this.userRole.next(info.userrole);

    return true;
  }
}
