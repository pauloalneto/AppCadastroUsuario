using Common.Entity;

namespace Common.Data
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
