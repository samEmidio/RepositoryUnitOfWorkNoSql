using System;
using System.Threading.Tasks;

namespace RepositoryUnitOfWorkNoSql.UnitOfWork.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}