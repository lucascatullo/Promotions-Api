using PromotionEngine.Entities;

namespace PromotionEngine.Application.Infrastructure.Repositories;

public interface IPromotionsRepository
{
    IAsyncEnumerable<Promotion> GetAll(string countryCode, CancellationToken cancellationToken);
    public Task<Promotion?> FindByIdOrDefaultAsync(Guid id, CancellationToken cancellationToken);

}