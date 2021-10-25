import {Component, OnInit, ViewChild} from '@angular/core';
import {ActivatedRoute, Params, Router} from "@angular/router";
import {PhonebookService} from "../../phonebooks/phonebook-list/phonebook.service";
import {IContact} from "../../contact.model";
import {ContactService} from "../contact.service";
import {IPhonebook} from "../../phonebook";
import {NgForm} from "@angular/forms";

@Component({
  selector: 'app-contact-add-component',
  templateUrl: './contact-add-component.component.html',
  styleUrls: ['./contact-add-component.component.css']
})
export class ContactAddComponentComponent implements OnInit {
  // @ts-ignore
  @ViewChild('f', {static: false}) contactForm: NgForm;
  id: number = 0;
  phonebook: IPhonebook = {
    id: 0,
    name: '',
    entries: []
  }
  contact: IContact = {
    id: 0,
    contactName: '',
    phoneNumber: '',
    phonebookId: 0
  }

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private phonebookService: PhonebookService,
    private contactService: ContactService
  ) { }

  ngOnInit(): void {
    this.route.params
      .subscribe((params: Params) => {
        this.id = +params['id'];
      });
    this.getPhoneBook();
  }

  getPhoneBook(){
    this.phonebookService.getPhonebook(this.id).subscribe(res => {
      this.phonebook = res;
    })
  }
  onSubmit(){
    if(!this.contactForm.valid){
      return;
    }
    this.onClickSave();
  }

  onClickSave(){
    this.contact.phonebookId = this.phonebook.id;
    this.contactService.addNewContact(this.contact).subscribe(res => {
      this.onBack()
    })
  }

  onBack(){
    this.router.navigate(['/phonebookList', + this.phonebook.id])
  }
}
