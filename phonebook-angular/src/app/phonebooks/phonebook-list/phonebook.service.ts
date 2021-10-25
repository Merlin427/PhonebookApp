import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {INewPhoneBook, IPhonebook} from "../../phonebook";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class PhonebookService {
  readonly ROOT_URL = ' http://localhost:5000/api/';

  constructor(public http: HttpClient) { }

  getPhonebook(id: number): Observable<IPhonebook>{
    return this.http.get<IPhonebook>(this.ROOT_URL + 'phonebooks/' + id)
  }

  getPhonebooksFromApi(): Observable<IPhonebook> {
    return this.http.get<IPhonebook>(this.ROOT_URL + 'phonebooks/details')
  }

  addNewPhonebook(phonebook: INewPhoneBook){
    return this.http.post(this.ROOT_URL + 'phonebooks/create', phonebook)
  }

  editPhoneBook(phonebook: INewPhoneBook){
    return this.http.put(this.ROOT_URL + 'phonebooks/update', phonebook)
  }

  deletePhonebook(id: number) {
    return this.http.delete(this.ROOT_URL + 'phonebooks/' + id)
  }
}

