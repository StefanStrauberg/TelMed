import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { IOrganization } from '../shared/models/organization';
import { catchError,map } from 'rxjs/operators';
import { Params } from '../shared/models/params';
import { IPagination } from '../shared/models/pagination';

@Injectable({
  providedIn: 'root'
})
export class OrganizationsService {
  baseUrl = 'http://localhost:5010/organization';

  constructor(private http: HttpClient) { }

  // Get All Organizations
  getOrganizations(orgParams: Params) {
    let params = new HttpParams();
    if(orgParams.search){
      params = params.append('search', orgParams.search);
    }
    params = params.append('pageIndex', orgParams.pageNumber.toString());
    params = params.append('pageSize', orgParams.pageSize.toString());
    return this.http.get<IPagination>(this.baseUrl, {observe: 'response', params})
    .pipe(
      map(response => {
        return response.body;
      })
    );
  }

  // Get By Id Organization
  getOrganization(id: string): Observable<IOrganization> {
    return this.http.get<IOrganization>(this.baseUrl + `/${id}`)
    .pipe(catchError(this.handleError));
  }

  // Create Organization
  createOrganization(model: IOrganization): Observable<{}> {
    return this.http.post<{}>(this.baseUrl, model)
      .pipe(catchError(this.handleError));
  }

  // Update Organization
  updateOrganization(model: IOrganization, id: string): Observable<{}> {
    return this.http.put<{}>(this.baseUrl + `/${id}`, model)
      .pipe(catchError(this.handleError));
  }

  // Delete Organization
  deleteOrganization(id: string): Observable<{}> {
    return this.http.delete<{}>(this.baseUrl + `/${id}`)
      .pipe(catchError(this.handleError));
  }

  // Error handling
  handleError(error: any) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    window.alert(errorMessage);
    return throwError(() => {
      return errorMessage;
    });
  }
}
