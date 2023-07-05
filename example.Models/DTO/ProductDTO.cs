namespace example.Models.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public double ListPrice { get; set; }
        public double Price100 { get; set; }

        public List<string> ImageUrls { get; set; }
    }

}
