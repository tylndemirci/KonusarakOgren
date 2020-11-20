using System;
using System.Linq;
using System.Linq.Expressions;

namespace KonusarakOgren.Entity.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetBy(Expression<Func<T, bool>> predicate);

        void Create(T entity);
        void Update(T entity);



    }
}