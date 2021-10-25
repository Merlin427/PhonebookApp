import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {IContact} from "../contact.model";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class ContactService {
  readonly ROOT_URL = 'http://localhost:5000/api/';

  constructor(public http: HttpClient) { }

  getContact(id: number): Observable<IContact>{
    return this.http.get<IContact>(this.ROOT_URL + 'contacts/' + id);
  }

  addNewContact(contact: IContact) {
    return this.http.post(this.ROOT_URL + 'contacts/create', contact);
  }

  updateContact(contact: IContact) {
    return this.http.put(this.ROOT_URL + 'contacts/update', contact);
  }

  deleteContact(id: number){
    return this.http.delete(this.ROOT_URL + 'contacts/' + id)
  }
}

