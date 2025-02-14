using Entitites.Models;
using Repositories.Bases;
using Repositories.Contracts;

namespace Repositories.Concreates
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext context) : base(context)
        {
        }
    }



}