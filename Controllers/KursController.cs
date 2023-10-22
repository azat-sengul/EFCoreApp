using efcoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        var kurslar = await _context.Kurslar.Include(k => k.Ogretmen).ToListAsync();

        return View(kurslar);
    }


    public async Task<IActionResult> Create()
    {
        ViewBag.Ogretmenler = new SelectList( await _context.Ogretmenler.ToListAsync(),"OgretmenId", "AdSoyad");
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

        var kurs = await _context
        .Kurslar
        .Include(o => o.KursKayitlari)
        .ThenInclude(o => o.Ogrenci)
        .FirstOrDefaultAsync(o => o.KursId == id);

        ViewBag.Ogretmenler = new SelectList( await _context.Ogretmenler.ToListAsync(),"OgretmenId", "AdSoyad");
        
        return View(kurs);
    }


    [HttpPost]
    public async Task<IActionResult> Edit(int id, Kurs model)
    {
        if(id != model.KursId)
        {
            return NotFound();
        }



            //_context.Update(new Kurs() {KursId=model.KursId, Baslik=model.Baslik, OgretmenId=model.OgretmenId});
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