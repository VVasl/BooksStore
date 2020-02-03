using System.ComponentModel.DataAnnotations;

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
        public string BookImage { get; set; }
    }
}
