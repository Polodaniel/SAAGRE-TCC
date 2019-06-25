using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SAGRE.Data;
using SAGRE.Models;

namespace SAGRE.Controllers
{
    public class SetorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SetorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Setor
        public async Task<IActionResult> Index()
        {
            return View(await _context.SetorModel.ToListAsync());
        }

        // GET: Setor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var setorModel = await _context.SetorModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (setorModel == null)
            {
                return NotFound();
            }

            return View(setorModel);
        }

        // GET: Setor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Setor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Sigla,Nome,Descricao,Inativo")] SetorModel setorModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(setorModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(setorModel);
        }

        // GET: Setor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var setorModel = await _context.SetorModel.FindAsync(id);
            if (setorModel == null)
            {
                return NotFound();
            }
            return View(setorModel);
        }

        // POST: Setor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Sigla,Nome,Descricao,Inativo")] SetorModel setorModel)
        {
            if (id != setorModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(setorModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SetorModelExists(setorModel.ID))
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
            return View(setorModel);
        }

        // GET: Setor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var setorModel = await _context.SetorModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (setorModel == null)
            {
                return NotFound();
            }

            return View(setorModel);
        }

        // POST: Setor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var setorModel = await _context.SetorModel.FindAsync(id);
            _context.SetorModel.Remove(setorModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SetorModelExists(int id)
        {
            return _context.SetorModel.Any(e => e.ID == id);
        }
    }
}
