namespace BookLover.Tests.UnitTests.Mocks
{
    using System;
    using System.Collections.Generic;
    using DataAccessLayer.Data;
    using DataAccessLayer.Repositories;
    using EntityModels;

    public class BookLoverDataMock: IBookLoverData
    {
        private readonly IDictionary<Type, object> repositories;

        private const int EntitySavedReturnValue = 1;

        public BookLoverDataMock()
        {
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users { get { return this.GetRepository<User>(); } }

        public IRepository<Book> Books { get { return this.GetRepository<Book>(); } }

        public IRepository<Review> Reviews { get { return this.GetRepository<Review>(); } }

        public IRepository<Author> Authors { get { return this.GetRepository<Author>(); } }

        public IRepository<BookDiary> BookDiaries { get { return this.GetRepository<BookDiary>(); } }

        public IRepository<DiaryNote> DiaryNotes { get { return this.GetRepository<DiaryNote>(); } }

        public IRepository<DiaryAccess> DiaryAccesses { get { return this.GetRepository<DiaryAccess>(); } }

        public IRepository<UserSession> UserSessions { get { return this.GetRepository<UserSession>(); } }

        public int SaveChanges()
        {
            return EntitySavedReturnValue;
        }

        private IRepository<T> GetRepository<T>() where T: class
        {
            var entityModelType = typeof(T);
            if (!this.repositories.ContainsKey(entityModelType))
            {
                var repositoryType = typeof(RepositoryMock<T>);
                this.repositories.Add(entityModelType, Activator.CreateInstance(repositoryType));
            }

            return (IRepository<T>)this.repositories[entityModelType];
        }
    }
}
