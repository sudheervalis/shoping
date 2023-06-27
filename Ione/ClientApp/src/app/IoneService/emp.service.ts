import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { EmpModel } from '../IoneModel/EmpModel';

@Injectable({
  providedIn: 'root'
})
export class EmpService {

  //baseurl: string;
  baseurl ='http://localhost:7272/';
  constructor(private http: HttpClient, @Inject('BASE_URL') _baseurl: string) { this.baseurl = _baseurl; }
  Create(EmpModel: EmpModel): Observable<EmpModel> {
    let reqHeader = new HttpHeaders();
    reqHeader.append('Content-Type', 'application/json');
    return this.http.post<EmpModel>(this.baseurl + 'api/EmpTables', EmpModel, { headers: reqHeader });
  }




  GetById(EmpId: any): Observable<EmpModel> {
    let reqHeader = new HttpHeaders();
    reqHeader.append('Content-Type', 'application/json');
    return this.http.get<EmpModel>(this.baseurl + 'api/EmpTables/' + EmpId, { headers: reqHeader });
  }
  GetAll(): Observable<EmpModel> {
    let reqHeader = new HttpHeaders();
    reqHeader.append('Content-Type', 'application/json');

    return this.http.get<EmpModel>(this.baseurl + 'api/EmpTables', { headers: reqHeader });
    //return this.http.get<NotePad>(this.baseurl + 'api/Products');
  }
  Update(EmpId: any, EmpModel: EmpModel): Observable<EmpModel> {
    let reqHeader = new HttpHeaders();
    reqHeader.append('Content-Type', 'application/json');
    return this.http.put<EmpModel>(this.baseurl + 'api/EmpTables/' + EmpId, EmpModel, { headers: reqHeader });
  }
  Delete(EmpId: any): Observable<EmpModel> {
    let reqHeader = new HttpHeaders();
    reqHeader.append('Content-Type', 'application/json');
    return this.http.delete<EmpModel>(this.baseurl + 'api/EmpTables/' + EmpId, { headers: reqHeader });
  }
}
