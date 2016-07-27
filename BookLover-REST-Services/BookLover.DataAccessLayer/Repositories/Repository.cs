using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLover.DataAccessLayer.Repositories
{
    using System.Data.Entity;

    public class Repository<TEntity>: IRepository<TEntity> where TEntity: class
    {
        private DbContext dbContext;

        private IDbSet<TEntity> entitySet;

        public Repository(DbContext context)
        {
            this.dbContext = context;
            this.entitySet = context.Set<TEntity>();
        }

        public IDbSet<TEntity> EntitySet
        {
            get { return this.entitySet; }
        }

        public IQueryable<TEntity> All()
        {
            return this.entitySet;
        }

        public void Add(TEntity entity)
        {
            this.ChangeState(entity, EntityState.Added);
        }

        public void Update(TEntity entity)
        {
            this.ChangeState(entity, EntityState.Modified);
        }

        public void Remove(TEntity entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
        }

        public void Remove(object id)
        {
            var entity = this.entitySet.Find(id);
            this.Remove(entity);
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        private void ChangeState(TEntity entity, EntityState state)
        {
            var entry = this.dbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.entitySet.Attach(entity);
            }

            entry.State = state;
        }
    }
}
