import { Component } from '@angular/core';
import { BookService } from './services/book/book.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'BookStoreClient';
  constructor(public data: BookService, private router: Router) { }


  onLog() {
    if (this.data.loginRequired) {
      this.router.navigate(["login"]);
    } else {
      this.router.navigate(["/books"]);
    }
  }
}


