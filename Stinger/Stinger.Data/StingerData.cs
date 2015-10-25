namespace Stinger.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using Contracts;
    using Stingers.Models;

    public class StingerData : IStingerData
    {
        private readonly DbContext _context;
        private readonly IDictionary<Type, object> _repositories;

        public StingerData()
            : this(new StingerDbContext())
        {
        }

        public StingerData(DbContext context)
        {
            this._context = context;
            this._repositories = new Dictionary<Type, object>();
        }

        // USERS
        public IRepository<User> UsersRepository
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        // STINGS
        public IRepository<Sting> StingsRepository
        {
            get
            {
                return this.GetRepository<Sting>();
            }
        }

        // RE-STINGS
        public IRepository<ReSting> ReStingsRepository
        {
            get
            {
                return this.GetRepository<ReSting>();
            }
        }

        // REPLIES
        public IRepository<Reply> RepliesRepository
        {
            get
            {
                return this.GetRepository<Reply>();
            }
        }

        // MESSAGES
        public IRepository<Message> MessagesRepository
        {
            get
            {
                return this.GetRepository<Message>();
            }
        }

        // REPORTS
        public IRepository<Report> ReportsRepository
        {
            get
            {
                return this.GetRepository<Report>();
            }
        }

        // NOTIFICATIONS
        public IRepository<Notification> NotificationsRepository
        {
            get
            {
                return this.GetRepository<Notification>();
            }
        }

        // FAVORITES
        public IRepository<Favorite> FavoritesRepository
        {
            get
            {
                return this.GetRepository<Favorite>();
            }
        }

        // GET REPOSITORY
        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this._repositories.ContainsKey(typeof(T)))
            {
                var type = typeof (StingerRepository<T>);

                this._repositories.Add(typeof(T), Activator.CreateInstance(type, this._context));
            }

            return (IRepository<T>) this._repositories[typeof (T)];
        }
    }
}
