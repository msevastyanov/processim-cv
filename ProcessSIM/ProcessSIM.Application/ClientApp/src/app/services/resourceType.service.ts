import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';
import {IJsonResult} from "../models/jsonResult.interface";
import {IDirtyType} from "../models/dirtyType.interface";

@Injectable()
export class ResourceTypeService {
  resourceTypesUrl = `${environment.apiUrl}/type`;

  constructor(private _http: HttpClient) { }

  getResourceType(typeId: number): Observable<IJsonResult> {
    return this._http.get<IJsonResult>(`${this.resourceTypesUrl}/${typeId}`);
  }

  addResourceType(catId: number, data: IDirtyType): Observable<IJsonResult> {
    return this._http.post<IJsonResult>(`${this.resourceTypesUrl}/${catId}`, data);
  }

  updateResourceType(id: number, data: IDirtyType): Observable<IJsonResult> {
    return this._http.post<IJsonResult>(`${this.resourceTypesUrl}/${id}/update`, data);
  }

  deleteResourceType(id: number): Observable<IJsonResult> {
    return this._http.delete<IJsonResult>(`${this.resourceTypesUrl}/${id}`);
  }
}
