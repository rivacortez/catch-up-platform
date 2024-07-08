using CatchUpPlatformRi.API.News.Domain.Model.Aggregates;
using CatchUpPlatformRi.API.News.Domain.Model.Commands;

namespace CatchUpPlatformRi.API.News.Domain.Services;

public interface IFavoriteSourceCommandService
{
    Task<FavoriteSource?> Handle(CreateFavoriteSourceCommand command);
}