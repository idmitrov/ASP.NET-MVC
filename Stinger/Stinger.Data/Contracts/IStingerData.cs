namespace Stinger.Data.Contracts
{
    using Stingers.Models;

    public interface IStingerData
    {
        // USERS
        IRepository<User> UsersRepository { get; }

        // STINGS
        IRepository<Sting> StingsRepository { get; }

        // RESTINGS
        IRepository<ReSting> ReStingsRepository { get; } 
        
        // REPLIES
        IRepository<Reply> RepliesRepository { get; }

        // MESSAGES
        IRepository<Message> MessagesRepository { get; } 

        // REPOROTS
        IRepository<Report> ReportsRepository { get; }

        // NOTIFICATIONS
        IRepository<Notification> NotificationsRepository { get; } 

        // FAVORITES
        IRepository<Favorite> FavoritesRepository { get; } 
    }
}
