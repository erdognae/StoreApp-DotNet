using Services.Contracts;

namespace Services
{

    public class ServiceManager : IServiceManager
    {

        private readonly IProductServices _productServices;
        private readonly ICategoryServices _categoryServices;

        public ServiceManager(IProductServices productServices, ICategoryServices categoryServices)
        {
            _productServices = productServices;
            _categoryServices = categoryServices;
        }

        public IProductServices ProductServices => _productServices;

        public ICategoryServices CategoryServices => _categoryServices;
    }

}