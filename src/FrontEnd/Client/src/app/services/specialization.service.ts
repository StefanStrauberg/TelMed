import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { ISpecialization } from '../models/ISpecialization';

@Injectable({
  providedIn: 'root'
})
export class SpecializationService {

  stringUrl: string = 'http://localhost:5001/api/specialization';

  constructor(private httpClient: HttpClient) { }

  //Get All Specialization
  getAllSpecializations(): Observable<ISpecialization[]> {
    let dataUrl: string = `${this.stringUrl}`;
    return this.httpClient.get<ISpecialization[]>(dataUrl).pipe(catchError(this.handleError));
  }

  //Get Specialization By Id
  getSpecialization(specializationId: string): Observable<ISpecialization>{
    let dataUrl: string = `${this.stringUrl}/${specializationId}`;
    return this.httpClient.get<ISpecialization>(dataUrl).pipe(catchError(this.handleError));
  }

  //Create Specialization
  createSpecialization(specialization: ISpecialization): Observable<{}>{
    let dataUrl: string = `${this.stringUrl}`;
    return this.httpClient.post<{}>(dataUrl, specialization).pipe(catchError(this.handleError));
  }

  //Update Specialization
  updateSpecialization(specialization: ISpecialization): Observable<{}>{
    let dataUrl: string = `${this.stringUrl}`;
    return this.httpClient.put<{}>(dataUrl, specialization).pipe(catchError(this.handleError));
  }

  //Delete Organization
  deleteSpecialization(specializationId: string): Observable<{}>{
    let dataUrl: string = `${this.stringUrl}/${specializationId}`;
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
