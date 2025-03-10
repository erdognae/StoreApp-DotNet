using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Components
{   
    public class CategoriesMenuViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;

        public CategoriesMenuViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public IViewComponentResult Invoke() // View ile dönüş yapılır. Components/CategoriesMenu/Default.cshtml.
        {
        var categories = _manager.CategoryServices.GetAllCategories(false);
        return View(categories);
        }

    }
    
}