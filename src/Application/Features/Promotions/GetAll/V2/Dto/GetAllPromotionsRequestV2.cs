

using MediatR;

namespace PromotionEngine.Application.Features.Promotions.GetAll.V2.Dto;

public class GetAllPromotionsRequestV2(string countryCode, string languageCode, int maxPromotions) : IRequest<GetAllResponseV2DTO>
{
    public string CountryCode { get; } = countryCode;
    public string LanguageCode { get; } = languageCode;
    public int MaxPromotions { get; } = maxPromotions;
}