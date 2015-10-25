namespace Stinger.Data
{
    using System.Data.Entity;
    using System.Linq;

    using Contracts;

    public class StingerRepository<T> : IRepository<T>
        where T : class
    {
        private readonly DbContext _context;
        private readonly IDbSet<T> _set;

        public StingerRepository()
            : this(new StingerDbContext())
        {
        }

        public StingerRepository(DbContext context)
        {
            this._context = context;
            this._set = context.Set<T>();
        }

        // ALL
        public IQueryable<T> All()
        {
            return this._set;
        }

        // FIND
        public T Find(object id)
        {
            return this._set.Find(id);
        }

        // ADD
        public void Add(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Added);
        }

        public void Update(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Modified);
        }

        // DELETE BY ENTITY
        public void Delete(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Deleted);
        }

        // DELETE BY ID
        public void Delete(object id)
        {
            this.Delete(this.Find(id));
        }

        // SAVE CHANGES
        public int SaveChanges()
        {
            return this._context.SaveChanges();
        }

        // CHANGE ENTITY STATE
        private void ChangeEntityState(T entity, EntityState state)
        {
            var entry = this._context.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                this._set.Attach(entity);
            }

            entry.State = state;
        }
    }
}
