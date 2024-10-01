using Microsoft.EntityFrameworkCore;
using SQL_CRUD_MVC_C_.Data;
using SQL_CRUD_MVC_C_.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ToDoDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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

app.MapControllerRoute(name: "default",
               pattern: "{controller=Home}/{action=Index}/{id?}");
//app.MapControllerRoute(name: "TaskToDoes",
//    pattern: "{controller=TasktoDoes}/{action=Index}/{id?}");

app.Run();
