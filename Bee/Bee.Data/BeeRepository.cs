namespace Bee.Data
{
    using System.Data.Entity;
    using System.Linq;
    using Contracts;

    public class BeeRepository<T> : IRepository<T> 
        where T : class
    {
        private readonly DbContext data;
        private readonly IDbSet<T> set;

        public BeeRepository() 
            : this(new BeeDbContext())
        {
        }

        public BeeRepository(DbContext data)
        {
            this.data = data;
            this.set = data.Set<T>();
        }

        // ALL
        public IQueryable<T> All()
        {
            return this.set;
        }

        // FIND
        public T Find(object id)
        {
            return this.set.Find(id);
        }

        // ADD
        public void Add(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Added);
        }
        
        // UPDATE
        public void Update(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Modified);
        }

        // DELETE
        public void Delete(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Deleted);
        }

        // DELETE BY ID
        public void Delete(object id)
        {
            this.Delete(this.Find(id));
        }

        // SAVE
        public int SaveChanges()
        {
            return this.data.SaveChanges();
        }

        // CHANGE ENTITY STATE
        private void ChangeEntityState(T entity, EntityState state)
        {
            var entry = this.data.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                this.set.Attach(entity);
            }

            entry.State = state;
        }
    }
}
