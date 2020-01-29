using BooksStore.Data.Entities;
using System.Collections.Generic;

namespace BooksStore.Data
{
    public interface IBooksStoreRepository
    {
        void AddEntity(object model);
        IEnumerable<Book> GetAllBooks();
        IEnumerable<Order> GetAllOrders(bool includeItems);
        Book GetBookById(int? id);
        IEnumerable<Book> GetBooksByCategory(string category);
        Order GetOrderById(string username, int id);
        Order GetOrderById(int id);
        bool SaveAll();
        void UpdateBook(int id, Book newBook);
    }
}