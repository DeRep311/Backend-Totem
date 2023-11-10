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
    public virtual void AddRaw(List<TEntity> entities){
        using Tcontext context = new();
        context.Set<TEntity>().AddRange(entities);
        context.SaveChanges();
    }

    public virtual void Delete(Expression<Func<TEntity, bool>> filter)
    {
        using Tcontext context = new();
        
        var deleteEntity = context.Set<TEntity>().Where(filter).FirstOrDefault();
        var deleteContext = context.Entry(deleteEntity);
        deleteContext.State = EntityState.Deleted;
        context.SaveChanges();

    }
    public virtual void DeleteRaw(List<TEntity> entities){
        using Tcontext context = new();
        context.Set<TEntity>().RemoveRange(entities);
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

    public virtual void Update(TEntity newentity, Expression<Func<TEntity, bool>> filter)
    {
        using Tcontext context = new();

        var updateEntity = context.Set<TEntity>().Where(filter).FirstOrDefault();
        var updateContext = context.Entry(updateEntity);
        updateContext.State = EntityState.Detached;
        updateContext.State = EntityState.Modified;
        context.SaveChanges();
        
    }
}

