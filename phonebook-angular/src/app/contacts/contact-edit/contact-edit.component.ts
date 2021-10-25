import {Component, OnInit, ViewChild} from '@angular/core';
import {ActivatedRoute, Params, Router} from "@angular/router";
import {PhonebookService} from "../../phonebooks/phonebook-list/phonebook.service";
import {ContactService} from "../contact.service";
import {IContact} from "../../contact.model";
import {NgForm} from "@angular/forms";

@Component({
  selector: 'app-contact-edit',
  templateUrl: './contact-edit.component.html',
  styleUrls: ['./contact-edit.component.css']
})
export class ContactEditComponent implements OnInit {
  // @ts-ignore
  @ViewChild('f', {static: false}) contactForm: NgForm;
  id: number = 0;
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
    this.getContact(this.id);
  }

  getContact(id: number){
    this.contactService.getContact(id).subscribe(res =>{
      this.contact = res;
    })
  }
  onSubmit(){
    if(!this.contactForm.valid){
      return;
    }
    this.onClickSave();
  }

  onClickSave(){
    this.contactService.updateContact(this.contact).subscribe(res => {
      this.onBack();
    });
  }

  onBack(){
    this.router.navigate(['phonebookList/' + this.contact.phonebookId.toString()]);
  }
}
