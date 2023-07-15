using example.DataAccess.Repository.IRepository;
using example.Models;
using example_web_mvc.DataAccess.Data;

namespace example.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<Product> GetProductsBySellerApplicationUserId(string applicationUserId)
        {
            return _db.Products.Where(p => p.Seller.ApplicationUserId == applicationUserId).ToList();
        }

        public void Update(Product obj)
        {
            var objFormdb = _db.Products.FirstOrDefault(u => u.Id == obj.Id);
            if (objFormdb != null)
            {

                objFormdb.Title = obj.Title;
                objFormdb.ISBN = obj.ISBN;
                objFormdb.Price = obj.Price;
                objFormdb.Price50 = obj.Price50;

                objFormdb.ListPrice = obj.ListPrice;
                objFormdb.Price100 = obj.Price100;
                objFormdb.Description = obj.Description;
                objFormdb.CategoryId = obj.CategoryId;
                objFormdb.Author = obj.Author;
                objFormdb.Quantity = obj.Quantity;
                objFormdb.ProductImages = obj.ProductImages;
                //objFormdb.ImageUrl = obj.ImageUrl;
                //if (obj.ImageUrl != null)
                //{
                //    objFormdb.ImageUrl = obj.ImageUrl;
                //}

            }
        }
    }
}
