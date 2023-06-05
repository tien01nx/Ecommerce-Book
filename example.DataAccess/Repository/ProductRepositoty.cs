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
            _db.Products.Update(obj);
        }
    }
}
