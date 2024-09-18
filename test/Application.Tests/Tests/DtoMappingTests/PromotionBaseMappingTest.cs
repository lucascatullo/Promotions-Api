
using AutoMapper;
using Moq;
using PromotionEngine.Application.Features.Promotions.Dto;
using PromotionEngine.Application.TestData;
using PromotionEngine.Entities;
using Xunit;

namespace PromotionEngine.Application.Tests.DtoMappingTests;

public class PromotionBaseMappingTest
{
    [Fact]
    public void MapPromotionBase_Is_Called_Once()
    {
        var promotion = FakePromotionsData.CreateFakePromotion();
        var mapperMock = new Mock<IMapper>();

        mapperMock.Setup(m => m.Map<PromotionBaseDTO>(promotion)).Returns(FakePromotionsData.CreateFakePromotionDTO());

        PromotionBaseDTO.From(promotion, "ES", mapperMock.Object);
        mapperMock.Verify(m => m.Map<PromotionBaseDTO>(promotion), Times.Once);
    }

    [Theory]
    [InlineData("ES")]
    [InlineData("EN")]
    public void MapPromotionText_Is_Called_If_There_Is_One_With_Correct_Lenguage(string language)
    {
        var promotion = FakePromotionsData.CreateFakePromotion();
        var mapperMock = new Mock<IMapper>();

        mapperMock.Setup(m => m.Map<PromotionBaseDTO>(promotion)).Returns(FakePromotionsData.CreateFakePromotionDTO());
        mapperMock.Setup(m => m.Map<PromotionTextBaseDTO>(promotion.DisplayContent![language])).Returns(FakePromotionsData.CreateFakePromotionTextDTO());


        PromotionBaseDTO.From(promotion, language, mapperMock.Object);

        mapperMock.Verify(m => m.Map<PromotionTextBaseDTO>(promotion.DisplayContent![language]), Times.Once);
    }


    [Fact]
    public void MapPromotionText_Is_Not_Mapped_If_DisplayContent_Is_Null()
    {
        var promotion = FakePromotionsData.CreateFakePromotion(p => p.DisplayContent = null);
        var mapperMock = new Mock<IMapper>();

        mapperMock.Setup(m => m.Map<PromotionBaseDTO>(promotion)).Returns(FakePromotionsData.CreateFakePromotionDTO());


        PromotionBaseDTO.From(promotion, "ES", mapperMock.Object);

        mapperMock.Verify(m => m.Map<PromotionTextBaseDTO>(It.IsAny<DisplayContent>()), Times.Never);
    }

    [Theory]
    [InlineData("ES")]
    [InlineData("EN")]
    public void MapPromotionText_Is_Not_Mapped_If_There_is_No_Matching_Lenguage(string removeLanguage)
    {
        var promotion = FakePromotionsData.CreateFakePromotion(p =>
        {
            p.DisplayContent?.Remove(removeLanguage);
        });
        var mapperMock = new Mock<IMapper>();

        mapperMock.Setup(m => m.Map<PromotionBaseDTO>(promotion)).Returns(FakePromotionsData.CreateFakePromotionDTO());


        PromotionBaseDTO.From(promotion, removeLanguage, mapperMock.Object);

        mapperMock.Verify(m => m.Map<PromotionTextBaseDTO>(It.IsAny<DisplayContent>()), Times.Never);
    }


    [Fact]
    public void Returns_PromotionBaseDTO()
    {
        var promotion = FakePromotionsData.CreateFakePromotion();
        var mapperMock = new Mock<IMapper>();

        mapperMock.Setup(m => m.Map<PromotionBaseDTO>(promotion)).Returns(FakePromotionsData.CreateFakePromotionDTO());

        var response = PromotionBaseDTO.From(promotion, "ES", mapperMock.Object);

        Assert.IsType<PromotionBaseDTO>(response);
    }
}
