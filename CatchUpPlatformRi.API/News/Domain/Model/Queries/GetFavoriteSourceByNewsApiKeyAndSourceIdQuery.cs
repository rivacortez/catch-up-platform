﻿namespace CatchUpPlatformRi.API.News.Domain.Model.Queries;

public record GetFavoriteSourceByNewsApiKeyAndSourceIdQuery(string NewsApiKey, string SourceId);