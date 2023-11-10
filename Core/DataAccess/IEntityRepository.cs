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

    void Delete(Expression<Func<T, bool>> filter);

    void DeleteRaw(List<T> entities);

    void Update(T newentity, Expression<Func<T, bool>> filter);


}}