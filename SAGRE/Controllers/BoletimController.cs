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
using SAGRE.Models.AnaliseAmbiente;
using SAGRE.Models.MetodosAnalise;

namespace SAGRE.Controllers
{
    [Authorize]
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
            var Local = _context.LocalModel.Where(x => x.ID_Local == (Convert.ToInt32(boletimModel.Local)) &&
                                                       x.ID == (Convert.ToInt32(boletimModel.Setor))
                                                 ).Select(x => x.Nome).FirstOrDefault();

            boletimModel.Setor = Setor;
            boletimModel.Atividade = Atividade;
            boletimModel.Local = Local;

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

            CheckListAnaliseCondBio CheckListBio = _context.CheckListAnaliseCondBio.Where(x => x.ID_Boletim == id).FirstOrDefault();
            CheckListAnaliseCondErg CheckListErg = _context.CheckListAnaliseCondErg.Where(x => x.ID_Boletim == id).FirstOrDefault();

            ViewBag.AnaliseLVE = "Não";

            if (!Equals(CheckListBio, null))
            {
                ViewBag.CheckListBio = CheckListBio;
                ViewBag.AnaliseLVE = "Sim";
            }
            else
                ViewBag.CheckListBio = null;

            if (!Equals(CheckListErg, null))
            {
                ViewBag.CheckListErg = CheckListErg;
                ViewBag.AnaliseLVE = "Sim";
            }
            else
                ViewBag.CheckListErg = null;

            ViewBag.ResultadoCheckListBio = ContaResultadoBio(CheckListBio);
            ViewBag.ResultadoCheckListErg = ContaResultadoErg(CheckListErg);

            return View(boletimModel);
        }

        private string ContaResultadoErg(CheckListAnaliseCondErg checkListErg)
        {
            int TotalErg = 0;

            if (!Equals(checkListErg, null))
            {
                if (checkListErg.Questao01 == "1") TotalErg++;
                if (checkListErg.Questao02 == "1") TotalErg++;
                if (checkListErg.Questao03 == "1") TotalErg++;
                if (checkListErg.Questao04 == "1") TotalErg++;
                if (checkListErg.Questao05 == "1") TotalErg++;
                if (checkListErg.Questao06 == "1") TotalErg++;
                if (checkListErg.Questao07 == "1") TotalErg++;
                if (checkListErg.Questao08 == "1") TotalErg++;
                if (checkListErg.Questao09 == "1") TotalErg++;
                if (checkListErg.Questao10 == "1") TotalErg++;
                if (checkListErg.Questao11 == "1") TotalErg++;
                if (checkListErg.Questao12 == "1") TotalErg++;
                if (checkListErg.Questao13 == "1") TotalErg++;
                if (checkListErg.Questao14 == "1") TotalErg++;
                if (checkListErg.Questao15 == "1") TotalErg++;
                if (checkListErg.Questao16 == "1") TotalErg++;
                if (checkListErg.Questao17 == "1") TotalErg++;
                if (checkListErg.Questao18 == "1") TotalErg++;
                if (checkListErg.Questao19 == "1") TotalErg++;
                if (checkListErg.Questao20 == "1") TotalErg++;
                if (checkListErg.Questao21 == "1") TotalErg++;
                if (checkListErg.Questao22 == "1") TotalErg++;
                if (checkListErg.Questao23 == "1") TotalErg++;
                if (checkListErg.Questao24 == "1") TotalErg++;
            }

            return ((TotalErg * 100) / 24).ToString();
        }

        private string ContaResultadoBio(CheckListAnaliseCondBio checkListBio)
        {
            int TotalBio = 0 ;

            if (!Equals(checkListBio,null))
            {
                if (checkListBio.Questao01 == "1") TotalBio++;
                if (checkListBio.Questao02 == "1") TotalBio++;
                if (checkListBio.Questao03 == "1") TotalBio++;
                if (checkListBio.Questao04 == "1") TotalBio++;
                if (checkListBio.Questao05 == "1") TotalBio++;
                if (checkListBio.Questao06 == "1") TotalBio++;
                if (checkListBio.Questao07 == "1") TotalBio++;
                if (checkListBio.Questao08 == "1") TotalBio++;
                if (checkListBio.Questao09 == "1") TotalBio++;
                if (checkListBio.Questao10 == "1") TotalBio++;
                if (checkListBio.Questao11 == "1") TotalBio++;
                if (checkListBio.Questao12 == "1") TotalBio++;
                if (checkListBio.Questao13 == "1") TotalBio++;
                if (checkListBio.Questao14 == "1") TotalBio++;

            }
            return TotalBio.ToString();
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

            List<SelectListItem> itemsLocal = new List<SelectListItem>();

            //Local
            var CodigoPrimeiro = itemsSetor.Select(x => x.Value).FirstOrDefault();

            var Local = _context.LocalModel.Where(x => x.Inativo != true && x.Setor.ID == (Convert.ToInt32(CodigoPrimeiro))).ToList();

            foreach (var local in Local)
                itemsLocal.Add(new SelectListItem { Text = local.Nome, Value = local.ID_Local.ToString() });

            ViewBag.Local = itemsLocal;

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

            if (Equals(analisepostura.local, null))
                analisepostura.local = " ";

            Boletim.NomeFiscal = analisepostura.nomefiscal;

            Boletim.Setor = analisepostura.setor;

            Boletim.Atividade = analisepostura.atividade;

            Boletim.Local = analisepostura.local;

            Boletim.HoraInicio = analisepostura.horainicio;

            Boletim.HoraTermino = analisepostura.horatermino;

            Boletim.TempoDuracao = analisepostura.tempogasto;

            Boletim.Data = Convert.ToDateTime(analisepostura.dataanalise);

            Boletim.Descricao = analisepostura.descricao;

            Boletim.listanasa = analisepostura.listanasa;

            Boletim.ListaAnalisePostura = analisepostura.lista;

            _context.BoletimModel.Add(Boletim);

            _context.SaveChanges();

            CheckListAnaliseCondBio CheckListAnaliseCondBio = new CheckListAnaliseCondBio();
            CheckListAnaliseCondErg CheckListAnaliseCondErg = new CheckListAnaliseCondErg();

            if (!Equals(analisepostura.checklistum, null))
            {
                var CheckList = _context.TmpCheckList.Where(x => x.ID == Convert.ToInt32(analisepostura.checklistum)).FirstOrDefault();

                CheckListAnaliseCondBio.ID_Boletim = Boletim.ID;
                CheckListAnaliseCondBio = MontaCheckListCondBio(CheckListAnaliseCondBio, CheckList);

                _context.TmpCheckList.Remove(CheckList);

            }

            if (!Equals(analisepostura.checklistdois, null))
            {
                var CheckList = _context.TmpCheckList.Where(x => x.ID == Convert.ToInt32(analisepostura.checklistdois)).FirstOrDefault();

                CheckListAnaliseCondErg.ID_Boletim = Boletim.ID;
                CheckListAnaliseCondErg = MontaCheckListCondErgo(CheckListAnaliseCondErg, CheckList);

                _context.TmpCheckList.Remove(CheckList);

            }

            _context.CheckListAnaliseCondBio.Add(CheckListAnaliseCondBio);
            _context.CheckListAnaliseCondErg.Add(CheckListAnaliseCondErg);

            _context.SaveChanges();

            return Json(Boletim.ID);
        }

        private CheckListAnaliseCondErg MontaCheckListCondErgo(CheckListAnaliseCondErg checkListAnaliseCondErg, TmpCheckList checkList)
        {
            checkListAnaliseCondErg.TipoCheckList = checkList.TipoCheckList;

            checkListAnaliseCondErg.Questao01 = checkList.Questao01;
            checkListAnaliseCondErg.Questao02 = checkList.Questao02;
            checkListAnaliseCondErg.Questao03 = checkList.Questao03;
            checkListAnaliseCondErg.Questao04 = checkList.Questao04;
            checkListAnaliseCondErg.Questao05 = checkList.Questao05;
            checkListAnaliseCondErg.Questao06 = checkList.Questao06;
            checkListAnaliseCondErg.Questao07 = checkList.Questao07;
            checkListAnaliseCondErg.Questao08 = checkList.Questao08;
            checkListAnaliseCondErg.Questao09 = checkList.Questao09;
            checkListAnaliseCondErg.Questao10 = checkList.Questao10;
            checkListAnaliseCondErg.Questao11 = checkList.Questao11;
            checkListAnaliseCondErg.Questao12 = checkList.Questao12;
            checkListAnaliseCondErg.Questao13 = checkList.Questao13;
            checkListAnaliseCondErg.Questao14 = checkList.Questao14;
            checkListAnaliseCondErg.Questao15 = checkList.Questao15;
            checkListAnaliseCondErg.Questao16 = checkList.Questao16;
            checkListAnaliseCondErg.Questao17 = checkList.Questao17;
            checkListAnaliseCondErg.Questao18 = checkList.Questao18;
            checkListAnaliseCondErg.Questao19 = checkList.Questao19;
            checkListAnaliseCondErg.Questao20 = checkList.Questao20;
            checkListAnaliseCondErg.Questao21 = checkList.Questao21;
            checkListAnaliseCondErg.Questao22 = checkList.Questao22;
            checkListAnaliseCondErg.Questao23 = checkList.Questao23;
            checkListAnaliseCondErg.Questao24 = checkList.Questao24;

            return checkListAnaliseCondErg;
        }

        private CheckListAnaliseCondBio MontaCheckListCondBio(CheckListAnaliseCondBio checkListAnaliseCondBio, TmpCheckList checkList)
        {
            checkListAnaliseCondBio.TipoCheckList = checkList.TipoCheckList;

            checkListAnaliseCondBio.Questao01 = checkList.Questao01;
            checkListAnaliseCondBio.Questao02 = checkList.Questao02;
            checkListAnaliseCondBio.Questao03 = checkList.Questao03;
            checkListAnaliseCondBio.Questao04 = checkList.Questao04;
            checkListAnaliseCondBio.Questao05 = checkList.Questao05;
            checkListAnaliseCondBio.Questao06 = checkList.Questao06;
            checkListAnaliseCondBio.Questao07 = checkList.Questao07;
            checkListAnaliseCondBio.Questao08 = checkList.Questao08;
            checkListAnaliseCondBio.Questao09 = checkList.Questao09;
            checkListAnaliseCondBio.Questao10 = checkList.Questao10;
            checkListAnaliseCondBio.Questao11 = checkList.Questao11;
            checkListAnaliseCondBio.Questao12 = checkList.Questao12;
            checkListAnaliseCondBio.Questao13 = checkList.Questao13;
            checkListAnaliseCondBio.Questao14 = checkList.Questao14;

            return checkListAnaliseCondBio;
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

        [HttpGet]
        public IActionResult ConsomeTempo(string HoraInicio, string HoraTermino)
        {
            var Inicio = Convert.ToDateTime(HoraInicio);
            var Termino = Convert.ToDateTime(HoraTermino);

            TimeSpan TempoGasto = Termino.Subtract(Inicio);

            var Tempo = TempoGasto.ToString("hh\\:mm");

            return Json(Tempo);
        }

        [HttpGet]
        public IActionResult BuscaLocal(int CodSetor)
        {
            var NomeSetor = string.Empty;

            var Setor = _context.SetorModel.Where(x => x.Inativo != true &&
                                                            x.ID == CodSetor).ToList();

            if (!Equals(Setor, null))
            {
                NomeSetor = Setor.Select(y => y.Nome).FirstOrDefault().ToString();
            }

            var ListaLocal = _context.LocalModel.Include("Setor").Where(x => x.Inativo != true &&
                                                            x.Setor.ID == CodSetor && x.Setor.Nome == NomeSetor)
                                                .ToList();

            return Json(ListaLocal);
        }

        [HttpPost]
        public IActionResult TmpCheckList(TmpCheckListClass Dados)
        {
            TmpCheckList CheckListTemporario = new TmpCheckList();

            CheckListTemporario.TipoCheckList = Dados.TipoCheckList;
            CheckListTemporario.Questao01 = Dados.Questao01;
            CheckListTemporario.Questao02 = Dados.Questao02;
            CheckListTemporario.Questao03 = Dados.Questao03;
            CheckListTemporario.Questao04 = Dados.Questao04;
            CheckListTemporario.Questao05 = Dados.Questao05;
            CheckListTemporario.Questao06 = Dados.Questao06;
            CheckListTemporario.Questao07 = Dados.Questao07;
            CheckListTemporario.Questao08 = Dados.Questao08;
            CheckListTemporario.Questao09 = Dados.Questao09;
            CheckListTemporario.Questao10 = Dados.Questao10;
            CheckListTemporario.Questao11 = Dados.Questao11;
            CheckListTemporario.Questao12 = Dados.Questao12;
            CheckListTemporario.Questao13 = Dados.Questao13;
            CheckListTemporario.Questao14 = Dados.Questao14;
            CheckListTemporario.Questao15 = Dados.Questao15;
            CheckListTemporario.Questao16 = Dados.Questao16;
            CheckListTemporario.Questao17 = Dados.Questao17;
            CheckListTemporario.Questao18 = Dados.Questao18;
            CheckListTemporario.Questao19 = Dados.Questao19;
            CheckListTemporario.Questao20 = Dados.Questao20;
            CheckListTemporario.Questao21 = Dados.Questao21;
            CheckListTemporario.Questao22 = Dados.Questao22;
            CheckListTemporario.Questao23 = Dados.Questao23;
            CheckListTemporario.Questao24 = Dados.Questao24;
            CheckListTemporario.Questao25 = Dados.Questao25;
            CheckListTemporario.Questao26 = Dados.Questao26;
            CheckListTemporario.Questao27 = Dados.Questao27;
            CheckListTemporario.Questao28 = Dados.Questao28;
            CheckListTemporario.Questao29 = Dados.Questao29;
            CheckListTemporario.Questao30 = Dados.Questao30;

            _context.TmpCheckList.Add(CheckListTemporario);

            _context.SaveChanges();

            return Json(CheckListTemporario.ID);
        }

        [HttpPost]
        public IActionResult TmpCheckListCorrigir(string idcheck)
        {
            var query = _context.TmpCheckList.Where(x => x.ID == Convert.ToInt32(idcheck)).FirstOrDefault();

            if (!Equals(query, null))
            {
                _context.TmpCheckList.Remove(query);
                _context.SaveChanges();

                return Json("OK");

            }

            return Json("Erro");
        }

    }

    public class TmpCheckListClass
    {
        public int TipoCheckList { get; set; }
        public int ID_Boletim { get; set; }
        public string Questao01 { get; set; }
        public string Questao02 { get; set; }
        public string Questao03 { get; set; }
        public string Questao04 { get; set; }
        public string Questao05 { get; set; }
        public string Questao06 { get; set; }
        public string Questao07 { get; set; }
        public string Questao08 { get; set; }
        public string Questao09 { get; set; }
        public string Questao10 { get; set; }
        public string Questao11 { get; set; }
        public string Questao12 { get; set; }
        public string Questao13 { get; set; }
        public string Questao14 { get; set; }
        public string Questao15 { get; set; }
        public string Questao16 { get; set; }
        public string Questao17 { get; set; }
        public string Questao18 { get; set; }
        public string Questao19 { get; set; }
        public string Questao20 { get; set; }
        public string Questao21 { get; set; }
        public string Questao22 { get; set; }
        public string Questao23 { get; set; }
        public string Questao24 { get; set; }
        public string Questao25 { get; set; }
        public string Questao26 { get; set; }
        public string Questao27 { get; set; }
        public string Questao28 { get; set; }
        public string Questao29 { get; set; }
        public string Questao30 { get; set; }

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
        public string local { get; set; }
        public string horainicio { get; set; }
        public string horatermino { get; set; }
        public string tempogasto { get; set; }
        public string checklistum { get; set; }
        public string checklistdois { get; set; }

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
