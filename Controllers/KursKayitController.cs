
using efcoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace efcoreApp.Controllers
{

    public class KursKayitController: Controller
    {

        private readonly DataContext _context;

        public KursKayitController(DataContext context)
        {

            _context = context;

        }

        public async Task<IActionResult> Index()
        {
            var kayit = await _context
            .KursKayitlari
            .Include(x => x.Ogrenci) //KursKayitlarini yükledikten sonra yanında Ogrenci tablosunuda yükle demek
            .Include(x => x.Kurs) //KursKayitlarini yükledikten sonra yanında Kurs tablosunuda yükle demek
            .ToListAsync();

            return View(kayit);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Ogrenciler =  new SelectList( await _context.Ogrenciler.ToListAsync(),"OgrenciId", "AdSoyad"); //AdSoyad modelde oluşturuldu
            ViewBag.Kurslar =  new SelectList( await _context.Kurslar.ToListAsync(),"KursId", "Baslik");
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(KursKayit model)
        {
            model.KayitTarihi = DateTime.Now; // Veri tabanına tarihi istenilen formatta kaydedebiliriz.
            _context.KursKayitlari.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


    }

}