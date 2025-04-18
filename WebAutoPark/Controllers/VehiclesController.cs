using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAutoPark.Data;
using WebAutoPark.Data.Entities;

namespace WebAutoPark.Controllers;

public class VehiclesController : Controller
{
    private readonly AppAutoParkContext _context;

    public VehiclesController(AppAutoParkContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var list = _context.Vehicles
            .Include(x => x.Company)
            .Include(x => x.Status)
            .ToList(); 
        return View(list);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost] 
    public async Task<IActionResult> Create(VehicleEntity model)
    {
        await _context.AddAsync(model);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var item = await _context.Vehicles.SingleOrDefaultAsync(x => x.Id == id);
        if (item != null)
        {
            _context.Vehicles.Remove(item);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }

}
