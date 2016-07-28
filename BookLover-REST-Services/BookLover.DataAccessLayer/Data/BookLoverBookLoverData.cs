namespace BookLover.DataAccessLayer.Data
{
    using System;
    using System.Collections.Generic;

    using Contexts;
    using EntityModels;
    using Repositories;

    public class BookLoverBookLoverData: IBookLoverData
    {
        private IBookLoverDbContext dbContext;

        private readonly IDictionary<Type, object> repositories;

        public BookLoverBookLoverData(IBookLoverDbContext context)
        {
            this.dbContext = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }

        public IRepository<Book> Books { get { return this.GetRepository<Book>();  } }

        public IRepository<Review> Reviews { get { return this.GetRepository<Review>(); } }

        public IRepository<Author> Authors { get { return this.GetRepository<Author>(); } }

        public IRepository<BookDiary> BookDiaries { get { return this.GetRepository<BookDiary>(); } }

        public IRepository<DiaryNote> DiaryNotes { get { return this.GetRepository<DiaryNote>(); } }

        public IRepository<DiaryAccess> DiaryAccesses { get { return this.GetRepository<DiaryAccess>(); } }

        public int SaveChanges()
        {
            return this.dbContext.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T: class
        {
            var entityModelType = typeof(T);

            if (!this.repositories.ContainsKey(entityModelType))
            {
                var repositoryType = typeof(Repository<T>);
                this.repositories.Add(entityModelType,
                    Activator.CreateInstance(repositoryType, this.dbContext));
            }

            return (IRepository<T>)this.repositories[entityModelType];
        }
    }
}
