using CatchUpPlatformRi.API.News.Domain.Model.Aggregates;
using CatchUpPlatformRi.API.News.Domain.Model.Commands;
using CatchUpPlatformRi.API.News.Interfaces.REST.Resources;

namespace CatchUpPlatformRi.API.News.Interfaces.REST.Transform;

public static class FavoriteSourceResourceFromEntityAssembler
{
    public static FavoriteSourceResource ToResourceFromEntity(FavoriteSource entity) =>
        new FavoriteSourceResource(entity.Id, entity.NewsApiKey, entity.SourceId);
}