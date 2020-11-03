import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';
import {IJsonResult} from "../models/jsonResult.interface";

@Injectable()
export class SimulationService {
  simulationUrl = `${environment.apiUrl}/simulation`;

  constructor(private _http: HttpClient) { }

  startSimulation(data: any): Observable<IJsonResult> {
    return this._http.post<IJsonResult>(this.simulationUrl, data);
  }
}
