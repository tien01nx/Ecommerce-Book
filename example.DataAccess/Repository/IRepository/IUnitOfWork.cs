namespace example.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepositoty Category { get; }
        void Save();
    }
}
