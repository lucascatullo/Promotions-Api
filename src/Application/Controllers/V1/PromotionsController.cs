using Asp.Versioning;
using MediatR;
using PromotionEngine.Application.Features.Promotions.GetAll.V1.Dto;
using PromotionEngine.Application.Features.Promotions.GetById.V1.Dto;

namespace PromotionEngine.Application.Controllers.V1;

[ApiController]
[Route("api/v{version:apiVersion}")]
[ApiVersion("1.0")]
public class PromotionsController : FeatureControllerBase
{
    public PromotionsController(ILogger<PromotionsController> logger, IMediator mediator) : base(logger, mediator)
    {
    }

    [HttpGet("{countryCode}/promotions")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetAllResponseDTO))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [SwaggerOperation(OperationId = "PromotionsList", Description = "Get Promotions")]
    public async Task<IActionResult> Get(
        [SwaggerParameter("ISO-3166 ALPHA-2")] string countryCode,
        string languageCode,
        CancellationToken cancellationToken)
    {
        var request = new GetAllPromotionsRequest(countryCode, languageCode);

        GetAllResponseDTO response = await _mediator.Send(request, cancellationToken);

        return response.Success ? Ok(response) : HandleException(response.Exception!);
    }


    [HttpGet("promotions/{id}")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetPromotionByIdResponse))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [SwaggerOperation(OperationId = "GetById", Description = "Get the promotion who match the ID")]
    public async Task<IActionResult> GetbyId(
    [SwaggerParameter("ISO-3166 ALPHA-2")] Guid id,
    string languageCode,
    CancellationToken cancellationToken)
    {
        var request = new GetPromotionByIdRequest(id, languageCode);

        GetPromotionByIdResponse response = await _mediator.Send(request, cancellationToken);

        return response.Success ?
            (response.Promotion != null ? Ok(response) : NotFound())
            : HandleException(response.Exception!);
    }
}
