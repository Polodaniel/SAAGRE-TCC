using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SAGRE.Data;
using SAGRE.Models.AnaliseAmbiente;

namespace SAGRE.Controllers.AnaliseAmbiente
{
    public class TmpCheckListController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TmpCheckListController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TmpCheckList
        public async Task<IActionResult> Index()
        {
            return View(await _context.TmpCheckList.ToListAsync());
        }

        public async Task<IActionResult> Questionario1()
        {
            return View();
        }

        // GET: TmpCheckList/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tmpCheckList = await _context.TmpCheckList
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tmpCheckList == null)
            {
                return NotFound();
            }

            return View(tmpCheckList);
        }

        // GET: TmpCheckList/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TmpCheckList/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TipoCheckList,ID_Boletim,Questao01,Questao02,Questao03,Questao04,Questao05,Questao06,Questao07,Questao08,Questao09,Questao10,Questao11,Questao12,Questao13,Questao14,Questao15,Questao16,Questao17,Questao18,Questao19,Questao20")] TmpCheckList tmpCheckList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tmpCheckList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tmpCheckList);
        }

        // GET: TmpCheckList/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tmpCheckList = await _context.TmpCheckList.FindAsync(id);
            if (tmpCheckList == null)
            {
                return NotFound();
            }
            return View(tmpCheckList);
        }

        // POST: TmpCheckList/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TipoCheckList,ID_Boletim,Questao01,Questao02,Questao03,Questao04,Questao05,Questao06,Questao07,Questao08,Questao09,Questao10,Questao11,Questao12,Questao13,Questao14,Questao15,Questao16,Questao17,Questao18,Questao19,Questao20")] TmpCheckList tmpCheckList)
        {
            if (id != tmpCheckList.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tmpCheckList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TmpCheckListExists(tmpCheckList.ID))
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
            return View(tmpCheckList);
        }

        // GET: TmpCheckList/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tmpCheckList = await _context.TmpCheckList
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tmpCheckList == null)
            {
                return NotFound();
            }

            return View(tmpCheckList);
        }

        // POST: TmpCheckList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tmpCheckList = await _context.TmpCheckList.FindAsync(id);
            _context.TmpCheckList.Remove(tmpCheckList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TmpCheckListExists(int id)
        {
            return _context.TmpCheckList.Any(e => e.ID == id);
        }
    }
}
