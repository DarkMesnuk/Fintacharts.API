using AutoMapper;
using Fintacharts.API.Database.Entities;
using Fintacharts.API.Database.Extensions;
using Fintacharts.API.Database.Repositories.Base;
using FintachartsAPI.Domain.Exceptions;
using FintachartsAPI.Domain.Interfaces.Database;
using FintachartsAPI.Domain.Models.Assets;
using FintachartsAPI.Domain.Schemas.Assets;
using FintachartsAPI.Domain.Schemas.Base.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Fintacharts.API.Database.Repositories;

public class AssetsRepository(
    FintachartsContext context, 
    ILogger<AssetsRepository> logger, 
    IMapper mapper
    ) : BaseRepository<AssetEntity, AssetModel, Guid>(context, logger, mapper), IAssetsRepository
{
    public async Task<IEnumerable<AssetModel>> GetDetailedAsync(IEnumerable<Guid> ids)
    {
        var entities = await GetBase
            .FilterByIds(ids)
            .ToListAsync();

        if (entities.Count != ids.Count())
            throw new NotFoundException(nameof(AssetModel));

        return MapToModel(entities);
    }
    
    public async Task<IPaginatedResponseSchema<AssetModel>> GetSimplePaginatedAsync(IPaginatedSchema schema)
    {
        var assets = await GetBase
            .Page(schema)
            .Select(x => new AssetEntity
            {
                Id = x.Id,
                Symbol = x.Symbol,
                Kind = x.Kind,
                Exchange = x.Exchange,
                Description = x.Description,
                TickSize = x.TickSize,
                Currency = x.Currency,
            })
            .ToPaginatedAsync(GetBase);

        return MapToModel(assets);
    }
    
    public async Task<ICollection<Guid>> GetAllIdsAsync()
    {
        return await GetBase.Select(x => x.Id).ToListAsync();
    }
    
    public async Task<bool> UpdateFromStreamAsync(UpdateAssetDataSchema updateSchema)
    {
        try
        {
            var query = GetBase.Where(x => x.Id == updateSchema.Id);

            if (updateSchema.Ask != null)
            {
                await query.ExecuteUpdateAsync(x => x
                    .SetProperty(asset => asset.AskPrice, updateSchema.Ask.Price)
                    .SetProperty(asset => asset.AskTimeStamp, DateTime.SpecifyKind(updateSchema.Ask.TimeStamp, DateTimeKind.Utc))
                );
            }
            
            if (updateSchema.Bid != null)
            {
                await query.ExecuteUpdateAsync(x => x
                    .SetProperty(asset => asset.BidPrice, updateSchema.Bid.Price)
                    .SetProperty(asset => asset.BidTimeStamp, DateTime.SpecifyKind(updateSchema.Bid.TimeStamp, DateTimeKind.Utc))
                );
            }
            
            if (updateSchema.Last != null)
            {
                await query.ExecuteUpdateAsync(x => x
                    .SetProperty(asset => asset.LastPrice, updateSchema.Last.Price)
                    .SetProperty(asset => asset.LastTimeStamp, DateTime.SpecifyKind(updateSchema.Last.TimeStamp, DateTimeKind.Utc))
                );
            }
        }
        catch (Exception ex)
        {
            logger.LogWarning("[AssetsRepository] failed update asset: {Message}, inner exception: {InnerExceptionMessage}, stack trace: {StackTrace}", ex.Message, ex.InnerException?.Message, ex.StackTrace);
            return false;
        }

        return true;
    }
    
    public Task<bool> AnyAsync()
    {
        return GetBase.AnyAsync();
    }
}