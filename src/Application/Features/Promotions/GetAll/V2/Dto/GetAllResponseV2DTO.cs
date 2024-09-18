


using PromotionEngine.Application.Features.Promotions.Dto;
using PromotionEngine.Application.Shared.Dto;

namespace PromotionEngine.Application.Features.Promotions.GetAll.V2.Dto;

public class GetAllResponseV2DTO : BaseResponse
{
    public IEnumerable<PromotionBaseDTO> Promotions { get; private set; } = Enumerable.Empty<PromotionBaseDTO>();
    public int PromotionCount { get; private set; }


    public GetAllResponseV2DTO SetPromotions(IEnumerable<PromotionBaseDTO> promotions)
    {
        Promotions = promotions;
        PromotionCount = promotions.Count();
        return this;
    }
}
