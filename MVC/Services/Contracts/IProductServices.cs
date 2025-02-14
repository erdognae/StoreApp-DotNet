using Entitites.Dtos;
using Entitites.Models;

namespace Services.Contracts
{

    public interface IProductServices
    {

        IEnumerable<Product> GelAllProducts(bool trackChanges); 
        Product? GetOneProduct (int id, bool trackChanges); 

        void CreateProduct(ProductDtForInsertion productDto);
        void UpdateProduct(ProductDtoForUpdate productDto);
        void DeleteOneProduct(int id);
        ProductDtoForUpdate GetOneProductForUpdate(int id, bool trackChanges);
    }



}
