using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAutoPark.Data;
using WebAutoPark.Data.Entities;
using WebAutoPark.Helpers;
using WebAutoPark.Models.Company;
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
        VehicleCreateVM model = new VehicleCreateVM();
        model.Companies = _mapper.ProjectTo<SelectItemViewModel>(_context.Companies)
            .ToList();

        model.VehicleStatuses = _mapper.ProjectTo<SelectItemViewModel>(_context.VehicleStatuses)
            .ToList();

        return View(model);
    }

    [HttpPost] 
    public async Task<IActionResult> Create(VehicleCreateVM requestModel)
    {
        if (!ModelState.IsValid)
        {
            requestModel.Companies = _mapper.ProjectTo<SelectItemViewModel>(_context.Companies)
                .ToList();

            requestModel.VehicleStatuses = _mapper.ProjectTo<SelectItemViewModel>(_context.VehicleStatuses)
                .ToList();

            return View(requestModel);
        }
        var entity = _mapper.Map<VehicleEntity>(requestModel);
        await _context.Vehicles.AddAsync(entity);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));

    }

    [HttpGet] //Тепер він працює методом GET - це щоб побачити форму
    public async Task<IActionResult> Edit(int id)
    {
        var entity = await _context.Vehicles.FindAsync(id);
        if (entity == null)
        {
            return NotFound();
        }

        var model = _mapper.Map<VehicleEditVM>(entity);

        model.Companies = _mapper.ProjectTo<SelectItemViewModel>(_context.Companies)
            .ToList();

        model.VehicleStatuses = _mapper.ProjectTo<SelectItemViewModel>(_context.VehicleStatuses)
            .ToList();

        return View(model);
    }

    [HttpPost] //Тепер він працює методом GET - це щоб побачити форму
    public async Task<IActionResult> Edit(VehicleEditVM requestModel)
    {
        if (!ModelState.IsValid)
        {
            requestModel.Companies = _mapper.ProjectTo<SelectItemViewModel>(_context.Companies)
                .ToList();

            requestModel.VehicleStatuses = _mapper.ProjectTo<SelectItemViewModel>(_context.VehicleStatuses)
                .ToList();
            return View(requestModel);
        }

        var existing = await _context.Vehicles.FirstOrDefaultAsync(x => x.Id == requestModel.Id);
        if (existing == null)
        {
            return NotFound();
        }


        existing = _mapper.Map(requestModel, existing);

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
