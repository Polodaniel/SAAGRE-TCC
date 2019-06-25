using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SAGRE.Data;
using SAGRE.Models.MetodosAnalise;

namespace SAGRE.Controllers
{
    public class ClassificaoOWASController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClassificaoOWASController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ClassificaoOWAS
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClassificaoOWAS.ToListAsync());
        }

        // GET: ClassificaoOWAS/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classificaoOWAS = await _context.ClassificaoOWAS
                .FirstOrDefaultAsync(m => m.ID == id);
            if (classificaoOWAS == null)
            {
                return NotFound();
            }

            return View(classificaoOWAS);
        }

        // GET: ClassificaoOWAS/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClassificaoOWAS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,NumCosta,NumBraco,NumPernas,NumForca")] ClassificaoOWAS classificaoOWAS)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classificaoOWAS);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(classificaoOWAS);
        }

        // GET: ClassificaoOWAS/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classificaoOWAS = await _context.ClassificaoOWAS.FindAsync(id);
            if (classificaoOWAS == null)
            {
                return NotFound();
            }
            return View(classificaoOWAS);
        }

        // POST: ClassificaoOWAS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,NumCosta,NumBraco,NumPernas,NumForca")] ClassificaoOWAS classificaoOWAS)
        {
            if (id != classificaoOWAS.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classificaoOWAS);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassificaoOWASExists(classificaoOWAS.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(classificaoOWAS);
        }

        // GET: ClassificaoOWAS/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classificaoOWAS = await _context.ClassificaoOWAS
                .FirstOrDefaultAsync(m => m.ID == id);
            if (classificaoOWAS == null)
            {
                return NotFound();
            }

            return View(classificaoOWAS);
        }

        // POST: ClassificaoOWAS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classificaoOWAS = await _context.ClassificaoOWAS.FindAsync(id);
            _context.ClassificaoOWAS.Remove(classificaoOWAS);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassificaoOWASExists(int id)
        {
            return _context.ClassificaoOWAS.Any(e => e.ID == id);
        }
    }
}
