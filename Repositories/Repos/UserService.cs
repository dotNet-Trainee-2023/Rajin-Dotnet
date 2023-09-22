using Entities;

namespace Assignment3.Services
{
    public class UserService : IUserService
    {
        private readonly UserDbContext _context;
        public UserService(UserDbContext context) 
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            User? user= _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public User? GetUser(int id)
        {
            return _context.Users.Find(id);
        }

        public List<User> GetUsers()
        {
            return _context.Users.ToList();   
        }

        public void UpdateUser(User user)
        {
            var newVal = _context.Users.Find(user.Id);
            if (newVal != null)
            {
                newVal.Name = user.Name;
                newVal.Email = user.Email;
                newVal.Address = user.Address;
                newVal.PhoneNumber = user.PhoneNumber;


                _context.Users.Update(newVal);
                _context.SaveChanges();
            }
        }
    }
}
