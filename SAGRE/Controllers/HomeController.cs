using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SAGRE.Data;
using SAGRE.Models;

namespace SAGRE.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            var TotalBoletins = _context.BoletimModel.Count().ToString();
            var TotalSetor = _context.SetorModel.Count().ToString();
            var TotalLocal = _context.LocalModel.Count().ToString();
            var TotalAtividade = _context.AtividadesModel.Count().ToString();
            var TotalAvaliadores = _context.Users.Count().ToString();

            var UltimoBoletim = _context.BoletimModel.LastOrDefault();

            TotalBoletins = TotalBoletins.PadLeft(2, '0');
            TotalSetor = TotalSetor.PadLeft(2, '0');
            TotalLocal = TotalLocal.PadLeft(2, '0');
            TotalAtividade = TotalAtividade.PadLeft(2, '0');
            TotalAvaliadores = TotalAvaliadores.PadLeft(2, '0');

            ViewBag.TotalBoletins = TotalBoletins;
            ViewBag.TotalSetor = TotalSetor;
            ViewBag.TotalLocal = TotalLocal;
            ViewBag.TotalAtividade = TotalAtividade;
            ViewBag.TotalAvaliadores = TotalAvaliadores;
            ViewBag.UltimoBoletim = UltimoBoletim;
            ViewBag.Horario = MensagemBoasVinda();

            return View();
        }

        private string MensagemBoasVinda()
        {
            string Msg = string.Empty;
            var Hora = Convert.ToDateTime(DateTime.Now.ToShortTimeString());

            if (Convert.ToDateTime(Hora) >= Convert.ToDateTime("05:00") && Convert.ToDateTime(Hora) <= Convert.ToDateTime("11:59"))
                Msg = "Bom Dia";
            else if (Convert.ToDateTime(Hora) >= Convert.ToDateTime("12:00") && Convert.ToDateTime(Hora) <= Convert.ToDateTime("17:59"))
                Msg = "Boa Tarde";
            if (Convert.ToDateTime(Hora) >= Convert.ToDateTime("18:00") || Convert.ToDateTime(Hora) >= Convert.ToDateTime("00:00") && Convert.ToDateTime(Hora) <= Convert.ToDateTime("04:59"))
                Msg = "Boa Noite";

            return Msg;
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
