using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAutoPark.Data;
using WebAutoPark.Data.Entities;
using WebAutoPark.Models.VehicleStatus;

namespace WebAutoPark.Controllers;

public class VehicleStatusesController : Controller
{
    private readonly AppAutoParkContext _context;
    private readonly IMapper _mapper;

    public VehicleStatusesController(AppAutoParkContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IActionResult Index()
    {
        var model = _mapper.ProjectTo<VehicleStatusItemVM>(_context.VehicleStatuses).ToList();
        return View(model);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost] 
    public async Task<IActionResult> Create(VehicleStatusCreateVM model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        var entity = _mapper.Map<VehicleStatusEntity>(model);
        await _context.VehicleStatuses.AddAsync(entity);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    [HttpGet] //Тепер він працює методом GET - це щоб побачити форму
    public async Task<IActionResult> Edit(int id)
    {
        var entity = await _context.VehicleStatuses.FindAsync(id);
        if (entity == null)
        {
            return NotFound();
        }

        var model = _mapper.Map<VehicleStatusEditVM>(entity);
        return View(model);
    }

    [HttpPost] //Тепер він працює методом GET - це щоб побачити форму
    public async Task<IActionResult> Edit(VehicleStatusEditVM model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var existing = await _context.VehicleStatuses.FirstOrDefaultAsync(x => x.Id == model.Id);
        if (existing == null)
        {
            return NotFound();
        }

        var duplicate = await _context.VehicleStatuses
            .FirstOrDefaultAsync(x => x.Name == model.Name && x.Id != model.Id);
        if (duplicate != null)
        {
            ModelState.AddModelError("Name", "Інший статус з такою назвою вже існує");
            return View(model);
        }

        existing = _mapper.Map(model, existing);

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
