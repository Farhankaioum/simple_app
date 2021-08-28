import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Book } from 'src/app/_models/book';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { AuthService } from 'src/app/_services/auth.service';
import { BookService } from 'src/app/_services/book.service';

@Component({
  selector: 'app-user-book-edit',
  templateUrl: './user-book-edit.component.html',
  styleUrls: ['./user-book-edit.component.css']
})
export class UserBookEditComponent implements OnInit {
  bookForm: FormGroup;
  book: Book;

  constructor(private authService: AuthService,
    private alertify: AlertifyService,
    private bookService: BookService,
    private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.data.subscribe(data => {
      this.book = data.book;
      console.log('book ', this.book);
    });
    this.createBookForm();
  }

  createBookForm(){
    this.bookForm = this.fb.group({
      title: [this.book.title, Validators.required],
      price: [this.book.price, Validators.required],
      description: [this.book.description, Validators.required],
      userId: [this.book.userId, Validators.required]
    });
  }

  updateBook(){
    if (this.bookForm.valid){
      var bookId = this.book.id;
      this.book = Object.assign({}, this.bookForm.value);
      this.book.id = bookId;
      this.bookService.updateUserBook(this.book)
        .subscribe(() => {
          this.alertify.success('Book update successful');
          this.router.navigate(['/lists']);
        }, error => {
          this.alertify.error(error);
        });
    }
  }

}
