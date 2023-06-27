import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { LoginModel } from '../IoneModel/LoginModel';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  baseurl: string;
  ////baseurl ='http://localhost:5001/';
  constructor(private http: HttpClient, @Inject('BASE_URL') _baseurl: string) { this.baseurl = _baseurl; }
  Create(LoginModel: LoginModel): Observable<LoginModel> {
    let reqHeader = new HttpHeaders();
    reqHeader.append('Content-Type', 'application/json');
    return this.http.post<LoginModel>(this.baseurl + 'api/ChairmanDetails', LoginModel, { headers: reqHeader });
  }




  GetById(Id: any): Observable<LoginModel> {
    let reqHeader = new HttpHeaders();
    reqHeader.append('Content-Type', 'application/json');
    return this.http.get<LoginModel>(this.baseurl + 'api/ChairmanDetails/' + Id, { headers: reqHeader });
  }
  GetAll(): Observable<LoginModel> {
    let reqHeader = new HttpHeaders();
    reqHeader.append('Content-Type', 'application/json');

    return this.http.get<LoginModel>(this.baseurl + 'api/ChairmanDetails', { headers: reqHeader });
    //return this.http.get<NotePad>(this.baseurl + 'api/Products');
  }
  Update(Id: any, LoginModel: LoginModel): Observable<LoginModel> {
    let reqHeader = new HttpHeaders();
    reqHeader.append('Content-Type', 'application/json');
    return this.http.put<LoginModel>(this.baseurl + 'api/ChairmanDetails/' + Id, LoginModel, { headers: reqHeader });
  }
  Delete(Id: any): Observable<LoginModel> {
    let reqHeader = new HttpHeaders();
    reqHeader.append('Content-Type', 'application/json');
    return this.http.delete<LoginModel>(this.baseurl + 'api/ChairmanDetails/' + Id, { headers: reqHeader });
  }
}
