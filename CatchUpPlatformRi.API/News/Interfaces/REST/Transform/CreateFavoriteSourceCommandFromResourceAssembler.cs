using CatchUpPlatformRi.API.News.Domain.Model.Commands;
using CatchUpPlatformRi.API.News.Interfaces.REST.Resources;

namespace CatchUpPlatformRi.API.News.Interfaces.REST.Transform;

public static class CreateFavoriteSourceCommandFromResourceAssembler
{
    public static CreateFavoriteSourceCommand ToCommandFromResource(CreateFavoriteSourceResource resource) =>
        new CreateFavoriteSourceCommand(resource.NewsApiKey, resource.SourceId);
  
}