using Entities;

namespace Repositories.Contracts
{
    public interface IUserRepository : IBaseRepository<User>
    {
        void TestMethod();
    }
}
