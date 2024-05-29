
using BookApi.Domain;

namespace BookApi.Data.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmail(string email);
        Task<User> GetUserById(int id);
        Task Register(User user);
        Task<User> Login(User user);

    }
}

