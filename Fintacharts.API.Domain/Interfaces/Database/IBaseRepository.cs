using FintachartsAPI.Domain.Interfaces.Models;
using FintachartsAPI.Domain.Schemas.Base.Interfaces;

namespace FintachartsAPI.Domain.Interfaces.Database;

public interface IBaseRepository<TModel, TId>
    where TModel : class, IEntityModel<TId>, new()
{
    bool Exists(TId id);
    
    Task<TModel?> CreateAsync(TModel model);
    Task<bool> CreateAsync(IEnumerable<TModel> models);
    
    Task<TModel?> GetByIdAsync(TId id);
    
    Task<IPaginatedResponseSchema<TModel>> GetAllAsync(IPaginatedSchema schema);
    
    Task<TModel?> UpdateAsync(TModel model);
    
    Task<bool> UpdateRangeAsync(IEnumerable<TModel> models);
    
    Task<bool> DeleteAsync(TId id);
    Task<bool> DeleteAsync(TModel model);
    Task<bool> DeleteRangeAsync(IEnumerable<TModel> models);
    Task<bool> DeleteRangeAsync(IEnumerable<TId> ids);
}