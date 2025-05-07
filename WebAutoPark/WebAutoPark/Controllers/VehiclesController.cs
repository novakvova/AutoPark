using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAutoPark.Data;
using WebAutoPark.Data.Entities;
using WebAutoPark.Models.Vehicle;
using WebAutoPark.Models.VehicleStatus;

namespace WebAutoPark.Controllers;

public class VehiclesController : Controller
{
    private readonly AppAutoParkContext _context;
    private readonly IMapper _mapper;

    public VehiclesController(AppAutoParkContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IActionResult Index()
    {
        var model = _mapper.ProjectTo<VehicleItemVM>(_context.Vehicles).ToList();
        return View(model);
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
