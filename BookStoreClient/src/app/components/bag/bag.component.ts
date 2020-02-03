import { Component, OnInit } from '@angular/core';
import { BookService } from 'src/app/services/book.service';
import { Router } from "@angular/router";

@Component({
  selector: 'app-cart',
  templateUrl: './bag.component.html',
  styleUrls: ['./bag.component.css']
})
export class BagComponent implements OnInit {

  constructor(public data: BookService, private router: Router) { }

  ngOnInit() {
  }
  onCheckout() {
    if (this.data.loginRequired) {
      // Force Login
      this.router.navigate(["login"]);
    } else {
      // Go to checkout
      this.router.navigate(["checkout"]);
    }
  }
}
