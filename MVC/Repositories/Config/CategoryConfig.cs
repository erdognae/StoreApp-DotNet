using Entitites.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{

    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {

            builder.HasKey(x => x.CategoryId);
            builder.Property(x => x.CategoryName).IsRequired();
            builder.HasData //Seed Data
            (
                new Category{ CategoryId=1,  CategoryName="Book"},
                new Category{ CategoryId=2, CategoryName="Electronic"}
            );
        }
    }

}