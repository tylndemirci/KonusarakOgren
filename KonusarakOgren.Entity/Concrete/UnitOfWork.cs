using KonusarakOgren.Entity.Abstract;

namespace KonusarakOgren.Entity.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly KonusarakOgrenContext _context;

        public UnitOfWork(KonusarakOgrenContext context)
        {
            _context = context;
        }

        public IGenericDal<T> GetRepository<T>() where T : class
        {
            return new EfGenericDal<T>(_context);
        }

        public int SaveChanges()
        {
            var i = _context.SaveChanges();
            return i;
        }
    }
}