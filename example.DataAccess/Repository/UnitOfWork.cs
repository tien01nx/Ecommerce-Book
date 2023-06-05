using example.DataAccess.Repository.IRepository;
using example_web_mvc.DataAccess.Data;

namespace example.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork

    {

        private ApplicationDbContext _db;
        public ICategoryRepositoty Category { get; private set; }
        public IProductRepositoty Product { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Product = new ProductRepositoty(_db);
        }


        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
