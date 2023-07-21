using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using SipayApi.Base;
using System.Linq.Expressions;

namespace SipayApi.Data.Repository;

public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : BaseModel
{
    private readonly SimDbContext dbContext;
    public GenericRepository(SimDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public void Save()
    {
        dbContext.SaveChanges();
    }

    public void Delete(Entity entity)
    {
        dbContext.Set<Entity>().Remove(entity);
    }

    public void DeleteById(int id)
    {
        var entity = dbContext.Set<Entity>().Find(id);
        Delete(entity);
    }

    public List<Entity> GetAll()
    {
        return dbContext.Set<Entity>().ToList();
    }

    public IQueryable<Entity> GetAllAsQueryable()
    {
        return dbContext.Set<Entity>().AsQueryable();
    }

    public Entity GetById(int id)
    {
        var entity = dbContext.Set<Entity>().Find(id);
        return entity;
    }

    public void Insert(Entity entity)
    {
        entity.InsertDate = DateTime.UtcNow;
        entity.InsertUser = "simadmin@pay.com";
        dbContext.Set<Entity>().Add(entity);
    }

    public void Update(Entity entity)
    {
        dbContext.Set<Entity>().Update(entity);
    }

    public List<Entity> GetByParameter(Func<Entity, bool> expression)
    {
        return dbContext.Set<Entity>().Where(expression).ToList();
    }
}
