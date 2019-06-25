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
    public class AtividadesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AtividadesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Atividades
        public async Task<IActionResult> Index()
        {
            return View(await _context.AtividadesModel.ToListAsync());
        }

        // GET: Atividades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atividadesModel = await _context.AtividadesModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (atividadesModel == null)
            {
                return NotFound();
            }

            return View(atividadesModel);
        }

        // GET: Atividades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Atividades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,NomeAtividade,DescricaoAtividade,Inativo")] AtividadesModel atividadesModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(atividadesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(atividadesModel);
        }

        // GET: Atividades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atividadesModel = await _context.AtividadesModel.FindAsync(id);
            if (atividadesModel == null)
            {
                return NotFound();
            }
            return View(atividadesModel);
        }

        // POST: Atividades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,NomeAtividade,DescricaoAtividade,Inativo")] AtividadesModel atividadesModel)
        {
            if (id != atividadesModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(atividadesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtividadesModelExists(atividadesModel.ID))
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
            return View(atividadesModel);
        }

        // GET: Atividades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atividadesModel = await _context.AtividadesModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (atividadesModel == null)
            {
                return NotFound();
            }

            return View(atividadesModel);
        }

        // POST: Atividades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var atividadesModel = await _context.AtividadesModel.FindAsync(id);
            _context.AtividadesModel.Remove(atividadesModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AtividadesModelExists(int id)
        {
            return _context.AtividadesModel.Any(e => e.ID == id);
        }
    }
}
