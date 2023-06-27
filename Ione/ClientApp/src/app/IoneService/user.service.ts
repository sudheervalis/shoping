import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { UserModel } from '../IoneModel/UserModel';
@Injectable({
  providedIn: 'root'
})
export class UserService {

  baseurl: string;
  ////baseurl ='http://localhost:5001/';
  constructor(private http: HttpClient, @Inject('BASE_URL') _baseurl: string) { this.baseurl = _baseurl; }
  Create(UserModel: UserModel): Observable<UserModel> {
    let reqHeader = new HttpHeaders();
    reqHeader.append('Content-Type', 'application/json');
    return this.http.post<UserModel>(this.baseurl + 'api/UserDatums', UserModel, { headers: reqHeader });
  }




  GetById(Id: any): Observable<UserModel> {
    let reqHeader = new HttpHeaders();
    reqHeader.append('Content-Type', 'application/json');
    return this.http.get<UserModel>(this.baseurl + 'api/UserDatums/' + Id, { headers: reqHeader });
  }
  GetAll(): Observable<UserModel> {
    let reqHeader = new HttpHeaders();
    reqHeader.append('Content-Type', 'application/json');

    return this.http.get<UserModel>(this.baseurl + 'api/UserDatums', { headers: reqHeader });
    //return this.http.get<NotePad>(this.baseurl + 'api/Products');
  }
  Update(Id: any, UserModel: UserModel): Observable<UserModel> {
    let reqHeader = new HttpHeaders();
    reqHeader.append('Content-Type', 'application/json');
    return this.http.put<UserModel>(this.baseurl + 'api/UserDatums/' + Id, UserModel, { headers: reqHeader });
  }
  Delete(Id: any): Observable<UserModel> {
    let reqHeader = new HttpHeaders();
    reqHeader.append('Content-Type', 'application/json');
    return this.http.delete<UserModel>(this.baseurl + 'api/UserDatums/' + Id, { headers: reqHeader });
  }
}
