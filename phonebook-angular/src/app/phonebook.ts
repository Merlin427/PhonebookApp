import {IContact} from "./contact.model";

export interface IPhonebook{
  id: number;
  name: string;
  entries: IContact[];
}

export interface INewPhoneBook{
  id:number;
  name: string;
}

export class Phonebook{
  public id: number;
  public name: string;

  constructor(id: number,name: string) {
   this.id = id;
    this.name = name;
  }
}
