using AutoMapper;
using MediatR;
using PromotionEngine.Application.Features.Promotions.Dto;
using PromotionEngine.Application.Features.Promotions.GetAll.V1.Dto;
using PromotionEngine.Application.Infrastructure.Repositories;
using PromotionEngine.Application.Shared.Extensions;
using PromotionEngine.Entities;

namespace PromotionEngine.Application.Features.Promotions.GetAll.V1.Query;

public class GetAllPromotionsHandler : IRequestHandler<GetAllPromotionsRequest, GetAllResponseDTO>
{
    private readonly IPromotionsRepository _repository;
    private readonly IMapper _mapper;
    public GetAllPromotionsHandler(IPromotionsRepository repo, IMapper mapper)
    {
        _repository = repo;
        _mapper = mapper;
    }

    public async Task<GetAllResponseDTO> Handle(GetAllPromotionsRequest request, CancellationToken cancellationToken)
    {
        var response = new GetAllResponseDTO();

        IEnumerable<Promotion> promotions = await _repository.GetAll(request.CountryCode, cancellationToken).ToListAsync(cancellationToken);
        IEnumerable<PromotionBaseDTO> promotionDTOs = promotions.Select(x => PromotionBaseDTO.From(x, request.LanguageCode, _mapper));
        return response.SetPromotions(promotionDTOs);
    }


}
