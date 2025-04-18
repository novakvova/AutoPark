using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAutoPark.Data;
using WebAutoPark.Data.Entities;
using WebAutoPark.Models;
using static System.Net.Mime.MediaTypeNames;

namespace WebAutoPark.Controllers;

public class HomeController : Controller
{
    private readonly AppAutoParkContext _context;

    public HomeController(AppAutoParkContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var list = _context.Companies
            .ToList(); 
        return View(list);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost] //çáåð³ãàº äàí³ â³ä êîðèñòóâà÷à
    public async Task<IActionResult> Create(CompanyEntity model)
    {
        await _context.AddAsync(model);
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
