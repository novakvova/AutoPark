using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAutoPark.Data;
using WebAutoPark.Data.Entities;
using WebAutoPark.Models;
using WebAutoPark.Models.Company;
using static System.Net.Mime.MediaTypeNames;

namespace WebAutoPark.Controllers;

public class HomeController : Controller
{
    private readonly AppAutoParkContext _context;
    private readonly IMapper _mapper;

    public HomeController(AppAutoParkContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IActionResult Index()
    {
        var model = _mapper.ProjectTo<CompanyItemVM>(_context.Companies).ToList();
        return View(model);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost] //çáåð³ãàº äàí³ â³ä êîðèñòóâà÷à
    public async Task<IActionResult> Create(CompanyCreateVM model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        var company = _mapper.Map<CompanyEntity>(model);
        await _context.Companies.AddAsync(company);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    [HttpGet] //Тепер він працює методом GET - це щоб побачити форму
    public async Task<IActionResult> Edit(int id)
    {
        var company = await _context.Companies.FindAsync(id);
        if (company == null)
        {
            return NotFound();
        }

        var model = _mapper.Map<CompanyEditVM>(company);
        return View(model);
    }

    [HttpPost] //Тепер він працює методом GET - це щоб побачити форму
    public async Task<IActionResult> Edit(CompanyEditVM model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var existing = await _context.Companies.FirstOrDefaultAsync(x => x.Id == model.Id);
        if (existing == null)
        {
            return NotFound();
        }

        var duplicate = await _context.Companies
            .FirstOrDefaultAsync(x => x.Name == model.Name && x.Id != model.Id);
        if (duplicate != null)
        {
            ModelState.AddModelError("Name", "Інша компанія з такою назвою вже існує");
            return View(model);
        }

        existing = _mapper.Map(model, existing);

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }


    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var item = await _context.Companies.SingleOrDefaultAsync(x => x.Id == id);
        if (item != null)
        {
            _context.Companies.Remove(item);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
