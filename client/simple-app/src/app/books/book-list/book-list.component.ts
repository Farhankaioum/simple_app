import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { Book } from 'src/app/_models/book';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { BookService } from 'src/app/_services/book.service';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css']
})
export class BookListComponent implements OnInit {
  books: Book[];

  constructor(private alertify: AlertifyService,
              private route: ActivatedRoute,
              private bookService: BookService) { }

  ngOnInit() {
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
      this.bookService.deleteBook(id).subscribe(data => {
        this.alertify.success('delete book successful!');
      }, error => {
        this.alertify.error('delete book unsuccessful!');
      },() => {
        this.bookService.getBooks()
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
      this.bookService.archiveBook(id).subscribe(data => {
        this.loadData();
        this.alertify.success('archive book successful!');
      }, error => {
        this.alertify.error('archive book unsuccessful!');
      },() => {
        this.bookService.getBooks()
          .subscribe((data) => {
            this.books = data;
          }, error => {
            this.alertify.error('errors to get data');
          });
      });
    }
  }

}
