import { Component, OnInit } from '@angular/core';
import { BookService } from 'src/app/services/book.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  public books: Book[];

  constructor(private service: BookService) { }

  ngOnInit() {
    this.service.getAllBooks().subscribe(data => {
      this.books = data;
    })
  }

  public createImgPath = (serverPath: string) => {
    return `https://localhost:44369/Resources/Images/${serverPath}.jpg`;
}

}
