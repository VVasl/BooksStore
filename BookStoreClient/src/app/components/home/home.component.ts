import { Component, OnInit } from '@angular/core';
import { BookService } from 'src/app/services/book/book.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  public books: Book[];

  constructor(private service: BookService) {
    this.books = service.books;
   }

  ngOnInit() {
    this.service.getAllBooks().subscribe(data => {
      this.books = data;
    })
  }

  public createImgPath = (serverPath: string) => {
    return `${serverPath}`;
  }

  addBook(book: Book) {
    this.service.AddToOrder(book);
  }

}
