using CourseUdemyNetMvc.Data;
using CourseUdemyNetMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseUdemyNetMvc.Controllers;

public class CategoryController : Controller
{
    private readonly ApplicationDbContext _db;

    public CategoryController(ApplicationDbContext db)
    {
        _db = db;
    }
    
    // GET CREATE
    public IActionResult Index()
    {
        IEnumerable<Category>? categoryList = _db.Category;
        return View(categoryList);
    }
    
    // GET CREATE
    public IActionResult Create()
    {
        return View();
    }
    
    // POST CREATE
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Category category)
    {
        if (ModelState.IsValid)
        {
            _db.Category!.Add(category);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        return View(category);
    }
    
    // GET UPDATE
    public IActionResult Update(int? id)
    {
        if (id is null or 0)
            return NotFound();

        var category = _db.Category!.Find(id);

        if (category is null)
            return NotFound();
        
        return View(category);
    }
    
    // POST UPDATE
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Update(Category category)
    {
        if (ModelState.IsValid)
        {
            _db.Category!.Update(category);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        return View(category);
    }
    
    // GET DELETE
    public IActionResult Delete(int? id)
    {
        if (id is null or 0)
            return NotFound();

        var category = _db.Category!.Find(id);

        if (category is null)
            return NotFound();
        
        return View(category);
    }
    
    // POST DELETE
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(Category? category)
    {
        if (category is null)
        {
            return NotFound();
        }
        
        _db.Category!.Remove(category);
        _db.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}