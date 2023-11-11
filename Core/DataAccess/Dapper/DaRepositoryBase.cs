using System.Data;
using System.Linq.Expressions;
using Core.DataAccess;
using Core.entities;
using Dapper;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;

public class DapperRepositoryBase<T> : IEntityRepository<T> where T : class, IEntity, new()
{
    

    private readonly IDbConnection _connection;
    
    public DapperRepositoryBase(IDbConnection connection)
    {
        _connection = connection;
    }

   public void Add(T entity)
{
    string tableName = typeof(T).Name;
    var properties = entity.GetType().GetNonIgnoredProperties();
    var columnNames = string.Join(", ", properties.Select(p => p.Name));
    
    var parameterNames = string.Join(", ", properties.Select(p => "@" + p.Name));

    string sql = $"INSERT INTO {tableName} ({columnNames}) VALUES ({parameterNames})";
    System.Console.WriteLine("Datos de la consulta");
    System.Console.WriteLine(sql);
    
    _connection.Execute(sql, entity);
}

    public void AddRaw(List<T> entities)
    {
         string tableName = typeof(T).Name;
    var properties = typeof(T).GetNonIgnoredProperties();
    var columnNames = string.Join(", ", properties.Select(p => p.Name));
    var parameterNames = string.Join(", ", properties.Select(p => "@" + p.Name));

    string sql = $"INSERT INTO {tableName} ({columnNames}) VALUES ({parameterNames})";
    System.Console.WriteLine(sql);
    
    _connection.Execute(sql, entities);
     
        
    }

    public void Delete(Expression<Func<T, bool>> filter)
    {
        string tableName = typeof(T).Name;
        string sql = $"DELETE FROM {tableName} WHERE {GetFilterExpression(filter)}";
        _connection.Execute(sql);
    }

    public void DeleteRaw(List<T> entities)
    {
        string tableName = typeof(T).Name;
        // string sql = $"DELETE FROM {tableName} WHERE {GetFilterExpression(filter)}";
        // _connection.Execute(sql);
    }

    public T Get(Expression<Func<T, bool>> filter)
    {
        string tableName= typeof(T).Name;
        
    
        if (GetFilterExpression(filter) != null)
        {
            string sql = $"SELECT * FROM {tableName} WHERE {GetFilterExpression(filter)}";
            
            String expr= GetFilterExpression(filter);
            System.Console.WriteLine("Datos de la consulta");
            System.Console.WriteLine(expr);
            System.Console.WriteLine(sql);
            var result= _connection.QueryFirst<T>(sql);
            return result;
        }
        else
        {
            string sql = $"SELECT * FROM {tableName}";
            return _connection.QueryFirst<T>(sql);
        }
      
    }

    public List<T> GetAll(Expression<Func<T, bool>>? filter = null)
    {
        string tableName = typeof(T).Name;
        string sql = $"SELECT * FROM {tableName}";
        return new List<T>(_connection.Query<T>(sql).ToList());
    }

    public void Update(T newentity, Expression<Func<T, bool>> filter)
    {

        string tableName = typeof(T).Name;
        var properties = typeof(T).GetNonIgnoredProperties();
        String columnNames = "";
        foreach (var item in properties)
        {
            columnNames += item.Name + " = @" + item.Name + ", ";
        }
        columnNames = columnNames.Remove(columnNames.Length - 2);
        
        string sql = $"UPDATE {tableName} SET {columnNames} WHERE {GetFilterExpression(filter)}";
  

        _connection.Execute(sql, newentity);
        

        
    }

     private string GetFilterExpression(Expression<Func<T, bool>> filter)
    {
         var binaryExpression = filter.Body as BinaryExpression;
            var left = binaryExpression.Left as MemberExpression;
            var right = binaryExpression.Right;

                       if (left != null)
            {
                var fieldName = left.Member.Name;
                object value;

                if (right is ConstantExpression constantExpression)
                {
                    value = constantExpression.Value;
                }
                else if (right is MemberExpression rightAsMemberExpression)
                {
                    value = extractValueFromExpression(rightAsMemberExpression);

                }
                else if (right is UnaryExpression unaryExpression)
                {
                    rightAsMemberExpression = unaryExpression.Operand as MemberExpression;
                    value = extractValueFromExpression(rightAsMemberExpression);
                }
                else
                {
                    throw new ArgumentException($"Unsupported expression type: {right.NodeType}");
                }

                object extractValueFromExpression(MemberExpression expr)
                {
                    var objectMember = Expression.Convert(expr, typeof(object));
                    var getterLambda = Expression.Lambda<Func<object>>(objectMember);
                    var getter = getterLambda.Compile();
                    return getter();
                }

                return $"{fieldName} = {value}";
            }
            return null;
    }
}

