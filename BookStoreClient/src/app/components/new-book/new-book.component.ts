import { Component, OnInit } from '@angular/core';
import { BookService } from 'src/app/services/book.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-new-book',
  templateUrl: './new-book.component.html',
  styleUrls: ['./new-book.component.css']
})
export class NewBookComponent implements OnInit {

  addBookForm: FormGroup;

  constructor(private service: BookService, private fb: FormBuilder, private router: Router) { }

  ngOnInit() {
    this.addBookForm = this.fb.group({
      //id:[Math.floor(Math.random()*1000)],
      title:[null, Validators.required],
      authorName:[null, Validators.required],
      publisherName:[null, Validators.compose([Validators.required, Validators.minLength(30)])],
      price:[null],
      publicationYear:[null]
    })
  }

  onSubmit(){
    this.service.addBook(this.addBookForm.value).subscribe( () => {
      this.router.navigate(["/books"]);
    })
  }
}
// let tour = automapper.map(
//   'TourFormModel',
//   'TourWithManagerForCreation',
//   this.tourForm.value);
// this.tourService.addTourWithManager(tour)
//   .subscribe(
//     () => {
//       this.router.navigateByUrl('/tours');
//     },
//     (validationResult) => 
//     { ValidationErrorHandler.handleValidationErrors(this.tourForm, validationResult); });