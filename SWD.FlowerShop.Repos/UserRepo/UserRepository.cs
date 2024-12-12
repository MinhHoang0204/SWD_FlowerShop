using Microsoft.EntityFrameworkCore;
using SWD.FlowerShop.Repos;
using SWD.FlowerShop.Repos.Entities;
using System.Linq;
using System.Threading.Tasks;

public class UserRepository : IUserRepository
{
    private readonly FlowerShopContext _context;

    public UserRepository(FlowerShopContext context)
    {
        _context = context;
    }

    public async Task<User> GetUserByUsername(string username)
    {
        // Lấy người dùng từ cơ sở dữ liệu
        return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task<bool> AddUser(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return true;
    }
}
