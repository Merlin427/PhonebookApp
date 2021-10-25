import {NgModule} from "@angular/core";
import {RouterModule, Routes} from "@angular/router";
import {PhonebookItemComponent} from "./phonebooks/phonebook-list/phonebook-item/phonebook-item.component";
import {PhonebookListComponent} from "./phonebooks/phonebook-list/phonebook-list.component";
import {PhonebookDetailComponent} from "./phonebooks/phonebook-list/phonebook-item/phonebook-detail/phonebook-detail.component";
import {PhonebookEditComponent} from "./phonebooks/phonebook-list/phonebook-edit/phonebook-edit.component";
import {ContactAddComponentComponent} from "./contacts/contact-add-component/contact-add-component.component";
import {PhonebookNewComponent} from "./phonebooks/phonebook-list/phonebook-new/phonebook-new.component";
import {ContactEditComponent} from "./contacts/contact-edit/contact-edit.component";

const appRoutes: Routes = [
  {path: '', redirectTo: '/phonebookList', pathMatch: 'full'},
  {path: 'phonebookList', component: PhonebookListComponent},
  {path: 'phonebookList/:id', component: PhonebookDetailComponent},
  {path: 'addPhonebook', component: PhonebookNewComponent},
  {path: 'newEntry', component: ContactAddComponentComponent},
  {path: 'newEntry/:id', component: ContactAddComponentComponent},
  {path: 'editPhoneBook/:id', component: PhonebookEditComponent},
  {path: 'editContact/:id', component: ContactEditComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule]

})
export class AppRoutingModule{

}
