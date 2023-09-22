
using Entities;

namespace Assignment3.Services
{
    public interface IUserService
    {
        List<User> GetUsers();
        User? GetUser(int id);
        void CreateUser(User user); 
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}
