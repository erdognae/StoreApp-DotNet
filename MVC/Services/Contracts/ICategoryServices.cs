using Entitites.Models;

namespace Services.Contracts
{

    public  interface ICategoryServices
    {

        IEnumerable<Category> GetAllCategories(bool trackChanges);


    }

}