import { Component, OnInit } from '@angular/core';
import { BooksService } from './product-list.service';
import { Book } from './model/Book';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
})
export class ProductListComponent implements OnInit {
  books: any;
  bookService: BooksService;

  filteredBooks: Book[] = [];

  _books: Book[] = [];

  _filterBy!: string;

  constructor(bookService: BooksService) {
    this.bookService = bookService;
  }

  ngOnInit(): void {
    this.retrieveAll();
  }

  retrieveAll(): void { 
    this.bookService.getBook().subscribe({
      next: (books: any) => {
        this._books = books;
        this.filteredBooks = this._books;
        console.log(this.books);
      },
      error: (err) => console.log('Error', err),
    });
  }

  set filter(value: string) {
    this._filterBy = value;

    this.filteredBooks = this._books.filter(
      (book: Book) =>
        book.name
          .toLocaleLowerCase()
          .indexOf(this._filterBy.toLocaleLowerCase()) > -1
    );
  }

  get filter() {
    return this._filterBy;
  }
}
