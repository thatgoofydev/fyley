using System;
using System.Data.Common;
using System.Threading.Tasks;

namespace DDDCore.Application.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        IEventStore EventStore { get; }
        
        Task Commit();
        DbConnection GetConnection();
    }
}