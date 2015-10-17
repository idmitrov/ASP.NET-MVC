namespace Bee.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using Contracts;
    using Models;

    public class BeeData : IBeeData
    {
        private readonly DbContext context;
        private readonly IDictionary<Type, object> repositories;

        public BeeData()
            : this(new BeeDbContext())
        {
        }

        public BeeData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        // BUZZ
        public IRepository<Buzz> Buzzes
        {
            get
            {
                return this.GetRepository<Buzz>();
            }
        }

        // USERS
        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }
        
        // SAVE
        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        // GET REPOSITORY
        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof (BeeRepository<T>);

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>) this.repositories[typeof (T)];
        }
    }
}
