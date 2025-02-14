using Entitites.Models;
using Repositories.Bases;
using Repositories.Contracts;

namespace Repositories.Concreates
{

    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext context) : base(context) //Base'i RepositoryBase'dir. base(context) ifadesi, RepositoryBase sınıfının yapıcısına bu context parametresini geçer. Yani, ProductRepository sınıfı, RepositoryBase sınıfının özelliklerinden yararlanır.
        {
        }

        public void CreateOneProduct(Product product)=> Create(product);


        public void DeleteOneProduct(Product product)=> Remove(product);
    
        public IQueryable<Product> GetAllProducts(bool trackChanges) => Findall(trackChanges);
        
        public void UpdateOneProduct(Product entity) => Update(entity);

        public Product?  GetOneProduct(int id, bool trackChanges)
        {

            var product = FindByCondition(p => p.ProdcutId.Equals(id), trackChanges);

            if (product == null)
            {
            // Null durumunda bir bilgi mesajı döndürülebilir veya bir loglama yapılabilir.
            Console.WriteLine($"Product with ID {id} not found.");
            } 

            return product;  

        }
    }

}