using Foxoft.AttendanceWeb.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Bütün şəbəkə interfeyslərindən (0.0.0.0:5000) dinləmə
builder.WebHost.UseUrls("http://0.0.0.0:5000");

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddMemoryCache();
builder.Services.AddHttpContextAccessor();

// Attendance custom services
builder.Services.AddSingleton<IAttendanceConfigStore, AttendanceConfigStore>();
builder.Services.AddScoped<IQrTokenService, QrTokenService>();
builder.Services.AddScoped<IGeolocationService, GeolocationService>();
builder.Services.AddScoped<IIpValidationService, IpValidationService>();
builder.Services.AddScoped<IDeviceLockService, DeviceLockService>();
builder.Services.AddScoped<IAttendanceService, AttendanceService>();

// CORS dəstəyi (istənilən local/mobil müraciət üçün)
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors();

// Statik fayllar (HTML, JS, CSS)
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapControllers();

// SPA Fallback: əgər marşrut API deyilsə index.html-ə yönəldilsin
app.MapFallbackToFile("index.html");

// Tətbiq qalxan kimi standart brauzerdə avtomatik açılsın
app.Lifetime.ApplicationStarted.Register(() =>
{
    try
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = "http://localhost:5000",
            UseShellExecute = true
        });
    }
    catch
    {
        // Brauzer açıla bilmədikdə səssiz davam edir
    }
});

app.Run();
