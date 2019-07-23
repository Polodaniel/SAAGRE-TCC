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
    public class LocalController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LocalController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Local
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.LocalModel.Include(l => l.Setor);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Local/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localModel = await _context.LocalModel
                .Include(l => l.Setor)
                .FirstOrDefaultAsync(m => m.ID_Local == id);
            if (localModel == null)
            {
                return NotFound();
            }

            return View(localModel);
        }

        // GET: Local/Create
        public IActionResult Create()
        {
            ViewData["ID"] = new SelectList(_context.SetorModel, "ID", "Nome");
            return View();
        }

        // POST: Local/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_Local,ID,Sigla,Nome,Descricao,Inativo")] LocalModel localModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(localModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ID"] = new SelectList(_context.SetorModel, "ID", "Nome", localModel.ID);
            return View(localModel);
        }

        // GET: Local/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localModel = await _context.LocalModel.FindAsync(id);
            if (localModel == null)
            {
                return NotFound();
            }
            ViewData["ID"] = new SelectList(_context.SetorModel, "ID", "Nome", localModel.ID_Local);
            return View(localModel);
        }

        // POST: Local/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Local,ID,Sigla,Nome,Descricao,Inativo")] LocalModel localModel)
        {
            if (id != localModel.ID_Local)
            {
                //return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(localModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocalModelExists(localModel.ID_Local))
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
            ViewData["ID"] = new SelectList(_context.SetorModel, "ID", "Nome", localModel.ID_Local);
            return View(localModel);
        }

        // GET: Local/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localModel = await _context.LocalModel
                .Include(l => l.Setor)
                .FirstOrDefaultAsync(m => m.ID_Local == id);
            if (localModel == null)
            {
                return NotFound();
            }

            return View(localModel);
        }

        // POST: Local/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var localModel = await _context.LocalModel.FindAsync(id);
            _context.LocalModel.Remove(localModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocalModelExists(int id)
        {
            return _context.LocalModel.Any(e => e.ID_Local == id);
        }
    }
}
