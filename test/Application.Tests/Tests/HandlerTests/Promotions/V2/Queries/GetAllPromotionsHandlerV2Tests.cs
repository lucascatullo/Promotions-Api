using AutoMapper;
using Moq;
using PromotionEngine.Application.Features.Promotions.Dto;
using PromotionEngine.Application.Features.Promotions.GetAll.V2.Dto;
using PromotionEngine.Application.Features.Promotions.GetAll.V2.Query;
using PromotionEngine.Application.Infrastructure.Repositories;
using PromotionEngine.Application.Shared.Extensions;
using PromotionEngine.Application.TestData;
using PromotionEngine.Entities;
using Xunit;

namespace PromotionEngine.Application.Tests.HandlerTests.Promotions.V2.Queries;

public class GetAllPromotionsHandlerV2Tests
{
    [Fact]
    public async Task Handle_ResponseType_Is_GetAllResponseV2DTO()
    {
        var mapperMock = new Mock<IMapper>();
        var repoMock = new Mock<IPromotionsRepository>();

        var fakePromotions = FakePromotionsData.GetPromotions(x => x.CountryCode == "ES");


        repoMock.Setup(x => x.GetAll("ES", new CancellationToken())).Returns(fakePromotions);
        mapperMock.Setup(m => m.Map<PromotionTextBaseDTO>(It.IsAny<DisplayContent>())).Returns(FakePromotionsData.CreateFakePromotionTextDTO());
        mapperMock.Setup(x => x.Map<PromotionBaseDTO>(It.IsAny<Promotion>())).Returns(FakePromotionsData.CreateFakePromotionDTO());

        var handler = new GetAllPromotionHandlerV2(repoMock.Object, mapperMock.Object);
        var request = new GetAllPromotionsRequestV2("ES", "ES", 5);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.IsType<GetAllResponseV2DTO>(response);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public async Task Handle_Does_Not_Return_More_Promotions_Than_MaximunPromotion_Param(int quantity)
    {
        var mapperMock = new Mock<IMapper>();
        var repoMock = new Mock<IPromotionsRepository>();

        var fakePromotions = FakePromotionsData.GetPromotions(_ => true);


        repoMock.Setup(x => x.GetAll("ES", new CancellationToken())).Returns(fakePromotions);
        mapperMock.Setup(m => m.Map<PromotionTextBaseDTO>(It.IsAny<DisplayContent>())).Returns(FakePromotionsData.CreateFakePromotionTextDTO());
        mapperMock.Setup(x => x.Map<PromotionBaseDTO>(It.IsAny<Promotion>())).Returns(FakePromotionsData.CreateFakePromotionDTO());

        var handler = new GetAllPromotionHandlerV2(repoMock.Object, mapperMock.Object);
        var request = new GetAllPromotionsRequestV2("ES", "ES", quantity);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.True(quantity >= response.Promotions.Count());
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public async Task Handle_Response_Contains_Promotion_Count_param(int quantity)
    {
        var mapperMock = new Mock<IMapper>();
        var repoMock = new Mock<IPromotionsRepository>();

        var fakePromotions = FakePromotionsData.GetPromotions(_ => true);


        repoMock.Setup(x => x.GetAll("ES", new CancellationToken())).Returns(fakePromotions);
        mapperMock.Setup(m => m.Map<PromotionTextBaseDTO>(It.IsAny<DisplayContent>())).Returns(FakePromotionsData.CreateFakePromotionTextDTO());
        mapperMock.Setup(x => x.Map<PromotionBaseDTO>(It.IsAny<Promotion>())).Returns(FakePromotionsData.CreateFakePromotionDTO());

        var handler = new GetAllPromotionHandlerV2(repoMock.Object, mapperMock.Object);
        var request = new GetAllPromotionsRequestV2("ES", "ES", quantity);

        var response = await handler.Handle(request, new CancellationToken());

        Assert.True(quantity >= response.Promotions.Count());
    }


    [Fact]
    public async Task Handle_Repository_GetAll_Filterting_By_Country_Code_Was_Called()
    {
        var mapperMock = new Mock<IMapper>();
        var repoMock = new Mock<IPromotionsRepository>();

        var fakePromotions = FakePromotionsData.GetPromotions(x => x.CountryCode == "ES");


        repoMock.Setup(x => x.GetAll("ES", new CancellationToken())).Returns(fakePromotions);
        mapperMock.Setup(m => m.Map<PromotionTextBaseDTO>(It.IsAny<DisplayContent>())).Returns(FakePromotionsData.CreateFakePromotionTextDTO());
        mapperMock.Setup(x => x.Map<PromotionBaseDTO>(It.IsAny<Promotion>())).Returns(FakePromotionsData.CreateFakePromotionDTO());

        var handler = new GetAllPromotionHandlerV2(repoMock.Object, mapperMock.Object);
        var request = new GetAllPromotionsRequestV2("ES", "ES", 5);

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
        mapperMock.Setup(m => m.Map<PromotionTextBaseDTO>(It.IsAny<DisplayContent>())).Returns(FakePromotionsData.CreateFakePromotionTextDTO());
        mapperMock.Setup(x => x.Map<PromotionBaseDTO>(It.IsAny<Promotion>())).Returns(FakePromotionsData.CreateFakePromotionDTO());


        var handler = new GetAllPromotionHandlerV2(repoMock.Object, mapperMock.Object);
        var request = new GetAllPromotionsRequestV2("ES", "ES", 5);

        var response = await handler.Handle(request, cancellationToken);
        var promotionList = await fakePromotions.ToListAsync(cancellationToken);
        Assert.Equal(promotionList.Count(), response.Promotions.Count());
    }
}

