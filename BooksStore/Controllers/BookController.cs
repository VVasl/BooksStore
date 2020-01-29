using BooksStore.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLog;
using BooksStore.Models;
using BooksStore.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace BooksStore.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class BookController : ControllerBase
    {
        private readonly BooksStoreContext _ctx;
        private readonly IBooksStoreRepository _repository;
        private readonly Logger _logger;
        private readonly IMapper _mapper;

        public BookController(BooksStoreContext ctx, IBooksStoreRepository repository, IMapper mapper)
        {
            _ctx = ctx;
            _repository = repository;
            _logger = LogManager.GetCurrentClassLogger();
            _mapper = mapper;
        }

        [HttpGet("[action]")]
        public ActionResult GetBooks()
        {
            try
            {
                var books = _repository.GetAllBooks();
                return Ok(_mapper.Map<IEnumerable<Book>, IEnumerable <BookDto>>(books));
            }
            catch (Exception ex)
            {
                _logger.Error($"Failed to get books:{ex}");
                return BadRequest($"Failed to get books");
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            var book = _repository.GetBookById(id);

            if (book != null)
            {
                return Ok(_mapper.Map<Book, BookDto>(book));
            }
            else
            {
                return NotFound();
            }

            
        }

        [HttpPost]
        public IActionResult Create([FromBody] BookDto book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newBook = _mapper.Map<BookDto, Book>(book);
                    _repository.AddEntity(newBook);


                    if (_repository.SaveAll())
                    {
                         return CreatedAtAction(nameof(GetBook), new { id = book.Id }, _mapper.Map<Book, BookDto>(newBook));
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }

            }
            catch (Exception ex)
            {
                _logger.Error($"Failed to save a new book: {ex}");
            }

            return BadRequest("Failed to save a new book");
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, BookDto book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                        var newBook = _mapper.Map<BookDto, Book>(book);

                    if (book != null)
                    {
                        _repository.UpdateBook(id,newBook);
                        return Ok(_mapper.Map<Book, BookDto>(newBook));
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Failed to update order: {ex}");
                return BadRequest("Failed to update order");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> Delete(int id)
        {
            var book = _repository.GetBookById(id);

            if (book == null)
            {
                return NotFound();
            }
             _ctx.Books.Remove(book);
             await _ctx.SaveChangesAsync();

            return book;
        }

        //private bool BookExists(int id)
        //{
        //    return _context.Books.Any(e => e.Id == id);
        //}
    }
}
