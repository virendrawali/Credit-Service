import { Injectable } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClient, HttpHeaders } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private fb: FormBuilder, private http: HttpClient) { }
  readonly BaseURI = 'https://localhost:44364/api';

  login(formData) {
    debugger;
    return this.http.post(this.BaseURI + '/customer/get', formData);

  }

  getUserProfile(username) {
    debugger;
    return this.http.post(this.BaseURI + '/customer/get',{username:username});
  }

  updateProfile(formData)
  {
    debugger;
    return this.http.post(this.BaseURI + '/customer/update', {username:localStorage.token,balance:formData.balance});
  }
}
