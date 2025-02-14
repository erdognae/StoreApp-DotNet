using Repositories.Concreates;
using Repositories.Contracts;

namespace Repositories
{
    public class RepositoryManager : IRepositoryManager
    {   
        private readonly IProductRepository _productRepository;
        private readonly RepositoryContext _context;
        private readonly ICategoryRepository _categoryRepository;

        public RepositoryManager(
        IProductRepository productRepository, 
        RepositoryContext context, 
        ICategoryRepository categoryRepository )
        {
            _context = context; //IoC ile gereklilikler sağlanır.
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

    

        public IProductRepository Product => _productRepository; 
        public ICategoryRepository Category => _categoryRepository; 

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

         /*
        public IProductRepository Product        public IProductRepository Product => _productRepository; şeklinde de ifade edilebilir. 
        {                   
            get
            {
                return _productRepository;
            }
        } */