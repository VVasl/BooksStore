import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Order, OrderItem } from "src/app/shared/order";
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  _baseURL: string = "https://localhost:44369/api/Book";

  public books: Book[] = [];
  public order: Order = new Order();

  private token: string = "";
  private tokenExpiration: Date = new Date();

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

  public get loginRequired(): boolean {
    return this.token.length == 0 || this.tokenExpiration > new Date();
  }

  public login(creds) {
    return this.http.post("https://localhost:44369/api/Account/CreateToken", creds)
      .pipe(
        map((response: any) => {
          let tokenInfo = response;
          this.token = tokenInfo.token;
          this.tokenExpiration = tokenInfo.expiration;
          return true;
        }));
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
