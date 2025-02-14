using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")] //eklenmeli
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
    }


}