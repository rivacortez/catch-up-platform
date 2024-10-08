﻿using System.Net.Mime;
using CatchUpPlatformRi.API.News.Domain.Model.Queries;
using CatchUpPlatformRi.API.News.Domain.Services;
using CatchUpPlatformRi.API.News.Interfaces.REST.Resources;
using CatchUpPlatformRi.API.News.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace CatchUpPlatformRi.API.News.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class FavoriteSourcesController(
    IFavoriteSourceCommandService favoriteSourceCommandService,
    IFavoriteSourceQueryService favoriteSourceQueryService)
    : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateFavoriteSource([FromBody] CreateFavoriteSourceResource resource)
    {
        var createFavoriteSourceCommand = CreateFavoriteSourceCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await favoriteSourceCommandService.Handle(createFavoriteSourceCommand);
        if (result is null) return BadRequest();
        return CreatedAtAction(nameof(GetFavoriteSourceById), new { id = result.Id }, FavoriteSourceResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
    private async Task<ActionResult> GetAllFavoriteSourcesByNewsApiKey(string newsApiKey)
    {
       var getAllFavoriteSourcesByNewsApiKeyQuery = new GetAllFavoriteSourcesByNewsApiKeyQuery(newsApiKey);
        var result = await favoriteSourceQueryService.Handle(getAllFavoriteSourcesByNewsApiKeyQuery);
        var resources = result.Select(FavoriteSourceResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    private async Task<ActionResult> GetFavoriteSourceByNewsApiKeyAndSourceId(string newsApiKey, string sourceId)
    {
        var getFavoriteSourceByNewsApiKeyAndSourceIdQuery = new GetFavoriteSourceByNewsApiKeyAndSourceIdQuery(newsApiKey, sourceId);
        var result = await favoriteSourceQueryService.Handle(getFavoriteSourceByNewsApiKeyAndSourceIdQuery);
        if (result is null) return NotFound();
        var resource = FavoriteSourceResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    [HttpGet]
    public async Task<ActionResult> GetFavoriteSourceFromQuery([FromQuery] string newsApiKey, [FromQuery] string sourceId = "")
    {
        return string.IsNullOrEmpty(sourceId)
            ? await GetAllFavoriteSourcesByNewsApiKey(newsApiKey)
            : await GetFavoriteSourceByNewsApiKeyAndSourceId(newsApiKey, sourceId);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult> GetFavoriteSourceById(int id)
    {
        var getFavoriteSourceByIdQuery = new GetFavoriteSourceByIdQuery(id);
        var result = await favoriteSourceQueryService.Handle(getFavoriteSourceByIdQuery);
        if (result is null) return NotFound();
        var resource = FavoriteSourceResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
}