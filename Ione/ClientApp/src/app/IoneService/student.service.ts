import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { StudentModel } from '../IoneModel/StudentModel';
@Injectable({
  providedIn: 'root'
})
export class StudentService {

  baseurl: string;
  ////baseurl ='http://localhost:5001/';
  constructor(private http: HttpClient, @Inject('BASE_URL') _baseurl: string) { this.baseurl = _baseurl; }
  Create(StudentModel: StudentModel): Observable<StudentModel> {
    let reqHeader = new HttpHeaders();
    reqHeader.append('Content-Type', 'application/json');
    return this.http.post<StudentModel>(this.baseurl + 'api/SudentTables', StudentModel, { headers: reqHeader });
  }




  GetById(StudentId: any): Observable<StudentModel> {
    let reqHeader = new HttpHeaders();
    reqHeader.append('Content-Type', 'application/json');
    return this.http.get<StudentModel>(this.baseurl + 'api/SudentTables/' + StudentId, { headers: reqHeader });
  }
  GetAll(): Observable<StudentModel> {
    let reqHeader = new HttpHeaders();
    reqHeader.append('Content-Type', 'application/json');

    return this.http.get<StudentModel>(this.baseurl + 'api/SudentTables', { headers: reqHeader });
    //return this.http.get<NotePad>(this.baseurl + 'api/Products');
  }
  Update(StudentId: any, StudentModel: StudentModel): Observable<StudentModel> {
    let reqHeader = new HttpHeaders();
    reqHeader.append('Content-Type', 'application/json');
    return this.http.put<StudentModel>(this.baseurl + 'api/SudentTables/' + StudentId, StudentModel, { headers: reqHeader });
  }
  Delete(StudentId: any): Observable<StudentModel> {
    let reqHeader = new HttpHeaders();
    reqHeader.append('Content-Type', 'application/json');
    return this.http.delete<StudentModel>(this.baseurl + 'api/SudentTables/' + StudentId, { headers: reqHeader });
  }
}
