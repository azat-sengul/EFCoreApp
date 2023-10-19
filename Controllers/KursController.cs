using efcoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace efcoreApp.Controllers;

public class KursController : Controller
{
    private readonly DataContext _context;

    public KursController(DataContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var kurslar = await _context.Kurslar.ToListAsync();

        return View(kurslar);
    }


    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Kurs model)
    {
        _context.Kurslar.Add(model);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }


    public async Task<IActionResult> Edit(int? id)
    {
        if(id == null)
        {
            return NotFound();
        }

        var kurs = await _context.Kurslar.FindAsync(id);
        
        return View(kurs);
    }


    [HttpPost]
    public async Task<IActionResult> Edit(int id, Kurs model)
    {
        if(id != model.KursId)
        {
            return NotFound();
        }

         _context.Update(model);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");

    }

    public async Task<IActionResult> Delete(int? id)
    {
        if(id == null)
        {
            return NotFound();
        }

        var kurs = await _context.Kurslar.FindAsync(id);

        return View(kurs);

    }


    [HttpPost]
    public async Task<IActionResult> Delete(int id, Kurs model)
    {
        if(id != model.KursId)
        {
            return NotFound();
        }

        var kurs = await _context.Kurslar.FindAsync(id);
        _context.Kurslar.Remove(kurs);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }


}