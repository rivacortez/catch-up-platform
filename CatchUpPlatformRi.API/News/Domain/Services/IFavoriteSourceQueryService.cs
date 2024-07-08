using CatchUpPlatformRi.API.News.Domain.Model.Aggregates;
using CatchUpPlatformRi.API.News.Domain.Model.Queries;

namespace CatchUpPlatformRi.API.News.Domain.Services;

public interface IFavoriteSourceQueryService
{
    Task<IEnumerable<FavoriteSource>> Handle(GetAllFavoriteSourcesByNewsApiKeyQuery query);
    Task<FavoriteSource?> Handle(GetFavoriteSourceByNewsApiKeyAndSourceIdQuery query);
    Task<FavoriteSource?> Handle(GetFavoriteSourceByIdQuery query);
}