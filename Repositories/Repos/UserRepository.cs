using Entities;
using Repositories.Contracts;

namespace Repositories.Repos
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(UserDbContext context) : base(context)
        {
        }
        

        public void TestMethod()
        {
            throw new NotImplementedException();
        }
    }
}
