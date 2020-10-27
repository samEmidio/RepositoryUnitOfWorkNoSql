using System.Threading.Tasks;
using RepositoryUnitOfWorkNoSql.Repositories.Interface;
using RepositoryUnitOfWorkNoSql.UnitOfWork.Interface;

namespace RepositoryUnitOfWorkNoSql.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMongoContext _context;

        public UnitOfWork(IMongoContext context)
        {
            _context = context;
        }

        public async Task<bool> Commit()
        {
            var changeAmount = await _context.SaveChanges();

            return changeAmount > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}