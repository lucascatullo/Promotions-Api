using PromotionEngine.Application.Features.Promotions.Dto;
using PromotionEngine.Application.Shared.Dto;

namespace PromotionEngine.Application.Features.Promotions.GetAll.V1.Dto;

public class GetAllResponseDTO : BaseResponse
{
    public IEnumerable<PromotionBaseDTO> Promotions { get; private set; } = Enumerable.Empty<PromotionBaseDTO>();


    public GetAllResponseDTO SetPromotions(IEnumerable<PromotionBaseDTO> promotions)
    {
        Promotions = promotions;

        return this;
    }

}
