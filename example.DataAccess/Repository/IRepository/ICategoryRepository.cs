﻿using Ecommerce.Models;
using System.Linq.Expressions;

namespace Ecommerce.DataAccess.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {

        void Update(Category obj);

        bool ExistsBy(Expression<Func<Category, bool>> filter);

    }
}
