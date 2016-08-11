namespace BookLover.Tests.UnitTests.Mocks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using DataAccessLayer.Repositories;

    public class RepositoryMock<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private IList<TEntity> entities;

        private Func<TEntity, object> keySelector;

        public RepositoryMock(): this(null)
        {
        }

        public RepositoryMock(Func<TEntity, object> keySelector = null)
        {
            if (keySelector != null)
            {
                this.keySelector = keySelector;
            }
            else
            {
                this.keySelector = (u => ((dynamic)u).Id);
            }

            this.entities = new List<TEntity>();
        }

        public void Add(TEntity entity)
        {
            this.entities.Add(entity);
        }

        public IQueryable<TEntity> All()
        {
            return this.entities.AsQueryable();
        }

        public TEntity Find(object id)
        {
            var entity = this.entities.FirstOrDefault(e => id.Equals(this.keySelector(e)));
            return entity;
        }

        public void Remove(object id)
        {
            var entity = this.Find(id);
            this.Remove(entity);
        }

        public void Remove(TEntity entity)
        {
            var entityToRemove = this.Find(this.keySelector(entity));
            var entityIndex = this.entities.IndexOf(entityToRemove);
            this.entities.RemoveAt(entityIndex);
        }

        public void Update(TEntity entity)
        {
            var entityToUpdate = this.Find(this.keySelector(entity));
            var entityIndex = this.entities.IndexOf(entityToUpdate);
            this.entities[entityIndex] = entity;
        }
    }
}
