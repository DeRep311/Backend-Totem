using System.Diagnostics;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Core.DataAccess;
using Core.entities;

class EfEntityRepositoryBase<TEntity, Tcontext> : IEntityRepository<TEntity>
where TEntity : class, IEntity, new()
where Tcontext : DbContext, new()
{
    public void Add(TEntity entitiy)
    {
        using (Tcontext context = new()){

            var addEntity = context.Entry(entitiy);
            addEntity.State= EntityState.Added;
            context.SaveChanges();

        }
    }

    public void Delete(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public TEntity Get(Expression<Func<TEntity, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public List<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null)
    {
        throw new NotImplementedException();
    }

    public void Update(TEntity entity)
    {
        throw new NotImplementedException();
    }
}
