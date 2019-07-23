using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SAGRE.Data;
using SAGRE.Models;

namespace SAGRE.Controllers
{
    [Authorize]
    public class GruposRiscoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GruposRiscoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GruposRisco
        public async Task<IActionResult> Index()
        {
            return View(await _context.GruposRiscoModel.ToListAsync());
        }

        // GET: GruposRisco/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gruposRiscoModel = await _context.GruposRiscoModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (gruposRiscoModel == null)
            {
                return NotFound();
            }

            return View(gruposRiscoModel);
        }

        // GET: GruposRisco/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GruposRisco/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nome,Descricao,Inativo")] GruposRiscoModel gruposRiscoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gruposRiscoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gruposRiscoModel);
        }

        // GET: GruposRisco/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gruposRiscoModel = await _context.GruposRiscoModel.FindAsync(id);
            if (gruposRiscoModel == null)
            {
                return NotFound();
            }
            return View(gruposRiscoModel);
        }

        // POST: GruposRisco/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nome,Descricao,Inativo")] GruposRiscoModel gruposRiscoModel)
        {
            if (id != gruposRiscoModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gruposRiscoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GruposRiscoModelExists(gruposRiscoModel.ID))
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
            return View(gruposRiscoModel);
        }

        // GET: GruposRisco/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gruposRiscoModel = await _context.GruposRiscoModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (gruposRiscoModel == null)
            {
                return NotFound();
            }

            return View(gruposRiscoModel);
        }

        // POST: GruposRisco/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gruposRiscoModel = await _context.GruposRiscoModel.FindAsync(id);
            _context.GruposRiscoModel.Remove(gruposRiscoModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GruposRiscoModelExists(int id)
        {
            return _context.GruposRiscoModel.Any(e => e.ID == id);
        }
    }
}
