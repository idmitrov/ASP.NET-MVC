namespace PhC.Data.Contracts
{
    using System;
    using System.Linq;

    public interface IRepository<T> : IDisposable 
        where T : class
    {
        // ALL
        IQueryable<T> All();

        // FDIND
        T Find(object id);

        // ADD
        void Add(T entity);

        // UPDATE
        void Update(T entity);

        // DELETE BY ENTITY
        void Delete(T entity);

        // DELETE BY ID
        void Delete(object id);

        // SAVE
        int SaveChanges();
    }
}
