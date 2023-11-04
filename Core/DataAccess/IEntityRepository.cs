using System;
using System.Linq.Expressions;
using System.Text;
using Core.entities;

namespace Core.DataAccess{

public interface IEntityRepository <T> where T:class,IEntity,new()
{


    List<T> GetAll(Expression<Func<T, bool>>? filter = null);
    
     T Get(Expression<Func<T, bool>> filter);
    
    void Add(T entitiy);

    void AddRaw(List<T> entities);

    void Delete(T entity);

    void DeleteRaw(List<T> entities);

    void Update(T newentity, T oldentity);



}}