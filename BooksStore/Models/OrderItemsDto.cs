using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.Models
{
    public class OrderItemsDto
    {
        public int Id { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        [Required]
        public int BookId { get; set; }
        public string BookCategory { get; set; }
        public string BookTitle { get; set; }
        public string BookAuthor { get; set; }
        public string BookAuthorId { get; set; }
    }
}
