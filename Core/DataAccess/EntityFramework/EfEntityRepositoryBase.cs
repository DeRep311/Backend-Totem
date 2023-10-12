using System.Diagnostics;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Core.DataAccess;
using Core.entities;

public class EfEntityRepositoryBase<TEntity, Tcontext> : IEntityRepository<TEntity>
where TEntity : class, IEntity, new()
where Tcontext : DbContext, new()
{
    public virtual void Add(TEntity entitiy)
    {
        using Tcontext context = new();
        var addEntity = context.Entry(entitiy);
        addEntity.State = EntityState.Added;
        context.SaveChanges();
    }

    public virtual void Delete(TEntity entity)
    {
        using Tcontext context = new();
        
        var deleteEntity = context.Entry(entity);
        deleteEntity.State = EntityState.Deleted;
        context.SaveChanges();
    }

    public virtual TEntity Get(Expression<Func<TEntity, bool>> filter)
    {
        using Tcontext context = new();
        return context.Set<TEntity>().SingleOrDefault(filter);
    }

    public virtual List<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null)
    {
        using Tcontext context= new();

        return filter==null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
        
        
        }

    public virtual void Update(TEntity newentity, TEntity oldentity)
    {
        using Tcontext context = new();

        context.Entry(oldentity).State= EntityState.Detached;
        var updatecontext = context.Entry(newentity);
        updatecontext.State= EntityState.Modified;
        context.Entry(oldentity).CurrentValues.SetValues(newentity);
        context.SaveChanges();
    }
}

