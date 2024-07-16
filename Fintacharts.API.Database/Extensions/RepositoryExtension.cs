using Fintacharts.API.Database.Entities.Interfaces;
using FintachartsAPI.Domain.Schemas.Base;
using FintachartsAPI.Domain.Schemas.Base.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Fintacharts.API.Database.Extensions;

public static class RepositoryExtension
{

    public static IQueryable<E> Page<E>(this IQueryable<E> query, IPaginatedSchema schema)
    {
        if (schema.PageSize != -1)
        {
            query = query
                .Skip(schema.PageNumber * schema.PageSize)
                .Take(schema.PageSize);
        }

        return query;
    }

    public static IPaginatedResponseSchema<E> ToPaginated<E>(this IQueryable<E> filteredQuery, IQueryable<E> withoutFilterQuery)
        where E : class, IEntity, new()
    {
        var totalCount = withoutFilterQuery.Count();
        
        var entities = filteredQuery.ToList();

        var response = new PaginatedResponseSchema<E>
        {
            TotalCount = totalCount,
            Count = entities.Count,
            Dtos = entities,
        };

        return response;
    }
    
    public static async Task<IPaginatedResponseSchema<E>> ToPaginatedAsync<E>(this IQueryable<E> filteredQuery, IQueryable<E> withoutFilterQuery)
        where E : class, IEntity, new()
    {
        var totalCount = await withoutFilterQuery.CountAsync();
        
        var entities = await filteredQuery.ToListAsync();

        var response = new PaginatedResponseSchema<E>
        {
            TotalCount = totalCount,
            Count = entities.Count,
            Dtos = entities,
        };

        return response;
    }

    public static E? GetById<E, ET>(this IQueryable<E> query, ET id)
        where E : class, IEntity<ET>, new()
    {
        return query.FirstOrDefault(e => Equals(e.Id, id));
    }

    public static Task<E?> GetByIdAsync<E, ET>(this IQueryable<E> query, ET id)
        where E : class, IEntity<ET>, new()
    {
        return query.FirstOrDefaultAsync(e => Equals(e.Id, id));
    }

    public static Task<E?> GetByFilterAsync<E>(this IQueryable<E> query, Expression<Func<E, bool>> func)
        where E : class, IEntity, new()
    {
        return query.FirstOrDefaultAsync(func);
    }

    public static IQueryable<E> FilterByIds<E, ET>(this IQueryable<E> query, IEnumerable<ET> ids)
        where E : class, IEntity<ET>, new()
    {
        return query.Where(e => ids.Contains(e.Id));
    }
}