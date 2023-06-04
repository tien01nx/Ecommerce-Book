using example.Models;

namespace example.DataAccess.Repository.IRepository
{
    public interface ICategoryRepositoty : IRepository<Category>
    {

        void Update(Category obj);

    }
}
