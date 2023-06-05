using example.Models;

namespace example.DataAccess.Repository.IRepository
{
    public interface IProductRepositoty : IRepository<Product>
    {

        void Update(Product obj);

    }
}
