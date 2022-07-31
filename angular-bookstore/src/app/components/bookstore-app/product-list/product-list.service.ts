import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Book } from './model/Book';
import { Observable } from 'rxjs';

@Injectable()
export class BooksService {
  private url = 'http://localhost:5001/api/bookstore';

  constructor(private http: HttpClient) {}

  getBook(): Observable<Book[]> {
    return this.http.get<Book[]>(this.url);
  }
}
