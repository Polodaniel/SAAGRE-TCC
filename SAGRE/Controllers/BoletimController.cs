using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SAGRE.Data;
using SAGRE.Models;
using SAGRE.Models.MetodosAnalise;

namespace SAGRE.Controllers
{
    public class BoletimController : Controller
    {
        private readonly ApplicationDbContext _context;
        private List<ClassificaoOWAS> ListaAnalises = new List<ClassificaoOWAS>();
        private List<AnalisePosturaModel> ListaRecebida = new List<AnalisePosturaModel>();



        public BoletimController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Boletim
        public async Task<IActionResult> Index()
        {
            var ListaSetor = await _context.SetorModel.Where(x => x.Inativo != true).ToListAsync();
            var ListaAtividade = await _context.AtividadesModel.Where(x => x.Inativo != true).ToListAsync();

            var Boletins = await _context.BoletimModel.ToListAsync();

            foreach (var item in Boletins)
            {
                var NomeSetor = ListaSetor.Where(x => x.ID == (Convert.ToInt32(item.Setor))).FirstOrDefault();
                var NomeAtividade = ListaAtividade.Where(x => x.ID == (Convert.ToInt32(item.Atividade))).FirstOrDefault();

                item.Setor = NomeSetor.Nome;
                item.Atividade = NomeAtividade.NomeAtividade;
            }

            Boletins = Boletins.OrderByDescending(x => x.ID).ToList();

            return View(Boletins);
        }

        // GET: Boletim/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boletimModel = await _context.BoletimModel.Include("ListaAnalisePostura").Include("listanasa")
                .FirstOrDefaultAsync(m => m.ID == id);

            if (boletimModel == null)
            {
                return NotFound();
            }

            var Setor = _context.SetorModel.Where(x => x.ID == (Convert.ToInt32(boletimModel.Setor))).Select(x => x.Nome).FirstOrDefault();
            var Atividade = _context.AtividadesModel.Where(x => x.ID == (Convert.ToInt32(boletimModel.Atividade))).Select(x => x.NomeAtividade).FirstOrDefault();

            boletimModel.Setor = Setor;
            boletimModel.Atividade = Atividade;

            var ValorMental = Convert.ToInt32(boletimModel.listanasa.escalaMental) * Convert.ToInt32(boletimModel.listanasa.rangeDM);
            var ValorFisico = Convert.ToInt32(boletimModel.listanasa.escalaFisica) * Convert.ToInt32(boletimModel.listanasa.rangeDF);
            var ValorTemporal = Convert.ToInt32(boletimModel.listanasa.escalaTemporal) * Convert.ToInt32(boletimModel.listanasa.rangeDT);
            var ValorPerformace = Convert.ToInt32(boletimModel.listanasa.escalaPerformace) * Convert.ToInt32(boletimModel.listanasa.rangePE);
            var ValorEsforco = Convert.ToInt32(boletimModel.listanasa.escalaEsforco) * Convert.ToInt32(boletimModel.listanasa.rangeDE);
            var ValorFrustracao = Convert.ToInt32(boletimModel.listanasa.escalaFrustacao) * Convert.ToInt32(boletimModel.listanasa.rangeFR);
            var ValorTotal = (ValorMental + ValorFisico + ValorTemporal + ValorPerformace + ValorEsforco + ValorFrustracao) / 15 ;

            ViewBag.ValorMental = ValorMental;
            ViewBag.ValorFisico = ValorFisico;
            ViewBag.ValorTemporal = ValorTemporal;
            ViewBag.ValorPerformace = ValorPerformace;
            ViewBag.ValorEsforco = ValorEsforco;
            ViewBag.ValorFrustracao = ValorFrustracao;
            ViewBag.ValorTotal = ValorTotal;

            return View(boletimModel);
        }

        // GET: Boletim/Create
        public IActionResult Create()
        {
            var Setor = _context.SetorModel.Where(x => x.Inativo != true).ToList();
            var Atividade = _context.AtividadesModel.Where(x => x.Inativo != true).ToList();

            List<SelectListItem> itemsSetor = new List<SelectListItem>();

            //Setor
            foreach (var setor in Setor)
                itemsSetor.Add(new SelectListItem { Text = setor.Nome, Value = setor.ID.ToString() });

            ViewBag.Setor = itemsSetor;

            List<SelectListItem> itemsAtividade = new List<SelectListItem>();

            //Atividade
            foreach (var atividade in Atividade)
                itemsAtividade.Add(new SelectListItem { Text = atividade.NomeAtividade, Value = atividade.ID.ToString() });

            ViewBag.Atividade = itemsAtividade;

            //@ViewBag.Atividade

            return View();
        }

        // POST: Boletim/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ID,NomeFiscal,Data,Setor,Descricao,Status,Flag")] BoletimModel boletimModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(boletimModel);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(boletimModel);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ID,NomeFiscal,Data,Setor,Descricao,Status,Flag,ListaAnalisePostura")] BoletimModel boletimModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(boletimModel);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(boletimModel);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody] BoletimModel boletimModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(boletimModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(boletimModel);
        }

        // GET: Boletim/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var boletimModel = await _context.BoletimModel.FindAsync(id);
            var boletimModel = await _context.BoletimModel.Include("ListaAnalisePostura").Include("listanasa")
                .FirstOrDefaultAsync(m => m.ID == id);

            if (boletimModel == null)
            {
                return NotFound();
            }

            var SetorLista = _context.SetorModel.Where(x => x.Inativo != true).ToList();
            var AtividadeLista = _context.AtividadesModel.Where(x => x.Inativo != true).ToList();

            List<SelectListItem> itemsSetor = new List<SelectListItem>();

            //Setor
            foreach (var setor in SetorLista)
                itemsSetor.Add(new SelectListItem { Text = setor.Nome, Value = setor.ID.ToString() });

            ViewBag.Setor = itemsSetor;

            List<SelectListItem> itemsAtividade = new List<SelectListItem>();

            //Atividade
            foreach (var atividade in AtividadeLista)
                itemsAtividade.Add(new SelectListItem { Text = atividade.NomeAtividade, Value = atividade.ID.ToString() });

            ViewBag.Atividade = itemsAtividade;

            var Setor = _context.SetorModel.Where(x => x.ID == (Convert.ToInt32(boletimModel.Setor))).Select(x => x.Nome).FirstOrDefault();
            var Atividade = _context.AtividadesModel.Where(x => x.ID == (Convert.ToInt32(boletimModel.Atividade))).Select(x => x.NomeAtividade).FirstOrDefault();

            boletimModel.Setor = Setor;
            boletimModel.Atividade = Atividade;

            var ValorMental = Convert.ToInt32(boletimModel.listanasa.escalaMental) * Convert.ToInt32(boletimModel.listanasa.rangeDM);
            var ValorFisico = Convert.ToInt32(boletimModel.listanasa.escalaFisica) * Convert.ToInt32(boletimModel.listanasa.rangeDF);
            var ValorTemporal = Convert.ToInt32(boletimModel.listanasa.escalaTemporal) * Convert.ToInt32(boletimModel.listanasa.rangeDT);
            var ValorPerformace = Convert.ToInt32(boletimModel.listanasa.escalaPerformace) * Convert.ToInt32(boletimModel.listanasa.rangePE);
            var ValorEsforco = Convert.ToInt32(boletimModel.listanasa.escalaEsforco) * Convert.ToInt32(boletimModel.listanasa.rangeDE);
            var ValorFrustracao = Convert.ToInt32(boletimModel.listanasa.escalaFrustacao) * Convert.ToInt32(boletimModel.listanasa.rangeFR);
            var ValorTotal = (ValorMental + ValorFisico + ValorTemporal + ValorPerformace + ValorEsforco + ValorFrustracao) / 15;

            ViewBag.ValorMental = ValorMental;
            ViewBag.ValorFisico = ValorFisico;
            ViewBag.ValorTemporal = ValorTemporal;
            ViewBag.ValorPerformace = ValorPerformace;
            ViewBag.ValorEsforco = ValorEsforco;
            ViewBag.ValorFrustracao = ValorFrustracao;
            ViewBag.ValorTotal = ValorTotal;

            return View(boletimModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,NomeFiscal,Data,Setor,Descricao,Status,Flag")] BoletimModel boletimModel)
        {
            if (id != boletimModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(boletimModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoletimModelExists(boletimModel.ID))
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
            return View(boletimModel);
        }

        // GET: Boletim/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boletimModel = await _context.BoletimModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (boletimModel == null)
            {
                return NotFound();
            }

            return View(boletimModel);
        }

        // POST: Boletim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var boletimModel = await _context.BoletimModel.FindAsync(id);
            _context.BoletimModel.Remove(boletimModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoletimModelExists(int id)
        {
            return _context.BoletimModel.Any(e => e.ID == id);
        }

        [HttpGet]
        public IActionResult BuscaTipoAnalise(string IndiceCosta, string IndicePerna, string IndiceEsforco, string IndiceBraco)
        {

            string Analise = String.Empty;

            ListaAnalises = _context.ClassificaoOWAS.Select(x => x).ToList();

            int Costa = Convert.ToInt32(IndiceCosta);
            int Perna = Convert.ToInt32(IndicePerna);
            int Braco = Convert.ToInt32(IndiceEsforco);
            int Esforco = Convert.ToInt32(IndiceBraco);

            var Item = ListaAnalises
                                .Where(x => x.NumCosta == Costa && x.NumPernas == Perna && x.NumBraco == Braco && x.NumForca == Esforco)
                                .Select(x => x.Categoria).FirstOrDefault();

            return Json(Item);
        }

        [HttpPost]
        public IActionResult GravarAnalise(Boletim analisepostura)
        {
            BoletimModel Boletim = new BoletimModel();
            List<AnalisePosturaModel> ListaPostura = new List<AnalisePosturaModel>();

            if (Equals(analisepostura.descricao, null))
                analisepostura.descricao = "Sem descrição Adicionada !";

            Boletim.NomeFiscal = analisepostura.nomefiscal;

            Boletim.Setor = analisepostura.setor;

            Boletim.Atividade = analisepostura.atividade;

            Boletim.Data = Convert.ToDateTime(analisepostura.dataanalise);

            Boletim.Descricao = analisepostura.descricao;

            // Teste
            Boletim.listanasa = analisepostura.listanasa;
            Boletim.ListaAnalisePostura = analisepostura.lista;

            _context.BoletimModel.Add(Boletim);

            _context.SaveChanges();

            //foreach (var item in analisepostura.lista)
            //{
            //    item.ID = Boletim.ID;
            //    ListaPostura.Add(item);
            //}

            //Boletim.listanasa = analisepostura.listanasa;

            //_context.AnalisePosturaModel.AddRange(ListaPostura);

            //_context.SaveChanges();

            return Json(Boletim.ID);
        }

        [HttpGet]
        public IActionResult MontaTabelaNASATLX(AnaliseNASATLXModel Dados)
        {
            int ValorMental = (Convert.ToInt32(Dados.escalaMental)) * (Convert.ToInt32(Dados.rangeDM));
            int ValorFisico = (Convert.ToInt32(Dados.escalaFisica)) * (Convert.ToInt32(Dados.rangeDF));
            int ValorTemporal = (Convert.ToInt32(Dados.escalaTemporal)) * (Convert.ToInt32(Dados.rangeDE));
            int ValorPerformace = (Convert.ToInt32(Dados.escalaPerformace)) * (Convert.ToInt32(Dados.rangePE));
            int ValorEsforco = (Convert.ToInt32(Dados.escalaEsforco)) * (Convert.ToInt32(Dados.rangeDE));
            int ValorFrustracao = (Convert.ToInt32(Dados.escalaFrustacao)) * (Convert.ToInt32(Dados.rangeFR));

            int Soma = ValorMental + ValorFisico + ValorTemporal + ValorPerformace + ValorEsforco + ValorFrustracao;

            var ValorTotal = Soma / 15;

            var TabelaString = ("<div id=\"TabelaNASATLX\">" +
                                    "<table class='table table-sm'>" +
                                        "<thead>" +
                                            "<tr>" +
                                                "<th scope='col' class=''>FATOR</th>" +
                                                "<th scope='col' class=''>PESO<p class='small mb-0'>(Comparação por pares)</p></th>" +
                                                "<th scope='col' class=''>VALOR<p class='small mb-0'>(Comparação por pares)</p></th>" +
                                                "<th scope='col' class=''>AJUSTE<p class='small mb-0'>(Peso X Valor)</p></th>" +
                                            "</tr>" +
                                        "</thead>" +
                                        "<tbody>" +
                                            "<tr>" +
                                                "<th scope='row'>Demanda Mental</th>" +
                                                "<td>" + Dados.escalaMental + "</td>" +
                                                "<td>" + Dados.rangeDM + "</td>" +
                                                "<td>" + ValorMental + "</td>" +
                                            "</tr>" +
                                            "<tr>" +
                                                "<th scope='row'>Demanda Física</th>" +
                                                "<td>" + Dados.escalaFisica + "</td>" +
                                                "<td>" + Dados.rangeDF + "</td>" +
                                                "<td>" + ValorFisico + "</td>" +
                                            "</tr>" +
                                            "<tr>" +
                                                "<th scope='row'>Demanda Temporal</th>" +
                                                "<td>" + Dados.escalaTemporal + "</td>" +
                                                "<td>" + Dados.rangeDT + "</td>" +
                                                "<td>" + ValorTemporal + "</td>" +
                                            "</tr>" +
                                            "<tr>" +
                                                "<th scope='row'>Performace</th>" +
                                                "<td>" + Dados.escalaPerformace + "</td>" +
                                                "<td>" + Dados.rangePE + "</td>" +
                                                "<td>" + ValorPerformace + "</td>" +
                                            "</tr>" +
                                            "<tr>" +
                                                "<th scope='row'>Esforço</th>" +
                                                "<td>" + Dados.escalaEsforco + "</td>" +
                                                "<td>" + Dados.rangeDE + "</td>" +
                                                "<td>" + ValorEsforco + "</td>" +
                                            "</tr>" +
                                            "<tr>" +
                                                "<th scope='row'>Frustração</th>" +
                                                "<td>" + Dados.escalaFrustacao + "</td>" +
                                                "<td>" + Dados.rangeFR + "</td>" +
                                                "<td>" + ValorFrustracao + "</td>" +
                                            "</tr>" +
                                                "<tr>" +
                                                "<th scope='row'  colspan='2'>PONTUAÇÃO<p class='small mb-0'>(Soma dos Ajuste dividido por 15)</p></th>" +
                                                "<td class='small'></td>" +
                                                "<th>" + ValorTotal + "</td>" +
                                            "</tr>" +
                                        "</tbody>" +
                                    "</table>" +
                                "</div>");

            return Json(TabelaString);
        }

    }

    public class Boletim
    {
        public Boletim()
        {
            lista = new List<AnalisePosturaModel>();
        }

        public string nomefiscal { get; set; }
        public string dataanalise { get; set; }
        public string setor { get; set; }
        public string atividade { get; set; }
        public string descricao { get; set; }
        public List<AnalisePosturaModel> lista { get; set; }
        public AnaliseNASATLXModel listanasa { get; set; }
    }

    public class AnaliseNASATLXa
    {
        public string rangeDM { get; set; }
        public string rangeDF { get; set; }
        public string rangeDT { get; set; }
        public string rangeDE { get; set; }
        public string rangePE { get; set; }
        public string rangeFR { get; set; }
        public string escalaFisica { get; set; }
        public string escalaTemporal { get; set; }
        public string escalaMental { get; set; }
        public string escalaPerformace { get; set; }
        public string escalaEsforco { get; set; }
        public string escalaFrustacao { get; set; }
    }

    public class TipoAnalise
    {
        public string NumCos { get; set; }
        public string NumPer { get; set; }
        public string NumEsf { get; set; }
        public string NumBra { get; set; }
    }
}
