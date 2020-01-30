import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Order, OrderItem } from "src/app/shared/order";

@Injectable({
  providedIn: 'root'
})
export class BookService {

  _baseURL: string = "https://localhost:44369/api/Book";

  public books: Book[] = [];
  public order: Order = new Order();

  constructor(private http: HttpClient) { }

  getAllBooks(){
    return this.http.get<Book[]>(this._baseURL+"/GetBooks");
  }

  addBook(book: Book){
    return this.http.post(this._baseURL, book);
  }

  getBookById(id: number){
    return this.http.get<Book>(this._baseURL+'/'+id);
  }

  updateBook(book: Book){
    return this.http.put(this._baseURL+'/'+book.id, book);
  }

  deleteBook(id: number){
    return this.http.delete(this._baseURL+'/'+id);
  }

  public AddToOrder(book: Book) {

    let item: OrderItem = this.order.items.find(i => i.bookId == book.id);

    if (item) {

      item.quantity++;

    } else {

      item = new OrderItem();
      item.bookId = book.id;
      item.bookAuthor = book.authorName;
      item.bookTitle = book.title;
      item.unitPrice = book.price;
      item.quantity = 1;

      this.order.items.push(item);
    }
  }
}
