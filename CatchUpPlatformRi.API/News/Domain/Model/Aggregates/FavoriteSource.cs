namespace CatchUpPlatformRi.API.News.Domain.Model.Aggregates;

public class FavoriteSource
{
    public int Id { get; private set; }
    public string NewsApiKey { get; private set; }
    public string SourceId { get; private set; }

    protected FavoriteSource()
    {
        this.NewsApiKey = string.Empty;
        this.SourceId = string.Empty;
    }
    
    
}