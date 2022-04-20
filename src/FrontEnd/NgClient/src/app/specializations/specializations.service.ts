import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { ISpecialization } from '../shared/models/specialization';

@Injectable({
  providedIn: 'root'
})
export class SpecializationsService {
  baseUrl = 'http://localhost:5010/specialization';

  constructor(private http: HttpClient) { }

  // Get All Specializations
  getSpecializations(): Observable<ISpecialization[]> {
    return this.http.get<ISpecialization[]>(this.baseUrl)
      .pipe(catchError(this.handleError));
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
