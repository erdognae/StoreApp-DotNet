using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Concreates;
using Repositories.Contracts;
using Services;
using Services.Contracts;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<RepositoryContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection"),
    b => b.MigrationsAssembly("StoreApp")); // Migrations bu tanım sayesinde StoreApp altında oluşturulur.

});

builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IProductServices, ProductManager>();
builder.Services.AddScoped<ICategoryServices, CategoryManager>();

builder.Services.AddAutoMapper(typeof(Program)); //Automap'in IoC kaydı burada yapılmıştır. builder.Services.AddAutoMapper(typeof(Program)); kodu ile mapping profilleri otomatik olarak yüklenecek.
/*
IRepositoryManager -> RepositoryManager: Uygulamanın herhangi bir yerinde IRepositoryManager arayüzü ihtiyaç duyulduğunda, DI sistemi RepositoryManager'in bir örneğini sağlar.
IProductRepository -> ProductRepository: Uygulamanın herhangi bir yerinde IProductRepository arayüzü ihtiyaç duyulduğunda, DI sistemi ProductRepository'nin bir örneğini sağlar.
Aynısı diğerleri için de geçerlidir.
*/


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); //wwwroot kullanılabilir hale gelir.

app.UseRouting();

app.UseAuthorization();



app.MapAreaControllerRoute(
    name: "Admin",
    areaName: "admin",
    pattern: "admin/{controller=Dashboard}/{action=Index}/{id?}");

app.MapControllerRoute( 
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
