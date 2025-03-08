using static Api.Shared.IoC;
namespace Api.Persistence
{
    public class UnitOfWork(StoreDbContext dbContext) : IScoped
    {
        public Task<int> CommitAsync(CancellationToken c = default)
        {
            return dbContext.SaveChangesAsync(c);
        }
        public int Commit()
        {
            return dbContext.SaveChanges();
        }
    }
}
