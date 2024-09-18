

using PromotionEngine.Application.Features.Promotions.Dto;
using PromotionEngine.Application.Shared.Dto;

namespace PromotionEngine.Application.Features.Promotions.GetById.V1.Dto;

public class GetPromotionByIdResponse : BaseResponse
{
    public PromotionBaseDTO? Promotion { get; set; }
}
