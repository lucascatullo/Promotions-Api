
using AutoMapper;
using MediatR;
using PromotionEngine.Application.Features.Promotions.Dto;
using PromotionEngine.Application.Features.Promotions.GetAll.V2.Dto;
using PromotionEngine.Application.Infrastructure.Repositories;
using PromotionEngine.Application.Shared.Extensions;
using PromotionEngine.Entities;

namespace PromotionEngine.Application.Features.Promotions.GetAll.V2.Query;

public class GetAllPromotionHandlerV2 : IRequestHandler<GetAllPromotionsRequestV2, GetAllResponseV2DTO>
{
    private readonly IPromotionsRepository _repository;
    private readonly IMapper _mapper;
    public GetAllPromotionHandlerV2(IPromotionsRepository repo, IMapper mapper)
    {
        _repository = repo;
        _mapper = mapper;
    }

    public async Task<GetAllResponseV2DTO> Handle(GetAllPromotionsRequestV2 request, CancellationToken cancellationToken)
    {
        var response = new GetAllResponseV2DTO();

        ///On a real database the unit of work who process the filters and the "take" is the database. This line doesn't reflect how i write this on a real environment.
        IEnumerable<Promotion> promotions = (await _repository.GetAll(request.CountryCode, cancellationToken).ToListAsync(cancellationToken)).Take(request.MaxPromotions);
        IEnumerable<PromotionBaseDTO> promotionDTOs = promotions.Select(x => PromotionBaseDTO.From(x, request.LanguageCode, _mapper));

        return response.SetPromotions(promotionDTOs);
    }

}
