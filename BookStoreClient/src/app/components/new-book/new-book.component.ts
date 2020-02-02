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
  selectedFile: File = null;
  public response: {'dbPath': ''}; 

  constructor(private service: BookService, private fb: FormBuilder, private router: Router) { }

  ngOnInit() {
    this.addBookForm = this.fb.group({
      title:[null, Validators.required],
      authorName:[null, Validators.required],
      publisherName:[null, Validators.compose([Validators.required, Validators.minLength(30)])],
      price:[null],
      publicationYear:[null],
      image: [null]
    })
  }

  onSelectFile(fileInput: any) {
    this.selectedFile = <File>fileInput.target.files[0].name;
  }


  onSubmit(){
    this.service.addBook(this.addBookForm.value).subscribe( () => {
      this.router.navigate(["/books"]);
    })
  }
}