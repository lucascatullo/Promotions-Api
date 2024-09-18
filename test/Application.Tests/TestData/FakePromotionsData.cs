
using PromotionEngine.Application.Features.Promotions.Dto;
using PromotionEngine.Entities;

namespace PromotionEngine.Application.TestData;

internal static class FakePromotionsData
{
    public static Promotion CreateFakePromotion(Action<Promotion>? onCreate = null)
    {
        var response = new Promotion()
        {
            Id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
            CountryCode = "ES",
            CreatedDate = DateTime.Now,
            Images = new List<string>() { "Image1", "Image2" },
            LastModifiedDate = DateTime.Now,
            Status = PromotionStatus.Enabled,
            EndValidityDate = DateTime.Now.AddDays(1),

            DisplayContent = new Dictionary<string, DisplayContent>()
                {
                    {
                        "ES",
                        new DisplayContent(){
                            Description = "Description",
                            DiscountDescription = "Discount Description",
                            DiscountTitle = "Discount Title",
                            Title = "Title"
                        }
                    },
                    {
                        "EN",
                        new DisplayContent(){
                            Description = "Description",
                            DiscountDescription = "Discount Description",
                            DiscountTitle = "Discount Title",
                            Title = "Title"
                        }
                    }
                }
        };

        onCreate?.Invoke(response);
        return response;
    }

    public static PromotionBaseDTO CreateFakePromotionDTO() => new()
    {
        Id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
        Images = new List<string>() { "Image1", "Image2" },
        EndValidityDate = DateTime.Now.AddDays(1),
    };

    public static PromotionTextBaseDTO CreateFakePromotionTextDTO() => new()
    {
        Description = "Description",
        DiscountDescription = "Discount Description",
        DiscountTitle = "Discount Title",
        Title = "Title"
    };


    public static async IAsyncEnumerable<Promotion> GetPromotions(Func<Promotion, bool> whereCondition)
    {
        var promotions = FakePromotions().Where(whereCondition);

        foreach (var promotion in promotions)
        {
            await Task.Yield();
            yield return promotion;
        }
    }


    private static List<Promotion> FakePromotions() => [

            new Promotion()
            {
                Id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                CountryCode = "ES",
                CreatedDate = DateTime.Now,
                Images = new List<string>() {"Image1", "Image2"},
                LastModifiedDate = DateTime.Now,
                Status = PromotionStatus.Enabled,
                EndValidityDate = DateTime.Now.AddDays(1),

                DisplayContent = new Dictionary<string, DisplayContent>()
                {
                    {
                        "ES",
                        new DisplayContent(){
                            Description = "Description",
                            DiscountDescription = "Discount Description",
                            DiscountTitle = "Discount Title",
                            Title = "Title"
                        }
                    },
                    {
                        "EN",
                        new DisplayContent(){
                            Description = "Description",
                            DiscountDescription = "Discount Description",
                            DiscountTitle = "Discount Title",
                            Title = "Title"
                        }
                    }
                },
                Discounts = new List<Discount>()
                {
                    new StoreDiscount()
                    {
                        FinalPrice = 1,
                        HasPrice = true,
                        LowestPriceLast30Days = 1,
                        OriginalPrice = 1,
                        PriceType = "Type1",
                        UnitsToBuy = 1,
                        UnitsToPay = 1
                    }
                }
            },
            new Promotion()
            {
                Id = Guid.NewGuid(),
                CountryCode = "DE",
                CreatedDate = DateTime.Now,
                Images = new List<string>() {"Image3", "Image4"},
                LastModifiedDate = DateTime.Now,
                Status = PromotionStatus.Enabled,
                EndValidityDate = DateTime.Now.AddDays(2),
                DisplayContent = new Dictionary<string, DisplayContent>()
                {
                    {
                        "DE",
                        new DisplayContent()
                        {
                            Description = "Description",
                            DiscountDescription = "Discount Description",
                            DiscountTitle = "Discount Title",
                            Title = "Title"
                        }
                    }
                },
                Discounts = new List<Discount>()
                {
                    new StoreDiscount()
                    {
                        FinalPrice = 1,
                        HasPrice = true,
                        LowestPriceLast30Days = 1,
                        OriginalPrice = 1,
                        PriceType = "Type1",
                        UnitsToBuy = 1,
                        UnitsToPay = 1
                    }
                }
            },
            new Promotion()
            {
                Id = Guid.NewGuid(),
                CountryCode = "DE",
                CreatedDate = DateTime.Now,
                Images = new List<string>() {"Image3", "Image4"},
                LastModifiedDate = DateTime.Now,
                Status = PromotionStatus.Enabled,
                EndValidityDate = DateTime.Now.AddDays(2),
                DisplayContent = new Dictionary<string, DisplayContent>()
                {
                    {
                        "DE",
                        new DisplayContent()
                        {
                            Description = "Description",
                            DiscountDescription = "Discount Description",
                            DiscountTitle = "Discount Title",
                            Title = "Title"
                        }
                    }
                },
                Discounts = new List<Discount>()
                {
                    new StoreDiscount()
                    {
                        FinalPrice = 1,
                        HasPrice = true,
                        LowestPriceLast30Days = 1,
                        OriginalPrice = 1,
                        PriceType = "Type1",
                        UnitsToBuy = 1,
                        UnitsToPay = 1
                    },
                    new OnlineDiscount()
                    {
                        FinalPrice = 1,
                        HasPrice = true,
                        LowestPriceLast30Days = 1,
                        OriginalPrice = 1,
                        PriceType = "Type1",
                        UnitsToBuy = 1,
                        UnitsToPay = 1
                    }
                }
            },
                new Promotion()
            {
                Id = Guid.NewGuid(),
                CountryCode = "DE",
                CreatedDate = DateTime.Now,
                Images = new List<string>() {"Image3", "Image4"},
                LastModifiedDate = DateTime.Now,
                Status = PromotionStatus.Disabled,
                EndValidityDate = DateTime.Now.AddDays(2),
                DisplayContent = new Dictionary<string, DisplayContent>()
                {
                    {
                    "DE",
                        new DisplayContent()
                        {
                        Description = "Description",
                        DiscountDescription = "Discount Description",
                        DiscountTitle = "Discount Title",
                        Title = "Title"
                        }
                    }
                },
                Discounts = new List<Discount>()
                {
                    new StoreDiscount()
                    {
                        FinalPrice = 1,
                        HasPrice = true,
                        LowestPriceLast30Days = 1,
                        OriginalPrice = 1,
                        PriceType = "Type1",
                        UnitsToBuy = 1,
                        UnitsToPay = 1
                    },
                    new OnlineDiscount()
                    {
                        FinalPrice = 1,
                        HasPrice = true,
                        LowestPriceLast30Days = 1,
                        OriginalPrice = 1,
                        PriceType = "Type1",
                        UnitsToBuy = 1,
                        UnitsToPay = 1
                    }
                }
            }
        ];
}
