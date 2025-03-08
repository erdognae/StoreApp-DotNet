using Entitites.Dtos;
using Entitites.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")] // Arelar içinde eklenmeli
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        private SelectList GetCategoriesSelectList()
        {

            return  new SelectList(_manager.CategoryServices.GetAllCategories(false), "CategoryId", "CategoryName", "1");      
        }
        public IActionResult Index()
        {
            var model= _manager.ProductServices.GelAllProducts(false);


            return View(model);
        }

        public IActionResult Create()
        {   
            ViewBag.Categories  = GetCategoriesSelectList();     
            return View(); 
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] ProductDtForInsertion productDto, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", file.FileName);
        
                // Dosyayı asenkron olarak kaydetme
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                productDto.ImageUrl= String.Concat("/images", file.FileName);

                _manager.ProductServices.CreateProduct(productDto);
                return RedirectToAction("Index");
            }

            
            return View();

        }


        public IActionResult Update([FromRoute] int id)
        {
            ViewBag.Categories = GetCategoriesSelectList();
            var model = _manager.ProductServices.GetOneProductForUpdate(id, false);
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ProductDtoForUpdate productDto)
        {
            if (ModelState.IsValid)
            {
            _manager.ProductServices.UpdateProduct(productDto);
            return RedirectToAction("Index");
            }

            return View();
        }



        [HttpGet]
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {

           _manager.ProductServices.DeleteOneProduct(id);
            return RedirectToAction("Index");


        }

    }
}