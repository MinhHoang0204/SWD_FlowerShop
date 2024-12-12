using SWD.FlowerShop.Repos.Entities;
using System.Threading.Tasks;

public interface IUserRepository
{
    Task<User> GetUserByUsername(string username);
    Task<bool> AddUser(User user);
}
