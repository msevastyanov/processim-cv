import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';
import { IProcedureHttp } from '../models/http-models/procedure-http.interface';

@Injectable()
export class ProcedureService {
  proceduresUrl = `${environment.apiUrl}/procedure`;

  constructor(private _http: HttpClient) { }

  getProcedures(): Observable<IProcedureHttp> {
    return this._http.get<IProcedureHttp>(this.proceduresUrl);
  }
}
