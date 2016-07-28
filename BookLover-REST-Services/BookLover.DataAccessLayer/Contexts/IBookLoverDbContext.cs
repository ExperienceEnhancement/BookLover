namespace BookLover.DataAccessLayer.Contexts
{
    using System.Data.Entity;

    using EntityModels;

    public interface IBookLoverDbContext
    {
        IDbSet<User> Users { get; }

        IDbSet<Book> Books { get; }

        IDbSet<Review> Reviews { get; }

        IDbSet<BookDiary> BookDiaries { get; }

        IDbSet<DiaryNote> DiaryNotes { get; }

        IDbSet<Author> Authors { get; }

        IDbSet<DiaryAccess> DiaryAccesses { get; }

        int SaveChanges();
    }  
}
