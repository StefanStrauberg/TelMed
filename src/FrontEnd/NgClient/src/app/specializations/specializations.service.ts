import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError,map } from 'rxjs/operators';
import { IPagination } from '../shared/models/pagination';
import { Params } from '../shared/models/params';
import { ISpecialization } from '../shared/models/specialization';

@Injectable({
  providedIn: 'root'
})
export class SpecializationsService {
  baseUrl = 'http://localhost:5010/specialization';

  constructor(private http: HttpClient) { }

  // Get All Specializations
  getSpecializations(specParams: Params) {
    let params = new HttpParams();
    if(specParams.search){
      params = params.append('search', specParams.search);
    }
    params = params.append('pageIndex', specParams.pageNumber.toString());
    params = params.append('pageSize', specParams.pageSize.toString());
    return this.http.get<IPagination>(this.baseUrl, {observe: 'response', params})
      .pipe(
        map(response => {
          return response.body;
        })
      );
  }

  // Get By Id Specialization
  getSpecialization(id: string): Observable<ISpecialization> {
    return this.http.get<ISpecialization>(this.baseUrl + `/${id}`)
    .pipe(catchError(this.handleError));
  }

  // Create Specialization
  createSpecialization(model: ISpecialization): Observable<{}> {
    return this.http.post<{}>(this.baseUrl, model)
      .pipe(catchError(this.handleError));
  }

  // Update Specialization
  updateSpecialization(model: ISpecialization, id: string): Observable<{}> {
    return this.http.put<{}>(this.baseUrl + `/${id}`, model)
      .pipe(catchError(this.handleError));
  }

  // Delete Specialization
  deleteSpecialization(id: string): Observable<{}> {
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
