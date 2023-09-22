namespace Repositories.Contracts
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }

        void Save();

        Task SaveAsync();
    }
}
