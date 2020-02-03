using System.ComponentModel.DataAnnotations;

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

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int PublicationYear { get; set; }
        public string Image { get; set; }
    }
}
