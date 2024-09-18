

using AutoMapper;
using PromotionEngine.Entities;

namespace PromotionEngine.Application.Features.Promotions.Dto;

public class PromotionBaseDTO
{
    public required Guid Id { get; set; }
    public PromotionTextBaseDTO? Texts { get; set; }
    public List<string> Images { get; set; } = new List<string>();
    public List<Discount>? Discounts { get; set; }

    public required DateTime EndValidityDate;

    public static PromotionBaseDTO From(Promotion promotion, string lenguageCode, IMapper mapper)
    {
        var response = mapper.Map<PromotionBaseDTO>(promotion);

        if (promotion.DisplayContent != null)
        {
            var content = promotion.DisplayContent.FirstOrDefault(d => d.Key == lenguageCode).Value;
            if (content != null) response.Texts = mapper.Map<PromotionTextBaseDTO>(content);
        }
        return response;
    }
}
