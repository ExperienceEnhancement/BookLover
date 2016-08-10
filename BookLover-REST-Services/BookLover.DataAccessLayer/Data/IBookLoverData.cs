namespace BookLover.DataAccessLayer.Data
{
    using EntityModels;
    using Repositories;

    public interface IBookLoverData
    {
        IRepository<User> Users { get; }

        IRepository<Book> Books { get; }

        IRepository<Review> Reviews { get; }

        IRepository<Author> Authors { get; }

        IRepository<BookDiary> BookDiaries { get; }

        IRepository<DiaryNote> DiaryNotes { get; }

        IRepository<DiaryAccess> DiaryAccesses { get; }

        IRepository<UserSession> UserSessions { get; }

        int SaveChanges();
    }
}
