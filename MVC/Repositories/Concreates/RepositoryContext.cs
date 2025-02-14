using System.Reflection;
using Entitites.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Config;
/*
RepositoryContext: Veritabanı bağlantısını ve tabloları yönetir, 
RepositoryBase<T>'e veritabanı işlemleri için altyapı sağlar.
*/

namespace Repositories.Concreates
{
    public class RepositoryContext(DbContextOptions<RepositoryContext> options) : DbContext(options)

    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
             /*----Config----
            modelBuilder.Entity<Product>().HasData(  //Seed Data
                new Product { ProdcutId = 1,CategoryId=2, ProductName = "HP Laptop", ProductPrice = 22000 },
                new Product { ProdcutId = 2,CategoryId=2, ProductName = "PS5", ProductPrice = 36000 },
                new Product { ProdcutId = 3,CategoryId=2, ProductName = "Gaming Laptop", ProductPrice = 32000 },
                new Product { ProdcutId = 4,CategoryId=2, ProductName = "Mause", ProductPrice = 2200 },
                new Product { ProdcutId = 5,CategoryId=2, ProductName = "Keyboard", ProductPrice = 16000 },
                new Product { ProdcutId = 6,CategoryId=1, ProductName = "Ulusların Düşüşü", ProductPrice = 420 },
                new Product { ProdcutId = 7,CategoryId=1, ProductName = "Sistem ve Network Mühendisliği", ProductPrice = 760 }
            ); 
            

            modelBuilder.Entity<Product>().HasKey( //PrimaryKey
                p => new { p.ProdcutId });
            
            -----

            modelBuilder.Entity<Category>().HasData(
                new Category{ CategoryId=1,  CategoryName="Book"},
                new Category{ CategoryId=2, CategoryName="Electronic"}

            );
            
             modelBuilder.Entity<Category>().HasKey( //PrimaryKey
                p => new { p.CategoryId });

            
            ----Config----
            
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new CategoryConfig());

            böyle ya da hemen aşağıdaki gibi config uygulanabilir

            */


            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); 
            // Hemen yukarıdaki kodun aksine dinamik bir config çözümlenmesi sağlanır ve her defasında tek tek config tanımlamaya gerke kalmaz.



        }

    }

    //DbSet<Product> Product.cs dosyasındaki tanımlara göre Products adlı veri tabanının temsilini oluşturur. Products tabloyu temsil eder.
    //Bu tanımlardan sonra fiziksel olarak veri tabanında oluşturmak için Connection Strings'e başvurulur ve EF tooldan fayfalanır.


}