

using AutoMapper;
using PromotionEngine.Application.Features.Promotions.Dto;
using PromotionEngine.Entities;

namespace PromotionEngine.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Promotion, PromotionBaseDTO>();
        CreateMap<DisplayContent, PromotionTextBaseDTO>();
    }
}
