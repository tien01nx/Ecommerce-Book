using example.Models;

namespace example.DataAccess.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {

        void Update(Product obj);
        IEnumerable<Product> GetProductsBySellerApplicationUserId(string applicationUserId);
    }
}
