using MediatR;

namespace PromotionEngine.Application.Features.Promotions.GetAll.V1.Dto;

public class GetAllPromotionsRequest(string countryCode, string languageCode) : IRequest<GetAllResponseDTO>
{
    public string CountryCode { get; set; } = countryCode;
    public string LanguageCode { get; set; } = languageCode;
}