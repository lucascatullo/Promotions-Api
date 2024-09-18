

using AutoMapper;
using Moq;
using PromotionEngine.Application.Features.Promotions.Dto;
using PromotionEngine.Application.Features.Promotions.GetAll.V1.Dto;
using PromotionEngine.Application.Features.Promotions.GetAll.V1.Query;
using PromotionEngine.Application.Infrastructure.Repositories;
using PromotionEngine.Application.Shared.Extensions;
using PromotionEngine.Application.TestData;
using PromotionEngine.Entities;
using Xunit;

namespace PromotionEngine.Application.Tests.HandlerTests.Promotions.V1.Queries;

public class GetAllPromotionsHandlerTests
{
    [Fact]
    public async Task Handle_Returns_Type_GetAllResponseDTO()
    {
        var mapperMock = new Mock<IMapper>();
        var repoMock = new Mock<IPromotionsRepository>();

        repoMock.Setup(x => x.GetAll("ES", new CancellationToken())).Returns(FakePromotionsData.GetPromotions(x => x.CountryCode == "ES"));

        var handler = new GetAllPromotionsHandler(repoMock.Object, mapperMock.Object);
        var request = new GetAllPromotionsRequest("ES", "ES");
        var response = await handler.Handle(request, new CancellationToken());

        Assert.IsType<GetAllResponseDTO>(response);
    }

    [Fact]
    public async Task Handle_Repository_GetAll_Filterting_By_Country_Code_Was_Called()
    {
        var mapperMock = new Mock<IMapper>();
        var repoMock = new Mock<IPromotionsRepository>();

        repoMock.Setup(x => x.GetAll("ES", new CancellationToken())).Returns(FakePromotionsData.GetPromotions(x => x.CountryCode == "ES"));

        var handler = new GetAllPromotionsHandler(repoMock.Object, mapperMock.Object);
        var request = new GetAllPromotionsRequest("ES", "ES");
        var response = await handler.Handle(request, new CancellationToken());

        repoMock.Verify(r => r.GetAll("ES", It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task Handle_All_Promotions_From_QueryResult_Are_Mapped()
    {
        var cancellationToken = new CancellationToken();
        var mapperMock = new Mock<IMapper>();
        var repoMock = new Mock<IPromotionsRepository>();
        var fakePromotions = FakePromotionsData.GetPromotions(x => x.CountryCode == "ES");


        repoMock.Setup(x => x.GetAll("ES", new CancellationToken())).Returns(fakePromotions);
        mapperMock.Setup(x => x.Map<PromotionBaseDTO>(It.IsAny<Promotion>())).Returns(FakePromotionsData.CreateFakePromotionDTO());


        var handler = new GetAllPromotionsHandler(repoMock.Object, mapperMock.Object);
        var request = new GetAllPromotionsRequest("ES", "ES");

        var response = await handler.Handle(request, cancellationToken);
        var promotionList = await fakePromotions.ToListAsync(cancellationToken);
        Assert.Equal(promotionList.Count(), response.Promotions.Count());
    }

}
