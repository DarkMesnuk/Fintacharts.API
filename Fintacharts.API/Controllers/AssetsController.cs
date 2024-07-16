using AutoMapper;
using Fintacharts.API.Application.Handlers.Assets;
using Fintacharts.API.Requests.Assets;
using Fintacharts.API.Responses.Assets;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Fintacharts.API.Controllers;

[Route("api/[controller]")]
public class AssetsController(
    ILogger<AssetsController> logger,
    IMapper mapper,
    IMediator mediator
    ) : BaseApiController(logger, mapper, mediator)
{
    [HttpGet]
    [Route("get-all-supported")]
    [ProducesResponseType(typeof(GetSimpleAssetsResponse), 200)]
    public async Task<IActionResult> Get([FromQuery] GetAllSupportedAssetsRequest request)
    {
        var getQuery = Mapper.Map<GetAllSupportedAssetsQueryRequest>(request);

        var applicationResponse = await Mediator.Send(getQuery);

        if (!applicationResponse.IsSucceeded)
            return applicationResponse.GetActionResult();

        var response = new GetSimpleAssetsResponse(applicationResponse);

        return Ok(response);
    }
    
    [HttpGet]
    [Route("get-many")]
    [ProducesResponseType(typeof(GetDetailedAssetsResponse), 200)]
    public async Task<IActionResult> Get([FromQuery] GetAssetsRequest request)
    {
        var getQuery = Mapper.Map<GetAssetsQueryRequest>(request);

        var applicationResponse = await Mediator.Send(getQuery);

        if (!applicationResponse.IsSucceeded)
            return applicationResponse.GetActionResult();

        var response = new GetDetailedAssetsResponse(applicationResponse.Dtos);

        return Ok(response);
    }
    
}