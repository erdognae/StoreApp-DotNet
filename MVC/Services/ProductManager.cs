using AutoMapper;
using Entitites.Dtos;
using Entitites.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ProductManager : IProductServices
    {
        private readonly IRepositoryManager _manager;
        private IMapper _mapper;

        public ProductManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public void CreateProduct(ProductDtForInsertion productDto)
        {   

            /*
            Product product= new Product()  // Burada tipler manuel olarak (automap olmadan) uygun hale getirilmiştir.
            {
                CategoryId = productDto.CategoryId,
                ProductName = productDto.ProductName,
                ProductPrice = productDto.ProductPrice,
            
            }; */


            // Otomatik (automapper) ile tip uyumu sağlanmıştır. nesneler arası dönüşüm gerçekleşmiştir. productDto girdidir Product'a map edilir.

            Product product = _mapper.Map<Product>(productDto); 
            _manager.Product.CreateOneProduct(product);
            _manager.Save();
        }

        public void DeleteOneProduct(int id)
        {   
            Product product = _manager.Product.GetOneProduct(id,false);

            if (product is not null)
            {
             _manager.Product.DeleteOneProduct(product);
             _manager.Save();
            }
        } 

    

        public IEnumerable<Product> GelAllProducts(bool trackChanges)
        {
            return _manager.Product.GetAllProducts(trackChanges);
        }

        public Product? GetOneProduct(int id, bool trackChanges) //burada örnek bir logic işletilmiştir.
        {
            var product = _manager.Product.GetOneProduct(id, trackChanges);
            if (product == null)
            {
                throw new Exception("Product not found");
            }
            return product;
        }

        public ProductDtoForUpdate GetOneProductForUpdate(int id, bool trackChanges)
        {
            var product = GetOneProduct(id, trackChanges);
            var productDto = _mapper.Map<ProductDtoForUpdate>(product);
            return productDto;
        }

        public void UpdateProduct(ProductDtoForUpdate productDto)
        {
         /*
        var entity = _manager.Product.GetOneProduct(productDto.ProdcutId, true);
        entity.ProductName = productDto.ProductName;
        entity.ProductPrice = productDto.ProductPrice;
        entity.CategoryId = productDto.CategoryId;
        */

        var entity = _mapper.Map<Product>(productDto);
        _manager.Product.UpdateOneProduct(entity);
        _manager.Save();
    }

    }





}