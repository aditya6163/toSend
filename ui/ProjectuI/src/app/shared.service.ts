import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {Observable} from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class SharedService {
readonly APIUrl = "https://localhost:5001/api";

  constructor(private http:HttpClient) { }

  getDocList():Observable<any[]>
  {
    return this.http.get<any>(this.APIUrl+'/doctors');

  }

  addDoc(val:any)
  {
    return this.http.post(this.APIUrl+'/doctors',val);
  }

  updateDoc(val:any)
  {
    return this.http.put(this.APIUrl+'/doctors',val);
  }

  deleteDoc(val:any)
  {
    return this.http.delete(this.APIUrl+'/doctors/',val);
  }

getAllDocNames():Observable<any[]>
{
  return this.http.get<any[]>(this.APIUrl+'/doctors/GetAllDoctors');
}
}
