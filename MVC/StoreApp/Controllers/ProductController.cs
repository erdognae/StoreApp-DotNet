using Microsoft.AspNetCore.Mvc;
using Services.Contracts;


namespace StoreApp.Controllers
{
public class ProductController : Controller
{
    private readonly IServiceManager _manager; //DI

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

    public IActionResult Index()
    {   
     var model= _manager.ProductServices.GelAllProducts(false).ToList();
     return View(model);
    }

    public IActionResult Get([FromRoute(Name ="id")] int id)
    {   
     var model= _manager.ProductServices.GetOneProduct(id,false);
     return View(model);
    }

}
}