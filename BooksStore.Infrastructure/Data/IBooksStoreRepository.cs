using BooksStore.Core.Entities;
using System.Collections.Generic;

namespace BooksStore.Infrastructure.Data
{
    public interface IBooksStoreRepository
    {
        void AddEntity(object model);
        void AddOrder(Order newOrder);
        IEnumerable<Book> GetAllBooks();
        IEnumerable<Order> GetAllOrders(bool includeItems);
        IEnumerable<Order> GetAllOrdersByUser(string username, bool includeItems);
        Book GetBookById(int? id);
        IEnumerable<Book> GetBooksByCategory(string category);
        Order GetOrderById(string username, int id);
        Order GetOrderById(int id);
        bool SaveAll();
        void UpdateBook(int id, Book newBook);
    }
}