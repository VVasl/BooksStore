import { Component, OnInit } from '@angular/core';
import { BookService } from 'src/app/services/book.service';
import { Router } from "@angular/router";

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {

  constructor(public data: BookService, public router: Router) {
  }

  ngOnInit() {
  }
  

}
