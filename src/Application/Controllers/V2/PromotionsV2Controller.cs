

using Asp.Versioning;
using MediatR;
using PromotionEngine.Application.Features.Promotions.GetAll.V1.Dto;
using PromotionEngine.Application.Features.Promotions.GetAll.V2.Dto;

namespace PromotionEngine.Application.Controllers.V2;

[ApiController]
[Route("api/v{version:apiVersion}")]
[ApiVersion("2.0")]
public class PromotionsV2Controller : FeatureControllerBase
{

    public PromotionsV2Controller(ILogger<PromotionsV2Controller> logger, IMediator mediator) : base(logger, mediator)
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
        CancellationToken cancellationToken,
        [FromQuery] int maxPromotions)
    {
        var request = new GetAllPromotionsRequestV2(countryCode, languageCode, maxPromotions);

        GetAllResponseV2DTO response = await _mediator.Send(request, cancellationToken);

        return response.Success ? Ok(response) : HandleException(response.Exception!);
    }
}