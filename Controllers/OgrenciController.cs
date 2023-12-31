using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using efcoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace efcoreApp.Controllers
{
    public class OgrenciController:Controller
    {
        private readonly DataContext _context;

        public OgrenciController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var ogrenciler = await _context.Ogrenciler.ToListAsync();
            return View(ogrenciler);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Ogrenci model)
        {
            _context.Ogrenciler.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ogr = await _context
            .Ogrenciler
            .Include(o => o.KursKayitlari) //Bu include satırı modelde oluşturalan ICollection list join etmesi için
            .ThenInclude(o => o.Kurs) // Bu include Kurskayit tablosundan  Kurs modeline de erişmesi için kullanılır. Farklı bir model geçildiği için then Include kullanılır
            .FirstOrDefaultAsync(o => o.OgrenciId == id); // FindAysnc include üzerinden çalışmaz. Bu yüzden firstordefault kullanıldı.

            return View(ogr);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Ogrenci model)
        {
            
            if(id != model.OgrenciId){

                return NotFound();

            }

            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }

                catch(Exception)
                {
                    if(!_context.Ogrenciler.Any(o => o.OgrenciId == model.OgrenciId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction("Index");
            }

            return View(model);  
           
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ogr = await _context.Ogrenciler.FindAsync(id);

            return View(ogr);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, Ogrenci model)
        {
            if(id != model.OgrenciId)
            {
                return NotFound();
            }

            var ogr = await _context.Ogrenciler.FindAsync(id);

            _context.Ogrenciler.Remove(ogr);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
            

        }
       
    
    }
    
}