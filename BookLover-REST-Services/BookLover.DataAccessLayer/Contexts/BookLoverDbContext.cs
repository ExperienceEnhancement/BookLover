namespace BookLover.DataAccessLayer.Contexts
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using EntityModels;
    using Migrations;

    public class BookLoverDbContext : IdentityDbContext<User>, IBookLoverDbContext
    {
        public BookLoverDbContext()
            : base("BookLoverDbConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<BookLoverDbContext, BookLoverDbMigrationConfiguration>());
        }

        public static BookLoverDbContext Create()
        {
            return new BookLoverDbContext();
        }

        public IDbSet<Book> Books { get; set; }

        public IDbSet<Review> Reviews { get; set; }

        public IDbSet<Author> Authors { get; set; }

        public IDbSet<BookDiary> BookDiaries { get; set; }

        public IDbSet<DiaryNote> DiaryNotes { get; set; }

        public IDbSet<DiaryAccess> DiaryAccesses { get; set; }

        public IDbSet<UserSession> UserSessions { get; set; }
    }
}
