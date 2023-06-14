
using example.DataAccess.Repository;
using example.DataAccess.Repository.IRepository;
using example.Utility;
using example_web_mvc.DataAccess.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Stripe;
// Tạo mơi một đối tượng WebapplicationBuider và cấu hình ứng dụng
var builder = WebApplication.CreateBuilder(args);

// Đăng kí dịch vụ Controller và Views Trong container dịch vụ
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.Configure<StripeSetting>(builder.Configuration.GetSection("Stripe"));

// (options => options.SignIn.RequireConfirmedAccount = true yêu cầu tài khoản của họ phải xác nhận qua email trc
//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();

// add quyen nguoi dung 
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
//ứng dụng sẽ chuyển hướng người dùng đến khi họ cần đăng nhập, đăng xuất hoặc khi họ bị từ chối truy cập.
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});


// Khai báo add Razor khi dùng identity
builder.Services.AddRazorPages();
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
builder.Services.AddScoped<IEmailSender, EmailSender>();
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
StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe:SecretKey").Get<string>();
app.UseRouting();

// xác định danh tính người dùng 
app.UseAuthentication();

// ủy quyền cho người dùng 
app.UseAuthorization();

// sử dụng Map cho Razor khi dùng identity
app.MapRazorPages();
// Use CORS policy
app.UseCors("VueCorsPolicy");

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.Run();


