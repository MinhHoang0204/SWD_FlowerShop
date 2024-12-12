using SWD.FlowerShop.Repos.Entities;
using System.Threading.Tasks;

public interface IUserService
{
    Task<bool> Register(User user);
    Task<bool> Login(string username, string password);
}
