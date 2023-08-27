using Hr_management.MVC.Contracts;
using Hr_management.MVC.Contracts.LeaveType;
using Hr_management.MVC.Services;
using Hr_management.MVC.Services.Base;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var apiBaseAddress = builder.Configuration.GetSection("ApiBaseAddress").Value;

builder.Services.AddHttpClient<IClient, Client>(p => p.BaseAddress = new Uri(apiBaseAddress));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<ILocalStorageService, LocalStorageService>();
builder.Services.AddScoped<ILeaveTypeService, LeaveTypeServices>();


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
