using Entitites.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class CategoryManager : ICategoryServices 
    {
        private readonly IRepositoryManager _manager;

        public CategoryManager(IRepositoryManager manager)
        {
            _manager = manager;
        }



        public IEnumerable<Category> GetAllCategories(bool trackChanges)
        {
           return _manager.Category.Findall(trackChanges);
        }
    }
}
