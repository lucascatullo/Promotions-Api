using PromotionEngine.Application.Shared.Extensions;
using PromotionEngine.Application.Shared.Persistence;
using PromotionEngine.Entities;

namespace PromotionEngine.Application.Infrastructure.Repositories;
public class PromotionsRepository : BaseRepository<Promotion>, IPromotionsRepository
{
    public PromotionsRepository(DatabaseConnection databaseConnectionInfo) : base(databaseConnectionInfo)
    {
    }

    public async Task<Promotion?> FindByIdOrDefaultAsync(Guid id, CancellationToken cancellationToken)
    {
        var promotions = await _db.QueryAsync(_ => _.Id == id, cancellationToken).ToListAsync(cancellationToken);


        return promotions.FirstOrDefault();
    }

    public IAsyncEnumerable<Promotion> GetAll(string countryCode, CancellationToken cancellationToken)
    {
        return _db.QueryAsync(_ => _.CountryCode == countryCode, cancellationToken);
    }


}
