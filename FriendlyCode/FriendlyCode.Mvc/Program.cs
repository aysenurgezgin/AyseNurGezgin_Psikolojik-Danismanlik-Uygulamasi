using FriendlyCode.Business.Abstract;
using FriendlyCode.Business.Concrete;
using FriendlyCode.Data;
using FriendlyCode.Data.Abstract;
using FriendlyCode.Data.Concrete;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=FriendlyCode.sqlite"));

builder.Services.AddScoped<ITrainerService, TrainerManager>();
builder.Services.AddScoped<ITrainerRepository, TrainerRepository>();

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
