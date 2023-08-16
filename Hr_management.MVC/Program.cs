using Hr_management.MVC.Contracts.LeaveTypeStorage;
using Hr_management.MVC.Services.Base;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var apiBaseAddress = builder.Configuration.GetSection("ApiBaseAddress").Value;

builder.Services.AddHttpClient<IClient, Client>(p => p.BaseAddress = new Uri(apiBaseAddress));

builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddSingleton<ILocalStorageService, LocalStorageService>(); // wireUp

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
