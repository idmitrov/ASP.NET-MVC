namespace Bee.Data.Contracts
{
    using System.Linq;

    public interface IRepository<T> where T : class
    {
        // ALL
        IQueryable<T> All();

        // FIND
        T Find(object id);
        
        // CREATE/ADD
        void Add(T entity);

        // UPDATE
        void Update(T entity);

        // DELETE
        void Delete(T entity);
        void Delete(object id);

        // SAVE
        int SaveChanges();
    }
}
