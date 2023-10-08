namespace Common.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
