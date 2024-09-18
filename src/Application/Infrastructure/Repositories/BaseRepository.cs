using PromotionEngine.Application.Shared.Persistence;

namespace PromotionEngine.Application.Infrastructure.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly DatabaseConnection _db;
    public BaseRepository(DatabaseConnection dbConnection)
    {
        _db = dbConnection;
    }



    ///Here i should put all generic T operations for base repository. 
}
