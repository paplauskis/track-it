using Api.Dtos;
using Application.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/item")]
public class ItemController: ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ILogger<ItemController> _logger;
    private readonly IReadItemTypesService _readItemTypesService;

    public ItemController(
        IMapper mapper,
        ILogger<ItemController> logger,
        IReadItemTypesService readItemTypesService)
    {
        _mapper = mapper;
        _logger = logger;
        _readItemTypesService = readItemTypesService;
    }

    [HttpGet("post-found-item/item-types")]
    public async Task<IActionResult> GetItemTypes()
    {
        var itemTypes = await _readItemTypesService.GetAll();
        return Ok(_mapper.Map<List<ItemTypeDto>>(itemTypes));
    }
}