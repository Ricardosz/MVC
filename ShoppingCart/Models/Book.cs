namespace ShoppingCart.Models
{
    public class Book
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Isbn { get; set; }
        public string Synopsis { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal ListPrice { get; set; }
        public decimal SalePrice { get; set; }
        public bool Featured { get; set; }

        public virtual Author Author { get; set; }
        public virtual Category Category { get; set; }
    }
}