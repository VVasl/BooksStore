import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { BooksComponent } from './components/books/books.component';
import { DeleteBookComponent } from './components/delete-book/delete-book.component';
import { NewBookComponent } from './components/new-book/new-book.component';
import { ShowBookComponent } from './components/show-book/show-book.component';
import { UpdateBookComponent } from './components/update-book/update-book.component';
const routes: Routes = [];

@NgModule({
  declarations: [
    BooksComponent,
    DeleteBookComponent,
    NewBookComponent,
    ShowBookComponent,
    UpdateBookComponent
  ],
  imports: [
    RouterModule.forRoot([
      { path: 'books', component: BooksComponent},
      { path: 'new-book', component: NewBookComponent},
      { path: 'update-book/:id', component: UpdateBookComponent},
      { path: 'delete-book/:id', component: DeleteBookComponent},
      { path: 'show-book/:id', component: ShowBookComponent}
    ])
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
