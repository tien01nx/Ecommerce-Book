using example.DataAccess.Repository.IRepository;
using example.Models;
using example_web_mvc.DataAccess.Data;

namespace example.DataAccess.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private ApplicationDbContext _db;
        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }




    }
}
