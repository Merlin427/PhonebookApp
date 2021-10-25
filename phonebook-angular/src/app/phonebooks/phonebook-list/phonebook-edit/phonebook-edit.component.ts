import {Component, OnInit, ViewChild} from '@angular/core';
import {ActivatedRoute, Params, Router} from "@angular/router";
import {PhonebookService} from "../phonebook.service";
import {INewPhoneBook} from "../../../phonebook";
import {NgForm} from "@angular/forms";

@Component({
  selector: 'app-phonebook-edit',
  templateUrl: './phonebook-edit.component.html',
  styleUrls: ['./phonebook-edit.component.css']
})
export class PhonebookEditComponent implements OnInit {
  // @ts-ignore
  @ViewChild('f', {static: false}) phonebookForm: NgForm;
  id: number = 0;
  phonebook: INewPhoneBook = {
    id: 0,
    name: ''
  }

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private phonebookService: PhonebookService
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
    if (!this.phonebookForm.valid){
      return
    }
   this.onClickSave()
 }
  onClickSave(){
    this.phonebookService.editPhoneBook(this.phonebook).subscribe(res => {
      this.onBack()
    } );
  }


  onBack(){
    this.router.navigate(['/phonebookList'])
  }

}
