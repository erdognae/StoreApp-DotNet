using Microsoft.AspNetCore.Mvc;

namespace  StoreApp.Areas.Admin.Controllers
{

    public class DashBoardController : Controller
    {
        [Area("Admin")] //eklenmeli

        public IActionResult Index()
        {
            return View();
        }
        



    }
}