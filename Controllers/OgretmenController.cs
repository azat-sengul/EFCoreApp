using efcoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace efcoreApp.Controllers
{
    public class OgretmenController : Controller
    {

        private readonly DataContext _context;

        public OgretmenController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var ogretmen = await _context.Ogretmenler.ToListAsync();

            return View(ogretmen);

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Ogretmen model)
        {
            _context.Ogretmenler.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult>  Edit(int? id)
        {

            if(id == null)
            {
                return NotFound();
            }

            var ogretmen = await _context.Ogretmenler.FindAsync(id);

            return View(ogretmen);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, Ogretmen model)
        {

            if(id != model.OgretmenId)
            {
                return NotFound();
            }

            _context.Ogretmenler.Update(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
            

        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ogretmen = await _context.Ogretmenler.FindAsync(id);

            return View(ogretmen);

        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, Ogretmen model)
        {
            if (id != model.OgretmenId)
            {
                return NotFound();
            }

            var ogretmen = await _context.Ogretmenler.FindAsync(id);

            _context.Ogretmenler.Remove(ogretmen);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
       

        }




    }
}