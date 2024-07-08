using CatchUpPlatformRi.API.News.Domain.Model.Aggregates;
using CatchUpPlatformRi.API.News.Domain.Repositories;
using CatchUpPlatformRi.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using CatchUpPlatformRi.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CatchUpPlatformRi.API.News.Infrastructure.Repositories;

public class FavoriteSourceRepository : BaseRepository<FavoriteSource>, IFavoriteSourceRepository
{
    public FavoriteSourceRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<FavoriteSource>> FindByNewsApiKeyAsync(string newsApiKey)
    {
        return await Context.Set<FavoriteSource>().Where(f => f.NewsApiKey == newsApiKey).ToListAsync();
    }

    public async Task<FavoriteSource?> FindByNewsApiKeyAndSourceIdAsync(string newsApiKey, string sourceId)
    {
       return await Context.Set<FavoriteSource>().FirstOrDefaultAsync(f=>f.NewsApiKey== newsApiKey && f.SourceId == sourceId);
       
    }
}