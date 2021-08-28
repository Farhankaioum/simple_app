import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { Book } from 'src/app/_models/book';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { BookService } from 'src/app/_services/book.service';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-book-edit',
  templateUrl: './book-edit.component.html',
  styleUrls: ['./book-edit.component.css']
})
export class BookEditComponent implements OnInit {
  bookForm: FormGroup;
  @ViewChild('editForm', {static: true}) editForm: NgForm;
  book: Book;

  constructor(private bookService: BookService,
    private alertify: AlertifyService,
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private router: Router) { }

    ngOnInit() {
      this.route.data.subscribe(data => {
        this.book = data.book;
        console.log('book ', this.book);
      });
      this.editBookForm();
    }

    editBookForm(){
      this.bookForm = this.fb.group({
        title: [this.book.title, Validators.required],
        price: [this.book.price, Validators.required],
        description: [this.book.description, Validators.required]
      });
    }

    editBook(){
      if (this.bookForm.valid){
        var id = this.book.id;
        this.book = Object.assign({}, this.bookForm.value);
        this.book.id = id;
        this.bookService.updateBook(this.book)
          .subscribe(() => {
            this.alertify.success('Book update successful');
            this.router.navigate(['/book-list']);
          }, error => {
            this.alertify.error(error);
          });
      }
    }

}
