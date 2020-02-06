import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor( private http: HttpClient) { }

  readonly _baseURL = "https://localhost:44369/api/Account/Register";
  

  register(user: User){
    return this.http.post(this._baseURL, user);
  }
}