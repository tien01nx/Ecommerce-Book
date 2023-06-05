using example.DataAccess.Repository.IRepository;
using example.Models;
using example_web_mvc.DataAccess.Data;

namespace example.DataAccess.Repository
{
    public class ProductRepositoty : Repository<Product>, IProductRepositoty
    {
        private ApplicationDbContext _db;
        public ProductRepositoty(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }



        public void Update(Product obj)
        {
            var objFormdb = _db.Products.FirstOrDefault(u => u.Id == obj.Id);
            if (objFormdb != null)
            {

                objFormdb.Title = obj.Title;
                objFormdb.Description = obj.Description;
                objFormdb.Price = obj.Price;
                objFormdb.Price50 = obj.Price50;

                objFormdb.ListPrice = obj.ListPrice;
                objFormdb.Price100 = obj.Price100;
                objFormdb.ISBN = obj.ISBN;
                objFormdb.CategoryId = obj.CategoryId;
                objFormdb.ImageUrl = obj.ImageUrl;
                if (obj.ImageUrl != null)
                {
                    objFormdb.ImageUrl = obj.ImageUrl;
                }

            }
        }
    }
}
