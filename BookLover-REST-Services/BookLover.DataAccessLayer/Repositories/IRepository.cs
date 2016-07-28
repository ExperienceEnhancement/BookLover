namespace BookLover.DataAccessLayer.Repositories
{
    using System.Linq;

    public interface IRepository<T>
    {
        IQueryable<T> All();

        void Add(T entity);

        void Update(T entity);

        void Remove(T entity);

        void Remove(object id);
    }
}
