import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';
import { IResourceHttp } from '../models/http-models/resource-http.interface';
import {IDirtyCategory} from "../models/dirtyCategory.interface";
import {IJsonResult} from "../models/jsonResult.interface";

@Injectable()
export class ResourceService {
  resourcesUrl = `${environment.apiUrl}/resource`;

  constructor(private _http: HttpClient) { }

  getResources(): Observable<IResourceHttp> {
    return this._http.get<IResourceHttp>(this.resourcesUrl);
  }

  getResourcesByType(typeId: number): Observable<IResourceHttp> {
    return this._http.get<IResourceHttp>(`${this.resourcesUrl}/${typeId}`);
  }

  addResource(typeId: number, data: IDirtyCategory): Observable<IJsonResult> {
    return this._http.post<IJsonResult>(`${this.resourcesUrl}/${typeId}`, data);
  }

  updateResource(id: number, data: IDirtyCategory): Observable<IJsonResult> {
    return this._http.post<IJsonResult>(`${this.resourcesUrl}/${id}/update`, data);
  }

  deleteResource(id: number): Observable<IJsonResult> {
    return this._http.delete<IJsonResult>(`${this.resourcesUrl}/${id}`);
  }
}
