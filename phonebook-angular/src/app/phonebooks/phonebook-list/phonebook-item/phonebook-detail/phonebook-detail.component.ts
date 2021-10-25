import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Params} from "@angular/router";
import {IPhonebook} from "../../../../phonebook";
import {PhonebookService} from "../../phonebook.service";
import {ContactService} from "../../../../contacts/contact.service";
import {DeleteDialogueComponent} from "../../../../delete-dialogue/delete-dialogue.component";
import {MatDialog} from "@angular/material/dialog";

@Component({
  selector: 'app-phonebook-detail',
  templateUrl: './phonebook-detail.component.html',
  styleUrls: ['./phonebook-detail.component.css']
})
export class PhonebookDetailComponent implements OnInit {
  id: number = 0;
  entriesLoaded: boolean = false;
  phonebook: IPhonebook = {
    id: 0,
    name: '',
    entries: [],


  }

  constructor(
    public dialog: MatDialog,
    private route: ActivatedRoute,
    private phonebookService: PhonebookService,
    private contactService: ContactService) { }

  ngOnInit(): void {
    this.route.params
      .subscribe((params: Params) => {
      this.id = +params['id'];
    });
    this.getPhoneBook();
  }

  // @ts-ignore
  openDialog(id) {
    const dialogRef = this.dialog.open(DeleteDialogueComponent);

    dialogRef.afterClosed().subscribe(result => {
      console.log(result)
      if(result == true){
        this.onDelete(id)
      }
    });
  }

  getPhoneBook(){
    this.phonebookService.getPhonebook(this.id).subscribe(res => {
      this.phonebook = res;
      if(this.phonebook.entries.length > 0){
        this.entriesLoaded = true;
      }
    });
  }

  onDelete(id: number){
   this.entriesLoaded = false;
    this.contactService.deleteContact(id).subscribe(res => {
      this.getPhoneBook()
    });
  }
}
