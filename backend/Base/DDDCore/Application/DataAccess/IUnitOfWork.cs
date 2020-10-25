using System;
using System.Threading.Tasks;

namespace DDDCore.Application.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        Task Commit();
    }
}