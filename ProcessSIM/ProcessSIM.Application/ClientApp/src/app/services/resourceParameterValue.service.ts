import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';
import {IJsonResult} from "../models/jsonResult.interface";
import {IResourceParameterValueHttp} from "../models/http-models/resourceParameterValue-http.interface";
import {IResourceParameterValue} from "../models/resourceParameterValue.interface";

@Injectable()
export class ResourceParameterValueService {
  resourceParametersUrl = `${environment.apiUrl}/parameterValue`;

  constructor(private _http: HttpClient) { }

  getResourceParameters(resId: number): Observable<IResourceParameterValueHttp> {
    return this._http.get<IResourceParameterValueHttp>(`${this.resourceParametersUrl}/${resId}`);
  }

  updateResourceParameter(data: IResourceParameterValue): Observable<IJsonResult> {
    return this._http.post<IJsonResult>(`${this.resourceParametersUrl}/${data.id}/update`, data);
  }
}
