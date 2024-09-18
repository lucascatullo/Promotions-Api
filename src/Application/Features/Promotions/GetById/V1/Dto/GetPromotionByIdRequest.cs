

using MediatR;

namespace PromotionEngine.Application.Features.Promotions.GetById.V1.Dto;

public class GetPromotionByIdRequest(Guid id, string lenguageCode) : IRequest<GetPromotionByIdResponse>
{
    public Guid Id { get; } = id;
    public string LenguageCode { get; } = lenguageCode;
}
