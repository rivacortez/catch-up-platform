using CatchUpPlatformRi.API.News.Domain.Model.Aggregates;
using CatchUpPlatformRi.API.Shared.Domain.Repositories;

namespace CatchUpPlatformRi.API.News.Domain.Repositories;

public interface IFavoriteSourceRepository: IBaseRepository<FavoriteSource>
{
    Task<IEnumerable<FavoriteSource>> FindByNewsApiKeyAsync(string newsApiKey);
    Task<FavoriteSource?> FindByNewsApiKeyAndSourceIdAsync(string newsApiKey, string sourceId);
}