namespace BooksStore.Data.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string PublisherName { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int PublicationYear { get; set; }
        public string Image { get; set; }
        public string Details { get; set; }
    }
}
