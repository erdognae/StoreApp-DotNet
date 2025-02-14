using Entitites.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    /*
    IypeConfiguration<TEntity> arayüzü, Entity Framework Core'da bir varlık (entity) sınıfını yapılandırmak 
    için kullanılan bir tasarım desenidir. Bu arayüz, veri tabanı eşleştirme ayarlarını bir sınıfta tanımlayarak 
    kodun daha modüler ve yönetilebilir hale gelmesini sağlar. Örneğin aşağıdaki tanımlamalar RepositoryContext üzerinden
    alınıp burada yapılmıştır.
    
    */

    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

           builder.HasKey(p => p.ProdcutId); // ProductId  Primary Key olarak ayarlanır.
           builder.Property(p => p.ProductName).IsRequired();
           builder.Property(p => p.ProductPrice).IsRequired();

           /*
            builder.Property() ifadeleri, Entity Framework Core kullanarak bir varlığın (entity) özelliklerine ilişkin 
            veri tabanı yapılandırmalarını tanımlamak için kullanılır. 
            Bu yöntem, özelliklerin sütun türlerini, zorunluluklarını, uzunluk kısıtlamalarını 
            ve diğer yapılandırmalarını belirlemek için kullanılır.
           */


           builder.HasData //Seed Data
           (
                new Product { ProdcutId = 1,CategoryId=2, ProductName = "HP Laptop", ProductPrice = 22000 },
                new Product { ProdcutId = 2,CategoryId=2, ProductName = "PS5", ProductPrice = 36000 },
                new Product { ProdcutId = 3,CategoryId=2, ProductName = "Gaming Laptop", ProductPrice = 32000 },
                new Product { ProdcutId = 4,CategoryId=2, ProductName = "Mause", ProductPrice = 2200 },
                new Product { ProdcutId = 5,CategoryId=2, ProductName = "Keyboard", ProductPrice = 16000 },
                new Product { ProdcutId = 6,CategoryId=1, ProductName = "Ulusların Düşüşü", ProductPrice = 420 },
                new Product { ProdcutId = 7,CategoryId=1, ProductName = "Sistem ve Network Mühendisliği", ProductPrice = 760 }
            );


        }
    }


}