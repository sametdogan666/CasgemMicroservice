using System.Linq.Expressions;
using CasgemMicroservice.Services.Order.Core.Application.Interfaces;
using CasgemMicroservice.Services.Order.Core.Domain.Models.Entities;
using CasgemMicroservice.Services.Order.Infra.Persistance.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CasgemMicroservice.Services.Order.Infra.Persistance.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly OrderContext _orderContext;

    public Repository(OrderContext orderContext)
    {
        _orderContext = orderContext;
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _orderContext.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _orderContext.Set<T>().FindAsync(id);
    }

    public async Task<T> CreateAsync(T entity)
    {
        _orderContext.Set<T>().Add(entity);
        await _orderContext.SaveChangesAsync();

        return entity;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        _orderContext.Set<T>().Update(entity);
        await _orderContext.SaveChangesAsync();

        return entity;
    }

    public async Task<T> DeleteAsync(T entity)
    {
        _orderContext.Set<T>().Remove(entity);
        await _orderContext.SaveChangesAsync();

        return entity;
    }

    public Task<List<T>> FindByCondition(Expression<Func<T, bool>> expression) => _orderContext.Set<T>().Where(expression).ToListAsync();

}