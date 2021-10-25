import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule} from "@angular/common/http";
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { ContactAddComponentComponent } from './contacts/contact-add-component/contact-add-component.component';
import {FormsModule} from "@angular/forms";
import { PhonebookListComponent } from './phonebooks/phonebook-list/phonebook-list.component';
import { PhonebookItemComponent } from './phonebooks/phonebook-list/phonebook-item/phonebook-item.component';
import {AppRoutingModule} from "./app-routing.module";
import { PhonebookDetailComponent } from './phonebooks/phonebook-list/phonebook-item/phonebook-detail/phonebook-detail.component';
import { PhonebookEditComponent } from './phonebooks/phonebook-list/phonebook-edit/phonebook-edit.component';
import { PhonebookNewComponent } from './phonebooks/phonebook-list/phonebook-new/phonebook-new.component';
import { ContactEditComponent } from './contacts/contact-edit/contact-edit.component';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import {MatDialogModule} from "@angular/material/dialog";
import { DeleteDialogueComponent } from './delete-dialogue/delete-dialogue.component';
import {MatButtonModule} from "@angular/material/button";


@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    ContactAddComponentComponent,
    PhonebookListComponent,
    PhonebookItemComponent,
    PhonebookDetailComponent,
    PhonebookEditComponent,
    PhonebookNewComponent,
    ContactEditComponent,
    DeleteDialogueComponent,

  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
    NoopAnimationsModule,
    MatDialogModule,
    MatButtonModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
