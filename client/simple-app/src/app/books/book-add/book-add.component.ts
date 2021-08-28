import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Book } from 'src/app/_models/book';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { AuthService } from 'src/app/_services/auth.service';
import { BookService } from 'src/app/_services/book.service';

@Component({
  selector: 'app-book-add',
  templateUrl: './book-add.component.html',
  styleUrls: ['./book-add.component.css']
})
export class BookAddComponent implements OnInit {
  bookForm: FormGroup;
  book: Book;

  constructor(private authService: AuthService,
    private alertify: AlertifyService,
    private bookService: BookService,
    private fb: FormBuilder,
    private router: Router) { }

  ngOnInit(): void {
    this.createBookForm();
  }

  createBookForm(){
    this.bookForm = this.fb.group({
      title: ['', Validators.required],
      price: ['', Validators.required],
      description: ['', Validators.required]
    });
  }

  addBook(){
    if (this.bookForm.valid){
      this.book = Object.assign({}, this.bookForm.value);
      this.bookService.postBook(this.book)
        .subscribe(() => {
          this.alertify.success('Book added successful');
          this.router.navigate(['/book-list']);
        }, error => {
          this.alertify.error(error);
        });
    }
  }

}
