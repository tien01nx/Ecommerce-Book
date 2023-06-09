using example.Models;

namespace example.DataAccess.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {

        void Update(Category obj);

    }
}
