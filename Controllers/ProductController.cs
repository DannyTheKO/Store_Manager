using Microsoft.AspNetCore.Mvc;
using Store_Manager.Models;

namespace Store_Manager.Controllers
{
    public class ProductController : Controller
    {
        // Create a product array list
        static List<Product> products = new List<Product>
        {
            new Product { Id = 101, Price = 99000, ProductName = "IOS"},
            new Product { Id = 102, Price = 99000, ProductName = "Android"},
            new Product { Id = 103, Price = 99000, ProductName = "Windows"}
        };

        // Redirect into ShowAll.cshtml
        public IActionResult Index()
        {
            return Redirect("Product/ShowAll");
        }

        // Redirect into ShowAll.cshtml and pass the "products" value
        public IActionResult ShowAll()
        {
            return View("ShowAll", products);
        }

        // Redirect to Create.cshtml
        public IActionResult Create()
        {
            return View("Create");
        }

        // Create POST Request
        [HttpPost]
        public IActionResult Create([Bind("Id", "ProductName", "Price")] Product product)
        {
            products.Add(product);
            return RedirectToAction("ShowAll");
        }

        // Redirect to Edit.cshtml
        public IActionResult Edit(int id)
        {
            Product p = products.SingleOrDefault(q => q.Id == id);
            if (p != null) // Found
                return View(p);
            else
                return NotFound();
        }

        // Edit POST Request
        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id", "ProductName", "Price")] Product product)
        {
            Product p = products.SingleOrDefault(q => q.Id == id);
            if (p != null) // Found
            {
                p.ProductName = product.ProductName;
                p.Price = product.Price;
            }

            return RedirectToAction("ShowAll");
        }

        // Delete function
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
