using CourseUdemyNetMvc.Data;
using CourseUdemyNetMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseUdemyNetMvc.Controllers;

public class ApplicationTypeController : Controller
{
    private readonly ApplicationDbContext _db;

    public ApplicationTypeController(ApplicationDbContext db)
    {
        _db = db;
    }
    
    // GET INDEX
    public IActionResult Index()
    {
        IEnumerable<ApplicationType>? applicationTypeList = _db.ApplicationType;
        return View(applicationTypeList);
    }
    
    // GET CREATE
    public IActionResult Create()
    {
        return View();
    }
    
    // POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(ApplicationType applicationType)
    {
        if (ModelState.IsValid)
        {
            _db.ApplicationType!.Add(applicationType);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        
        return View(applicationType);
    }
    
    // GET UPDATE
    public IActionResult Update(int? id)
    {
        if (id is null or 0)
            return NotFound();

        var applicationType = _db.ApplicationType!.Find(id);

        if (applicationType is null)
            return NotFound();
        
        return View(applicationType);
    }
    
    // POST UPDATE
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Update(ApplicationType applicationType)
    {
        if (ModelState.IsValid)
        {
            _db.ApplicationType!.Update(applicationType);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        return View(applicationType);
    }
    
    // GET DELETE
    public IActionResult Delete(int? id)
    {
        if (id is null or 0)
            return NotFound();

        var applicationType = _db.ApplicationType!.Find(id);

        if (applicationType is null)
            return NotFound();
        
        return View(applicationType);
    }
    
    // POST DELETE
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(ApplicationType? applicationType)
    {
        if (applicationType is null)
        {
            return NotFound();
        }
        
        _db.ApplicationType!.Remove(applicationType);
        _db.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}