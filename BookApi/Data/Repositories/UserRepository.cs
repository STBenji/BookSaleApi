using BookApi.Data;
using BookApi.Data.Repositories;
using BookApi.Domain;
using Microsoft.EntityFrameworkCore;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User> GetUserById(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<User> GetUserByEmail(string email)
    {
        return await _context.Users
                             .FirstOrDefaultAsync(user => user.Email == email);
    }

    public async Task Register(User user)
    {
        string passwordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
        user.PasswordHash = passwordHash;

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

    }

    public async Task<User> Login(User user)
    {
        var userResult = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);

        if (userResult == null)
        {
            return null;
        }

        bool isPasswordValid = BCrypt.Net.BCrypt.Verify(user.PasswordHash, userResult.PasswordHash);
        if (!isPasswordValid)
        {
            return null;
        }

        return userResult;
    }
}
