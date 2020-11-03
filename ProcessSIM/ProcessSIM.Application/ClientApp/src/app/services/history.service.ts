import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';

import {environment} from '../../environments/environment';
import {IHistoryHttp} from "../models/http-models/history-http.interface";

@Injectable()
export class HistoryService {
  historyUrl = `${environment.apiUrl}/history`;

  constructor(private _http: HttpClient) {
  }

  getHistory(): Observable<IHistoryHttp> {
    return this._http.get<IHistoryHttp>(this.historyUrl);
  }
}
