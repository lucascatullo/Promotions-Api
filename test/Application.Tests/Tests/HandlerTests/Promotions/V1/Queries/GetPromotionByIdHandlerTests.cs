using AutoMapper;
using Moq;
using PromotionEngine.Application.Features.Promotions.Dto;
using PromotionEngine.Application.Features.Promotions.GetById.V1.Dto;
using PromotionEngine.Application.Features.Promotions.GetById.V1.Query;
using PromotionEngine.Application.Infrastructure.Repositories;
using PromotionEngine.Application.TestData;
using PromotionEngine.Entities;
using Xunit;

namespace PromotionEngine.Application.Tests.HandlerTests.Promotions.V1.Queries;

public class GetPromotionByIdHandlerTests
{
    [Fact]
    public async Task Handle_Calls_Repository_FindByIdOrDefault()
    {
        var targetId = Guid.NewGuid();
        var mapperMock = new Mock<IMapper>();
        var repoMock = new Mock<IPromotionsRepository>();

        var handler = new GetPromotionByIdHandler(repoMock.Object, mapperMock.Object);

        var request = new GetPromotionByIdRequest(targetId, "ES");
        var response = await handler.Handle(request, new CancellationToken());

        repoMock.Verify(r => r.FindByIdOrDefaultAsync(request.Id, It.IsAny<CancellationToken>()), Times.Once);
    }


    [Fact]
    public async Task Handle_NoResultFound_ResponseHasEmptyPromotion()
    {
        var targetId = Guid.NewGuid();
        var mapperMock = new Mock<IMapper>();
        var repoMock = new Mock<IPromotionsRepository>();

        repoMock.Setup(r => r.FindByIdOrDefaultAsync(targetId, It.IsAny<CancellationToken>())).ReturnsAsync(() => null);

        var handler = new GetPromotionByIdHandler(repoMock.Object, mapperMock.Object);

        var request = new GetPromotionByIdRequest(targetId, "ES");
        var response = await handler.Handle(request, new CancellationToken());

        Assert.Null(response.Promotion);
    }

    [Fact]
    public async Task Handle_ResultFound_AutoMapperTo_PromotionBaseDTO()
    {
        var targetId = Guid.NewGuid();
        var mapperMock = new Mock<IMapper>();
        var repoMock = new Mock<IPromotionsRepository>();
        var returnedPromotion = FakePromotionsData.CreateFakePromotion();

        repoMock.Setup(r => r.FindByIdOrDefaultAsync(targetId, It.IsAny<CancellationToken>())).ReturnsAsync(() => returnedPromotion);
        mapperMock.Setup(x => x.Map<PromotionBaseDTO>(It.IsAny<Promotion>())).Returns(FakePromotionsData.CreateFakePromotionDTO());

        var handler = new GetPromotionByIdHandler(repoMock.Object, mapperMock.Object);

        var request = new GetPromotionByIdRequest(targetId, "ES");
        var response = await handler.Handle(request, new CancellationToken());

        mapperMock.Verify(m => m.Map<PromotionBaseDTO>(returnedPromotion), Times.Once);
        Assert.NotNull(response.Promotion);
    }

}
