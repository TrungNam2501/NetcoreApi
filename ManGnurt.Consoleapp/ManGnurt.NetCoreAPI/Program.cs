using ManGnurt.DataAccessNetcore.IServices;
using ManGnurt.DataAccessNetcore.Services;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// --- 1. Đăng ký dịch vụ (Services) ---
builder.Services.AddControllers();

// Chỉ dùng bộ Swagger này là đủ
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductServices, ProductServices>();

var app = builder.Build();


//app.UseExceptionHandler();
//app.UseHsts();
//app.UseHttpsRedirection();
//app.UseStaticFiles();
//app.UseRouting();
//app.UseStaticFiles();
//app.UseCors();

// --- 2. Cấu hình Pipeline (Middleware) ---
if (app.Environment.IsDevelopment())
{
    // Bật Swagger để có giao diện UI
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ManGnurt.NetCoreAPI.MiddleWare.MyMiddleware>();

app.UseAuthorization();

app.MapControllers();

/// Cấu hình để phục vụ các file tĩnh từ thư mục "File" trong dự án, có thể truy cập qua đường dẫn "/File"
//app.UseStaticFiles(new StaticFileOptions
//{
//    FileProvider= new PhysicalFileProvider(
//        Path.Combine(Directory.GetCurrentDirectory(), "File")),
//    RequestPath= "/File"
//});

app.Run();