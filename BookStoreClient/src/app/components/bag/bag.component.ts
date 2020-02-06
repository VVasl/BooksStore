import { Component, OnInit } from '@angular/core';
import { BookService } from 'src/app/services/book/book.service';
import { Router } from "@angular/router";

@Component({
  selector: 'app-bag',
  templateUrl: './bag.component.html',
  styleUrls: ['./bag.component.css']
})
export class BagComponent implements OnInit {

  constructor(public data: BookService, private router: Router) { }

  ngOnInit() {
  }
  onCheckout() {
    if (this.data.loginRequired) {
      this.router.navigate(["login"]);
    } else {
      this.router.navigate(["checkout"]);
    }
  }
}
