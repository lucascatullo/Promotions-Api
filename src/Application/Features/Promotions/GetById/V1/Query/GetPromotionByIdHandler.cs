using AutoMapper;
using MediatR;
using PromotionEngine.Application.Features.Promotions.Dto;
using PromotionEngine.Application.Features.Promotions.GetById.V1.Dto;
using PromotionEngine.Application.Infrastructure.Repositories;

namespace PromotionEngine.Application.Features.Promotions.GetById.V1.Query;

public class GetPromotionByIdHandler : IRequestHandler<GetPromotionByIdRequest, GetPromotionByIdResponse>
{
    private readonly IPromotionsRepository _repository;
    private readonly IMapper _mapper;
    public GetPromotionByIdHandler(IPromotionsRepository repo, IMapper mapper)
    {
        _repository = repo;
        _mapper = mapper;
    }

    public async Task<GetPromotionByIdResponse> Handle(GetPromotionByIdRequest request, CancellationToken cancellationToken)
    {
        var response = new GetPromotionByIdResponse();
        var promotion = await _repository.FindByIdOrDefaultAsync(request.Id, cancellationToken);
        if (promotion != null) response.Promotion = PromotionBaseDTO.From(promotion, request.LenguageCode, _mapper);
        return response;
    }
}
