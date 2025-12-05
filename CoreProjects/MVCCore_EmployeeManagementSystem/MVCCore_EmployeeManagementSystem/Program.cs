using System;
using Microsoft.EntityFrameworkCore;
using MVCCore_EmployeeManagementSystem.Data;
using MVCCore_EmployeeManagementSystem.Repository;
using MVCCore_EmployeeManagementSystem.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
//Adding the dependency injection for the repository and services
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
// Adding services for Employee and Attendance
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
// Adding services for Attendance
builder.Services.AddScoped<IAttendanceService, AttendanceService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
