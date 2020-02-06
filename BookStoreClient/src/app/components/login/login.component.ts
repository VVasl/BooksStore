import { Component, OnInit } from '@angular/core';
import { Router } from "@angular/router";
import { BookService } from 'src/app/services/book/book.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private data: BookService, private router: Router) { }

  errorMessage: string = "";
  authenticated: boolean = false;
  public creds = {
    email: "",
    password: ""
  };

  ngOnInit() {
  }

  onLogin() {
    this.errorMessage = "";
    this.authenticated = false;
    this.data.login(this.creds)
      .subscribe(success => {
        if (success) {
          if (this.data.order.items.length == 0) {
            this.authenticated = true;
            this.router.navigate([""]);
          } else {
            this.router.navigate(["checkout"]);
          }
        }
      }, (err => {
        this.errorMessage = "Failed to login";
        this.authenticated = false;
      }))
  }

  logout() {
    this.authenticated = false;
    this.data.logout();
    this.router.navigateByUrl("/login");
  }

  createAccount(){
    this.router.navigate(["/registration"]);
  }
}
