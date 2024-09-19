using Microsoft.AspNetCore.Mvc;
using Store_Manager.Models;

namespace Store_Manager.Controllers
{
    public class ProductController : Controller
    {
        static List<Product> products = new List<Product>();


        public IActionResult Index()
        {

            return Redirect("Product/ShowAll");
        }
        public IActionResult ShowAll()
        {
            return View("ShowAll", products);
        }

        // Starting DB
        //public IActionResult ShowAll()
        //{
        //    ViewData["Heading"] = "Product Management";
         
        //    var products = new List<Product>();
        //    products.Add(new Product { Id = 101, Price = 99000, ProductName = "IOS" });
        //    products.Add(new Product { Id = 102, Price = 99000, ProductName = "Android" });
        //    products.Add(new Product { Id = 103, Price = 99000, ProductName = "Windows" });

        //    return View(products);
        //}

        // Create
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create([Bind("Id", "ProductName", "Price")] Product product)
        {
            products.Add(product);
            return RedirectToAction("ShowAll");
        }

        // Edit
        public IActionResult Edit(int id)
        {
            Product p = products.SingleOrDefault(q => q.Id == id);
            if (p != null) // Tìm Thấy
                return View(p);
            else
                return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id", "ProductName", "Price")] Product product)
        {
            Product p = products.SingleOrDefault(q => q.Id == id);
            if (p != null) // Tìm Thấy
            {
                p.ProductName = product.ProductName;
                p.Price = product.Price;
            }

            return RedirectToAction("ShowAll");
        }

        public IActionResult Delete(int id)
        {
            Product p = products.SingleOrDefault(q => q.Id == id);
            if (p != null) // Found
            {
                products.Remove(p);
            }

            return RedirectToAction("ShowAll");
        }

    }
}
