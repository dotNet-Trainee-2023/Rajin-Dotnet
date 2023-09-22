using Entities;
using Repositories.Contracts;

namespace Repositories.Repos
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UserDbContext _context;
        public IUserRepository Users { get; set; }

        public UnitOfWork(UserDbContext context)
        {
            _context = context;
            Users = new UserRepository(context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
