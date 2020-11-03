import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';
import { IResourceCategoryHttp } from '../models/http-models/resourceCategory-http.interface';
import {IJsonResult} from "../models/jsonResult.interface";
import {IDirtyCategory} from "../models/dirtyCategory.interface";

@Injectable()
export class ResourceCategoryService {
  resourceCategoriesUrl = `${environment.apiUrl}/category`;

  constructor(private _http: HttpClient) { }

  getResourceCategories(): Observable<IResourceCategoryHttp> {
    return this._http.get<IResourceCategoryHttp>(this.resourceCategoriesUrl);
  }

  addResourceCategory(data: IDirtyCategory): Observable<IJsonResult> {
    return this._http.post<IJsonResult>(this.resourceCategoriesUrl, data);
  }

  updateResourceCategory(id: number, data: IDirtyCategory): Observable<IJsonResult> {
    return this._http.post<IJsonResult>(`${this.resourceCategoriesUrl}/${id}/update`, data);
  }

  deleteResourceCategory(id: number): Observable<IJsonResult> {
    return this._http.delete<IJsonResult>(`${this.resourceCategoriesUrl}/${id}`);
  }
}
