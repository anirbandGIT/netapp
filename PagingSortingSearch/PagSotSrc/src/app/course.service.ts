import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/internal/operators/map';
@Injectable({
  providedIn: 'root'
})
export class CourseService {

  constructor(private http: HttpClient) { }

  public getCourseDetails(): Observable<any> {
    return this.http.get('https://localhost:5001/api/course');
  }
  public getCovidDetails(): Observable<any> {
    return this.http.get('https://api.covid19india.org/data.json').pipe(map((res: any) => {
      console.log(res.statewise);
    }));
  }
}
