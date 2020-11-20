namespace KonusarakOgren.Entity.Abstract
{
    public interface IUnitOfWork
    {
        IGenericDal<T> GetRepository<T>() where T : class;
        public int SaveChanges();
    }
}