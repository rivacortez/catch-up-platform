using CatchUpPlatformRi.API.News.Domain.Model.Aggregates;
using CatchUpPlatformRi.API.News.Domain.Model.Commands;
using CatchUpPlatformRi.API.News.Domain.Repositories;
using CatchUpPlatformRi.API.News.Domain.Services;
using CatchUpPlatformRi.API.Shared.Domain.Repositories;

namespace CatchUpPlatformRi.API.News.Application.Internal.CommandServices;

public class FavoriteSourceCommandService(IFavoriteSourceRepository favoriteSourceRepository, IUnitOfWork unitOfWork)
    : IFavoriteSourceCommandService
{
    public async Task<FavoriteSource?> Handle(CreateFavoriteSourceCommand command)
    {
        var favoriteSource = await favoriteSourceRepository.FindByNewsApiKeyAndSourceIdAsync(command.NewsApiKey, command.SourceId);
        if(favoriteSource != null) 
            throw new Exception("Favorite Source with this SourceId already exists for te given NewsApiKey");
        favoriteSource = new FavoriteSource(command);
        try
        {
            await favoriteSourceRepository.AddAsync(favoriteSource);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }

        return favoriteSource;
    }
}