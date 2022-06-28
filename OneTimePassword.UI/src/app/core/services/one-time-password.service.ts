import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { catchError, map, Observable, throwError } from "rxjs";
import { GeneratedPasswordModel, UserOtpRequestModel } from "../models/generated-password.model";

@Injectable({
    providedIn: 'root'
})
export class OneTimePasswordService {
    apiPath: string;

    constructor(private httpClient: HttpClient) {
        this.apiPath = 'http://localhost:32929/';
    }

    getPassword(userOtpRequest: UserOtpRequestModel): Observable<GeneratedPasswordModel> {
        return this.httpClient.post<GeneratedPasswordModel>(`${this.apiPath}api/PasswordGenerator/GetCurrentPassword`, userOtpRequest)
            .pipe(
                map(response => { return response; }),
                catchError(transformError)
            );
    }
}

function transformError(error: HttpErrorResponse | string) {
    let errorMessage = 'Something bad happened; please try again later.';
  
    if (typeof error === 'string') {
      errorMessage = error;
    } else if (error.error instanceof ErrorEvent || (error.error && error.error.message)) {
      errorMessage = `${error.error.message}`;
    } else if (error.status) {
      errorMessage = `Request failed with ${error.status} ${error.statusText}`;
      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${error.error}`);
    }
  
    return throwError(() => errorMessage);
}