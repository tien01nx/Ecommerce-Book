namespace example.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepositoty Category { get; }
        IProductRepositoty Product { get; }
        void Save();
    }
}
