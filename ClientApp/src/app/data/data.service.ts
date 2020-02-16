import { NewsLetterForm } from './news-letter-form';
import { Injectable, Inject } from '@angular/core';
import { Observable, of, throwError } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, tap, map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {}

  postNewsLetterForm(newsLetterForm: NewsLetterForm): Observable<any> {
    console.log('awdawd');
   const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
   console.log(this.baseUrl + 'testhaha');
    return this.http.post<NewsLetterForm>(this.baseUrl + 'testhaha', newsLetterForm)
      .pipe(
        tap(data => console.log('created news letter : ' + JSON.stringify(data))),
        catchError(err => throwError(err))
      );
  }
}
