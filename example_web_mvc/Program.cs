
using example.DataAccess.Repository;
using example.DataAccess.Repository.IRepository;
using example_web_mvc.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
// Tạo mơi một đối tượng WebapplicationBuider và cấu hình ứng dụng
var builder = WebApplication.CreateBuilder(args);

// Đăng kí dịch vụ Controller và Views Trong container dịch vụ
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add CORS services cho vueJS
builder.Services.AddCors(options =>
{
    options.AddPolicy("VueCorsPolicy", builder =>
    {
        builder
            .WithOrigins("http://localhost:8080") // Replace with the origin of your Vue app
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
// Tạo mới đối tượng Webappcation từ WebApplicationBuider
var app = builder.Build();

// Cấu hình pipelinne xử lý cấu hình HTTP
if (!app.Environment.IsDevelopment())
{
    // xử ký ngoại lệ và chuyển đến trang lỗi
    app.UseExceptionHandler("/Home/Error");
    // kích hoạt https strict transport security (HSTS)
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
// chuyển huingw yêu cầu HTTP sang HTTPS
app.UseHttpsRedirection();

// phục vụ các tệp tĩnh
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Use CORS policy
app.UseCors("VueCorsPolicy");

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.Run();


