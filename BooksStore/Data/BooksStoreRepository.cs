using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksStore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace BooksStore.Data
{
    public class BooksStoreRepository : IBooksStoreRepository
    {
        private readonly BooksStoreContext _ctx;
        private readonly Logger _logger;

        public BooksStoreRepository(BooksStoreContext ctx)
        {
            _ctx = ctx;
            _logger = LogManager.GetCurrentClassLogger();
        }

        public void AddEntity(object model)
        {
            _ctx.Add(model);
        }

        public IEnumerable<Order> GetAllOrders(bool includeItems)
        {
            if (includeItems)
            {
                return _ctx.Orders
                           .Include(o => o.Items)
                           .ThenInclude(i => i.Book)
                           .ToList();
            }
            else
            {
                return _ctx.Orders.ToList();
            }
        }
        public IEnumerable<Book> GetAllBooks()
        {
            try
            {
                _logger.Info("GetAllBooks was called");
                return _ctx.Books
                       .OrderBy(p => p.Title)
                       .ToList();
            }
            catch (Exception ex)
            {
                _logger.Error($"Failed to get all books:{ex}");
                return null;
            }

        }

        public Order GetOrderById(string username, int id)
        {
            return _ctx.Orders
                      .Include(o => o.Items)
                      .ThenInclude(i => i.Book)
                      .Where(o => o.Id == id)
                      .FirstOrDefault();
        }

        //public IEnumerable<Order> GetAllOrdersByUser(string username, bool includeItems)
        //{
        //    if (includeItems)
        //    {

        //        return _ctx.Orders
        //                   .Where(o => o.User.UserName == username)
        //                   .Include(o => o.Items)
        //                   .ThenInclude(i => i.Book)
        //                   .ToList();

        //    }
        //    else
        //    {
        //        return _ctx.Orders
        //                   .Where(o => o.User.UserName == username)
        //                   .ToList();
        //    }
        //}

        public Book GetBookById(int? id)
        {
            return _ctx.Books
                       .Where(n => n.Id == id)
                       .FirstOrDefault();
        }

        public IEnumerable<Book> GetBooksByCategory(string category)
        {
            return _ctx.Books
                       .Where(p => p.Category == category)
                       .ToList();
        }

        public void UpdateBook(int id, Book newBook)
        {
            Book oldBook = GetBookById(id);
            if(oldBook != null)
            {
                oldBook.Title = newBook.Title;
                oldBook.AuthorName = newBook.AuthorName;
                oldBook.PublicationYear = newBook.PublicationYear;
                oldBook.PublisherName = newBook.PublisherName;
                oldBook.Price = newBook.Price;
            }
            
            _ctx.SaveChanges();
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }
    }
}

