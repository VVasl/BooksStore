using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.Models
{
    public class BookDto
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string AuthorName { get; set; }

        [Required]
        public string PublisherName { get; set; }
        //public string Category { get; set; }

        //[Required]
        //public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int PublicationYear { get; set; }
        //public string Image { get; set; }
        //public string Details { get; set; }
    }
}
