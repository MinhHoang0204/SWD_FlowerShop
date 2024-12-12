using SWD.FlowerShop.Repos.Entities;
using SWD.FlowerShop.Repos;
using System.Threading.Tasks;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> Register(User user)
    {
        // Lưu trữ mật khẩu gốc (không khuyến khích trong môi trường thực tế)
        var existingUser = await _userRepository.GetUserByUsername(user.Username);
        if (existingUser != null)
        {
            return false; // Nếu người dùng đã tồn tại
        }

        // Lưu người dùng vào cơ sở dữ liệu
        return await _userRepository.AddUser(user);
    }

    public async Task<bool> Login(string username, string password)
    {
        var user = await _userRepository.GetUserByUsername(username);
        if (user == null || user.Password != password) // Kiểm tra mật khẩu không mã hóa
        {
            return false; // Sai tên người dùng hoặc mật khẩu
        }

        return true; // Đăng nhập thành công
    }
}
