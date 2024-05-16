using Microsoft.AspNetCore.Mvc;
using Products_image.dataContext;
using Products_image.Models;

namespace Crud_Operation_Practice.Controllers
{
    public class ProductController : Controller
    {
        private readonly databaseContext _context;
        public string env;

        public ProductController(databaseContext context , IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            env = Path.Combine(webHostEnvironment.WebRootPath,"image");
        }
        public IActionResult Index()
        {
            ViewBag.Products = _context.Products.ToList();

            return View();
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Products products)
        {
            var filePath = Path.Combine(env , products.ProdImage.FileName);

            using (var imagefile = new FileStream(filePath, FileMode.Create))
            {
                products.ProdImage.CopyTo(imagefile);
            }
            products.ProdImagePath = products.ProdImage.FileName;
          _context.Products.Add(products);
            _context.SaveChanges();
            return View();
        }
        [HttpPost]
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var proddel = _context.Products.Find(Id);
            _context.Products.Remove(proddel);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int Id)
        {
            ViewBag.updateprod = _context.Products.Find(Id);
            return View();
        }
        [HttpPost]
        public IActionResult Update(Products prod)
        {
            var filePath = Path.Combine(env, prod.ProdImage.FileName);

            using (var imagefile = new FileStream(filePath, FileMode.Create))
            {
                prod.ProdImage.CopyTo(imagefile);
            }
            prod.ProdImagePath = prod.ProdImage.FileName;
            _context.Products.Add(prod);

            _context.Products.Update(prod);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}