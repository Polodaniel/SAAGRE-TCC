using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAGRE.Data;

namespace SAGRE.Controllers
{
    [Authorize]
    public class GraficoBoletinsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GraficoBoletinsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GraficoBoletins
        public ActionResult Index()
        {
            var DataAtual = DateTime.Now;

            List<ListaData> ListaDataBoletins = new List<ListaData>();
            List<ListaDataMetodologia> ListaDataMetodologia = new List<ListaDataMetodologia>();

            var Lista = _context.BoletimModel.Include("ListaAnalisePostura").Include("listanasa").Where(x => x.ID > 0).ToList();

            var ListaCkeckListBio = _context.CheckListAnaliseCondBio.ToList();
            var ListaCkeckListErg = _context.CheckListAnaliseCondErg.ToList();

            var ListaBoletimAgrupado = Lista.GroupBy(x => x.Data).ToList();

            ListaDataBoletins = MontaListaDataAtual(DataAtual);
            ListaDataMetodologia = MontaListaMetodologiaDataAtual(DataAtual);

            // Lista do Primeiro Card
            foreach (var itemListaDataBoletim in ListaDataBoletins)
            {
                foreach (var itemListaBoletim in ListaBoletimAgrupado)
                {
                    if (itemListaDataBoletim.Data == Convert.ToDateTime(itemListaBoletim.Key).ToShortDateString())
                    {
                        itemListaDataBoletim.Valor = itemListaBoletim.Count();
                    }
                }
            }

            // Lista do Segundo Card
            foreach (var itemListaDataMetodologia in ListaDataMetodologia)
            {
                foreach (var itemListaBoletim in ListaBoletimAgrupado)
                {
                    if (itemListaDataMetodologia.Data == Convert.ToDateTime(itemListaBoletim.Key).ToShortDateString())
                    {
                        foreach (var item in itemListaBoletim)
                        {
                            foreach (var i in item.ListaAnalisePostura)
                            {
                                if (!Equals(i.AcaoDescricao,"Não são necessarias medidas corretivas."))
                                {
                                    itemListaDataMetodologia.MetologiaPostura += 1;
                                } 
                            }
                            
                            //itemListaDataMetodologia.MetologiaPostura += item.ListaAnalisePostura.Count();

                            if (item.listanasa.ID > 0 && item.listanasa.Resultado != "Sem Análise !")
                                itemListaDataMetodologia.MetologiaCognitiva += 1;
                            else
                                itemListaDataMetodologia.MetologiaCognitiva += 0;
                        }
                    }
                }
            }

            foreach (var item in ListaDataBoletins)
            {
                item.Data = item.Data.Substring(0, 5);
            }

            ViewBag.TotalBoletim = Lista.Count();
            ViewBag.UltimoBoletim = Lista.Select(x => x.ID).LastOrDefault().ToString();
            ViewBag.TotalizadoBoletim = ListaDataBoletins.OrderBy(x => x.Data).ToList();

            int AnalisePosturaRisco = 0;
            int AnaliseCognitivaRisco = 0;
            int AnaliseCheckListBioRisco = 0;
            int AnaliseCheckListErgRisco = 0;

            foreach (var item in ListaDataMetodologia)
            {
                AnalisePosturaRisco += item.MetologiaPostura;
                AnaliseCognitivaRisco += item.MetologiaCognitiva;
                AnaliseCheckListBioRisco += item.MetologiaAmbienteBio;
                AnaliseCheckListErgRisco += item.MetologiaAmbienteErg;

            }

            foreach (var itemCheckList in ListaCkeckListBio)
                foreach (var itemListaBoletim in ListaBoletimAgrupado)
                    foreach (var item in itemListaBoletim)
                        if (item.ID == itemCheckList.ID_Boletim)
                            AnaliseCheckListBioRisco += 1;

            foreach (var itemCheckList in ListaCkeckListErg)
                foreach (var itemListaBoletim in ListaBoletimAgrupado)
                    foreach (var item in itemListaBoletim)
                        if (item.ID == itemCheckList.ID_Boletim)
                            AnaliseCheckListErgRisco += 1;


            //Monta as ViewBag com os Dados para o Grafico
            ViewBag.AnalisePosturaRisco = AnalisePosturaRisco;
            ViewBag.AnaliseCognitivaRisco = AnaliseCognitivaRisco;
            ViewBag.AnaliseCheckListBioRisco = AnaliseCheckListBioRisco;
            ViewBag.AnaliseCheckListErgRisco = AnaliseCheckListErgRisco;

            return View();
        }

        private List<ListaDataMetodologia> MontaListaMetodologiaDataAtual(DateTime dt)
        {
            List<ListaDataMetodologia> NovaListaData = new List<ListaDataMetodologia>();

            DateTime Segunda = DateTime.Now;
            DateTime Terca = DateTime.Now;
            DateTime Quarta = DateTime.Now;
            DateTime Quinta = DateTime.Now;
            DateTime Sexta = DateTime.Now;
            DateTime Sabado = DateTime.Now;
            DateTime Domingo = DateTime.Now;

            int Valor = 0;

            if (dt.DayOfWeek.ToString() == "Sunday")
            {
                Segunda = dt.AddDays(-6);
                Terca = dt.AddDays(-5);
                Quarta = dt.AddDays(-4);
                Quinta = dt.AddDays(-3);
                Sexta = dt.AddDays(-2);
                Sabado = dt.AddDays(-1);
                Domingo = dt;
            }
            else if (dt.DayOfWeek.ToString() == "Monday")
            {
                Segunda = dt;
                Terca = dt.AddDays(-6);
                Quarta = dt.AddDays(-5);
                Quinta = dt.AddDays(-4);
                Sexta = dt.AddDays(-3);
                Sabado = dt.AddDays(-2);
                Domingo = dt.AddDays(-1);
            }
            else if (dt.DayOfWeek.ToString() == "Tuesday")
            {
                Segunda = dt.AddDays(-1);
                Terca = dt;
                Quarta = dt.AddDays(-6);
                Quinta = dt.AddDays(-5);
                Sexta = dt.AddDays(-4);
                Sabado = dt.AddDays(-3);
                Domingo = dt.AddDays(-2);
            }
            else if (dt.DayOfWeek.ToString() == "Wednesday")
            {
                Segunda = dt.AddDays(-2);
                Terca = dt.AddDays(-1);
                Quarta = dt;
                Quinta = dt.AddDays(-6);
                Sexta = dt.AddDays(-5);
                Sabado = dt.AddDays(-4);
                Domingo = dt.AddDays(-3);
            }
            else if (dt.DayOfWeek.ToString() == "Thursday")
            {
                Segunda = dt.AddDays(-3);
                Terca = dt.AddDays(-2);
                Quarta = dt.AddDays(-1);
                Quinta = dt;
                Sexta = dt.AddDays(-6);
                Sabado = dt.AddDays(-5);
                Domingo = dt.AddDays(-4);
            }
            else if (dt.DayOfWeek.ToString() == "Friday")
            {
                Segunda = dt.AddDays(-4);
                Terca = dt.AddDays(-3);
                Quarta = dt.AddDays(-2);
                Quinta = dt.AddDays(-1);
                Sexta = dt;
                Sabado = dt.AddDays(-6);
                Domingo = dt.AddDays(-5);
            }
            else if (dt.DayOfWeek.ToString() == "Saturday")
            {
                Segunda = dt.AddDays(-5);
                Terca = dt.AddDays(-4);
                Quarta = dt.AddDays(-3);
                Quinta = dt.AddDays(-2);
                Sexta = dt.AddDays(-1);
                Sabado = dt;
                Domingo = dt.AddDays(-6);
            }

            NovaListaData.Add(new ListaDataMetodologia(Segunda.ToShortDateString(), 0, 0, 0, 0));
            NovaListaData.Add(new ListaDataMetodologia(Terca.ToShortDateString(), 0, 0, 0, 0));
            NovaListaData.Add(new ListaDataMetodologia(Quarta.ToShortDateString(), 0, 0, 0, 0));
            NovaListaData.Add(new ListaDataMetodologia(Quinta.ToShortDateString(), 0, 0, 0, 0));
            NovaListaData.Add(new ListaDataMetodologia(Sexta.ToShortDateString(), 0, 0, 0, 0));
            NovaListaData.Add(new ListaDataMetodologia(Sabado.ToShortDateString(), 0, 0, 0, 0));
            NovaListaData.Add(new ListaDataMetodologia(Domingo.ToShortDateString(), 0, 0, 0, 0));

            return NovaListaData;
        }

        private List<ListaData> MontaListaDataAtual(DateTime dt)
        {
            List<ListaData> NovaListaData = new List<ListaData>();

            DateTime Segunda = DateTime.Now;
            DateTime Terca = DateTime.Now;
            DateTime Quarta = DateTime.Now;
            DateTime Quinta = DateTime.Now;
            DateTime Sexta = DateTime.Now;
            DateTime Sabado = DateTime.Now;
            DateTime Domingo = DateTime.Now;

            int Valor = 0;

            if (dt.DayOfWeek.ToString() == "Sunday")
            {
                Segunda = dt.AddDays(-6);
                Terca = dt.AddDays(-5);
                Quarta = dt.AddDays(-4);
                Quinta = dt.AddDays(-3);
                Sexta = dt.AddDays(-2);
                Sabado = dt.AddDays(-1);
                Domingo = dt;
            }
            else if (dt.DayOfWeek.ToString() == "Monday")
            {
                Segunda = dt;
                Terca = dt.AddDays(-6);
                Quarta = dt.AddDays(-5);
                Quinta = dt.AddDays(-4);
                Sexta = dt.AddDays(-3);
                Sabado = dt.AddDays(-2);
                Domingo = dt.AddDays(-1);
            }
            else if (dt.DayOfWeek.ToString() == "Tuesday")
            {
                Segunda = dt.AddDays(-1);
                Terca = dt;
                Quarta = dt.AddDays(-6);
                Quinta = dt.AddDays(-5);
                Sexta = dt.AddDays(-4);
                Sabado = dt.AddDays(-3);
                Domingo = dt.AddDays(-2);
            }
            else if (dt.DayOfWeek.ToString() == "Wednesday")
            {
                Segunda = dt.AddDays(-2);
                Terca = dt.AddDays(-1);
                Quarta = dt;
                Quinta = dt.AddDays(-6);
                Sexta = dt.AddDays(-5);
                Sabado = dt.AddDays(-4);
                Domingo = dt.AddDays(-3);
            }
            else if (dt.DayOfWeek.ToString() == "Thursday")
            {
                Segunda = dt.AddDays(-3);
                Terca = dt.AddDays(-2);
                Quarta = dt.AddDays(-1);
                Quinta = dt;
                Sexta = dt.AddDays(-6);
                Sabado = dt.AddDays(-5);
                Domingo = dt.AddDays(-4);
            }
            else if (dt.DayOfWeek.ToString() == "Friday")
            {
                Segunda = dt.AddDays(-4);
                Terca = dt.AddDays(-3);
                Quarta = dt.AddDays(-2);
                Quinta = dt.AddDays(-1);
                Sexta = dt;
                Sabado = dt.AddDays(-6);
                Domingo = dt.AddDays(-5);
            }
            else if (dt.DayOfWeek.ToString() == "Saturday")
            {
                Segunda = dt.AddDays(-5);
                Terca = dt.AddDays(-4);
                Quarta = dt.AddDays(-3);
                Quinta = dt.AddDays(-2);
                Sexta = dt.AddDays(-1);
                Sabado = dt;
                Domingo = dt.AddDays(-6);
            }

            NovaListaData.Add(new ListaData(Segunda.ToShortDateString(), Valor));
            NovaListaData.Add(new ListaData(Terca.ToShortDateString(), Valor));
            NovaListaData.Add(new ListaData(Quarta.ToShortDateString(), Valor));
            NovaListaData.Add(new ListaData(Quinta.ToShortDateString(), Valor));
            NovaListaData.Add(new ListaData(Sexta.ToShortDateString(), Valor));
            NovaListaData.Add(new ListaData(Sabado.ToShortDateString(), Valor));
            NovaListaData.Add(new ListaData(Domingo.ToShortDateString(), Valor));

            return NovaListaData;
        }
    }

    public class ListaData
    {
        public ListaData(string data, int valor)
        {
            Data = data;
            Valor = valor;
        }

        public string Data { get; set; }
        public int Valor { get; set; }
    }

    public class ListaDataMetodologia
    {
        public ListaDataMetodologia(string data, int metologiaPostura, int metologiaCognitiva, int metologiaAmbienteBio, int metologiaAmbienteErg)
        {
            Data = data;
            MetologiaPostura = metologiaPostura;
            MetologiaCognitiva = metologiaCognitiva;
            MetologiaAmbienteBio = metologiaAmbienteBio;
            MetologiaAmbienteErg = metologiaAmbienteErg;
        }

        public string Data { get; set; }
        public int MetologiaPostura { get; set; }
        public int MetologiaCognitiva { get; set; }
        public int MetologiaAmbienteBio { get; set; }
        public int MetologiaAmbienteErg { get; set; }
    }
}