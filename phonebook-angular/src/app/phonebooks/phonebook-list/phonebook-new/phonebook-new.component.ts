import {Component, OnInit, ViewChild} from '@angular/core';
import {INewPhoneBook} from "../../../phonebook";
import {PhonebookService} from "../phonebook.service";
import {Router} from "@angular/router";
import {NgForm} from "@angular/forms";

@Component({
  selector: 'app-phonebook-new',
  templateUrl: './phonebook-new.component.html',
  styleUrls: ['./phonebook-new.component.css']
})
export class PhonebookNewComponent implements OnInit {
  // @ts-ignore
  @ViewChild('f', {static: false}) phonebookForm: NgForm;
  phonebook: INewPhoneBook = {
    id : 0,
    name: ''
  }

  constructor(
    private phonebookService: PhonebookService,
  private router: Router) { }

  ngOnInit(): void {
  }

  onSubmit(){
    if(!this.phonebookForm.valid){
      return;
    }
    this.onAddClick()
  }

  onAddClick(){
    this.phonebookService.addNewPhonebook(this.phonebook).subscribe(res => {
      this.onBack();
    });
  }

  onBack(){
    this.router.navigate(['/phonebookList'])
  }
}
