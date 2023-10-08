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
        using Tcontext context = new();
        var addEntity = context.Entry(entitiy);
        addEntity.State = EntityState.Added;
        context.SaveChanges();
    }

    public void Delete(TEntity entity)
    {
        using Tcontext context = new();
        var deleteEntity = context.Entry(entity);
        deleteEntity.State = EntityState.Deleted;
        context.SaveChanges();
    }

    public TEntity Get(Expression<Func<TEntity, bool>> filter)
    {
        using Tcontext context = new();
        return context.Set<TEntity>().SingleOrDefault(filter);
    }

    public List<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null)
    {
        using Tcontext context= new();

        return filter==null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
        
        
        }

    public void Update(TEntity entity)
    {
        using Tcontext context = new();

        var updatecontext = context.Entry(entity);
        updatecontext.State= EntityState.Modified;
        context.SaveChanges();
    }
}

