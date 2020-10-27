using RepositoryUnitOfWorkNoSql.Model;
using RepositoryUnitOfWorkNoSql.Repositories.Interface;

namespace RepositoryUnitOfWorkNoSql.Repositories
{
    public class UserRepository : BaseRepository<User>, IUser
    {
        public UserRepository(IMongoContext context) : base(context)
        {
            
        }
    }
}