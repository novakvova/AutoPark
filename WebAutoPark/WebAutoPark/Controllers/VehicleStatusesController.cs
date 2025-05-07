using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAutoPark.Data;
using WebAutoPark.Data.Entities;

namespace WebAutoPark.Controllers;

public class VehicleStatusesController : Controller
{
    private readonly AppAutoParkContext _context;

    public VehicleStatusesController(AppAutoParkContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var list = _context.VehicleStatuses
            .ToList(); 
        return View(list);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost] 
    public async Task<IActionResult> Create(VehicleStatusEntity model)
    {
        await _context.AddAsync(model);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var item = await _context.VehicleStatuses.SingleOrDefaultAsync(x => x.Id == id);
        if (item != null)
        {
            _context.VehicleStatuses.Remove(item);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }

}
