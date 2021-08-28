import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { Book } from '../_models/book';
import { AlertifyService } from '../_services/alertify.service';
import { BookService } from '../_services/book.service';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-user-book-list',
  templateUrl: './user-book-list.component.html',
  styleUrls: ['./user-book-list.component.css']
})
export class UserBookListComponent implements OnInit {
  books: Book[];

  constructor(private alertify: AlertifyService,
              private route: ActivatedRoute,
              private bookService: BookService,
              private authService: AuthService) { }

  ngOnInit(): void {
    this.loadData();
  }

  loadData() {
    this.route.data.subscribe(data => {
      console.log('data', data);
      this.books = data.books;
    }, errror => {
      this.alertify.error('Error occured when retrive data!');
    });
  }

  deleteBook(id) 
  {
    if(confirm("Are you sure to delete")) {
      this.bookService.deleteUserBook(id).subscribe(data => {
        this.alertify.success('delete book successful!');
      }, error => {
        this.alertify.error('delete book unsuccessful!');
      },() => {
        this.bookService.getUserBookList()
          .subscribe((data) => {
            this.books = data;
          }, error => {
            this.alertify.error('errors to get data');
          });
      });
    }
  }

  archiveBook(id) 
  {
    if(confirm("Are you sure to archive")) {
      this.bookService.archiveUserBook(id).subscribe(data => {
        this.alertify.success('archive book successful!');
      }, error => {
        this.alertify.error('archive book unsuccessful!');
      },() => {
        this.bookService.getUserBookList()
          .subscribe((data) => {
            this.books = data;
          }, error => {
            this.alertify.error('errors to get data');
          });
      });
    }
  }

}
