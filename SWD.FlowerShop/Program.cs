using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using SWD.FlowerShop.Repos;


var builder = WebApplication.CreateBuilder(args);

// Cấu hình kết nối cơ sở dữ liệu SQL Server
builder.Services.AddDbContext<FlowerShopContext>(options =>
    options.UseSqlServer("DefaultConnectionString"));

// Đăng ký IUserService và UserService
builder.Services.AddScoped<IUserService, UserService>();

// Đăng ký IUserRepository và UserRepository
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Thêm dịch vụ MVC cho API controllers
builder.Services.AddControllers();

// Thêm dịch vụ Swagger
builder.Services.AddEndpointsApiExplorer();  // Để Swagger có thể duyệt API
builder.Services.AddSwaggerGen();  // Thêm Swagger Gen

var app = builder.Build();

// Kiểm tra môi trường phát triển và cấu hình Swagger UI
if (app.Environment.IsDevelopment())  // Chỉ kích hoạt Swagger khi môi trường là Development
{
    app.UseSwagger();  // Sử dụng Swagger để tạo tài liệu API
    app.UseSwaggerUI();  // Mở Swagger UI khi ở môi trường phát triển
}

app.UseRouting();

// Map các controllers API
app.MapControllers();

app.Run();
