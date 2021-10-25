import { Component, OnInit } from '@angular/core';
import {PhonebookService} from "../phonebook.service";
import {MatDialog} from "@angular/material/dialog";
import {DeleteDialogueComponent} from "../../../delete-dialogue/delete-dialogue.component";

@Component({
  selector: 'app-phonebook-item',
  templateUrl: './phonebook-item.component.html',
  styleUrls: ['./phonebook-item.component.css']
})
export class PhonebookItemComponent implements OnInit {
  phonebooks: any[];


  constructor(
    public dialog: MatDialog,
    private phonebookService: PhonebookService
  ) {
    this.phonebooks = [];
  }

  ngOnInit(): void {
    this.getPhonebooks();
  }

  // @ts-ignore
  openDialog(id) {
    const dialogRef = this.dialog.open(DeleteDialogueComponent);

    dialogRef.afterClosed().subscribe(result => {
      if (result == true) {
        this.onDeletePhonebook(id)
      }
    });
  }

  getPhonebooks(){
    this.phonebookService.getPhonebooksFromApi().subscribe((res: any) => {
      this.phonebooks = res;
    });
  }

  onDeletePhonebook(phonebookId: number){
    this.phonebookService.deletePhonebook(phonebookId).subscribe(res => {
      this.getPhonebooks();
    })
  }
}
