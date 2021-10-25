export class Contact{
  public name: string;
  public telephoneNumber: string;

  constructor(name: string, telephoneNumber: string) {
    this.name = name;
    this.telephoneNumber = telephoneNumber;
  }
}

export interface IContact{
  id: number;
  contactName: string;
  phoneNumber: string;
  phonebookId: number;
}
