using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace KonusarakOgren.Entity.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetBy(Expression<Func<T, bool>> predicate);

        T Create(T entity);
        void CreateGroup(List<T> entities);
        void Update(T entity);
    }
}    