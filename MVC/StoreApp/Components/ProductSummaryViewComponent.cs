using Microsoft.AspNetCore.Mvc;
using Repositories.Concreates;
using Services.Contracts;

namespace StoreApp.Components
{
    public class ProductSummaryViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;

        public ProductSummaryViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public string Invoke()
        {

        return _manager.ProductServices.GelAllProducts(false).Count().ToString();

        }  
    }
    


}