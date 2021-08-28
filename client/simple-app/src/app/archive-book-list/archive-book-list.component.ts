import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';

import { Book } from 'src/app/_models/book';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { BookService } from 'src/app/_services/book.service';

@Component({
  selector: 'app-archive-book-list',
  templateUrl: './archive-book-list.component.html',
  styleUrls: ['./archive-book-list.component.css']
})
export class ArchiveBookListComponent implements OnInit {
  books: Book[];

  constructor(private alertify: AlertifyService,
    private route: ActivatedRoute,
    private bookService: BookService,
    private router: Router) { }

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

  restoreBook(id) 
  {
    this.bookService.retoreBookById(id).subscribe(data => {
      this.alertify.success('Restore book successful!');
    }, error => {
      this.alertify.error('Restore book unsuccessful!');
    },() => {
      this.bookService.getArchiveBooks()
        .subscribe((data) => {
          this.books = data;
        }, error => {
          this.alertify.error('errors to get data');
        });
    });
    
  }

  restoreAllBook() 
  {
    this.bookService.retoreAllBook().subscribe(data => {
      this.alertify.success('Restore all books successful!');
    }, error => {
      this.alertify.error('Restore book unsuccessful!');
    }, () => {
      this.bookService.getArchiveBooks()
        .subscribe((data) => {
          this.books = data;
        }, error => {
          this.alertify.error('errors to get data');
        });
    });
    
  }

}
