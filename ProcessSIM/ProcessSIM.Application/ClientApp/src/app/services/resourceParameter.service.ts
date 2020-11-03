import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';
import {IJsonResult} from "../models/jsonResult.interface";
import {IResourceParameterHttp} from "../models/http-models/resourceParameter-http.interface";
import {IDirtyParameter} from "../models/dirtyParameter.interface";
import {IResourceParameter} from "../models/resourceParameter.interface";

@Injectable()
export class ResourceParameterService {
  resourceParamsUrl = `${environment.apiUrl}/parameter`;

  constructor(private _http: HttpClient) { }

  getResourceParameters(typeId: number): Observable<IResourceParameterHttp> {
    return this._http.get<IResourceParameterHttp>(`${this.resourceParamsUrl}/${typeId}`);
  }

  addResourceParameter(typeId: number, data: IDirtyParameter): Observable<IJsonResult> {
    return this._http.post<IJsonResult>(`${this.resourceParamsUrl}/${typeId}`, data);
  }

  updateResourceParameter(typeId: number, data: IResourceParameter): Observable<IJsonResult> {
    return this._http.post<IJsonResult>(`${this.resourceParamsUrl}/${typeId}/${data.id}/update`, data);
  }

  deleteResourceParameter(id: number): Observable<IJsonResult> {
    return this._http.delete<IJsonResult>(`${this.resourceParamsUrl}/${id}`);
  }
}
