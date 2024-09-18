using PromotionEngine.Entities;
using System.Runtime.CompilerServices;

namespace PromotionEngine.Application.Shared.Persistence;

/// <summary>
/// DISCLAIMER: YOU CAN'T MODIFY THIS FILE, THIS IS BEEING USED TO SIMULATE A DATABASE
/// </summary>
#pragma warning disable CS9113 // Parameter is unread.
public class DatabaseConnection(string connectionString) : IDisposable
#pragma warning restore CS9113 // Parameter is unread.
{
    public async IAsyncEnumerable<Promotion> QueryAsync(Func<Promotion, bool> predicate, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        foreach (var promotion in promotions.Where(predicate))
        {
            if (cancellationToken.IsCancellationRequested)
                break;

            await Task.Yield();
            yield return promotion;
        }
    }

    public Task ConnectAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public Task<bool> PingAsync()
    {
        return Task.FromResult(true);
    }

    public void Dispose()
    {
        // example purposes
    }

    static readonly List<Promotion> promotions = new List<Promotion>() {

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
        };
}
