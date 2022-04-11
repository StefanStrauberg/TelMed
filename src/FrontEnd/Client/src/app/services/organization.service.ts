import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { IOrganization } from '../models/IOrganization';

@Injectable({
  providedIn: 'root'
})
export class OrganizationService {

  stringUrl: string = 'http://localhost:5000/api/organization';

  constructor(private httpClient: HttpClient) { }

  //Get All Organizations
  getAllOrganizations(): Observable<IOrganization[]> {
    let dataUrl: string = `${this.stringUrl}`;
    return this.httpClient.get<IOrganization[]>(dataUrl).pipe(catchError(this.handleError));
  }

  //Get Organizations By Id
  getOrganization(organizationId: string): Observable<IOrganization>{
    let dataUrl: string = `${this.stringUrl}/${organizationId}`;
    return this.httpClient.get<IOrganization>(dataUrl).pipe(catchError(this.handleError));
  }

  //Create Organization
  createOrganization(organization: IOrganization): Observable<{}>{
    let dataUrl: string = `${this.stringUrl}`;
    return this.httpClient.post<{}>(dataUrl, organization).pipe(catchError(this.handleError));
  }

  //Update Organization
  updateOrganization(organization: IOrganization): Observable<{}>{
    let dataUrl: string = `${this.stringUrl}`;
    return this.httpClient.put<{}>(dataUrl, organization).pipe(catchError(this.handleError));
  }

  //Delete Organization
  deleteOrganization(organizationId: string): Observable<{}>{
    let dataUrl: string = `${this.stringUrl}/${organizationId}`;
    return this.httpClient.delete<{}>(dataUrl).pipe(catchError(this.handleError));
  }

  // Error Handling
  handleError(error: HttpErrorResponse){
    let errorMessage: string = '';
    if(error.error instanceof ErrorEvent){
      errorMessage = `Error: ${error.error.message}`;
    }
    else{
      errorMessage = `Status: ${error.status} \n Message: ${error.message}`;
    }
    return throwError(errorMessage);
  }
}
