using CourseUdemyNetMvc.Data;
using CourseUdemyNetMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CourseUdemyNetMvc.Controllers;

public class ProductController : Controller
{
    private readonly ApplicationDbContext _db;
    
    public ProductController(ApplicationDbContext db)
    {
        _db = db;
    }

    // GET INDEX
    public IActionResult Index()
    {
        IEnumerable<Product> productList = _db.Product!.Include(c => c.Category)
                                                      .Include(a => a.ApplicationType);
        return View(productList);
    }
    
    // GET UPSERT
    public IActionResult Upsert(int? id)
    {
        IEnumerable<SelectListItem> categoriaDropDown = _db.Category!.Select(c => new SelectListItem()
        {
            Text = c.CategoryName,
            Value = c.Id.ToString()
        });

        ViewBag.categoriaDropDown = categoriaDropDown;
            
        var product = new Product();
        if (id is null)
            return View(product);
        
        product = _db.Product!.Find(id);
        if (product is null)
            return NotFound();
            
        return View(product);
    }
    
    // GET DELETE
    public IActionResult Delete(int? id)
    {
        if (id is null or 0)
            return NotFound();

        var product = _db.Product!.Find(id);

        if (product is null)
            return NotFound();
        
        return View(product);
    }
    
    // POST DELETE
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(Product? product)
    {
        if (product is null)
        {
            return NotFound();
        }
        
        _db.Product!.Remove(product);
        _db.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}