using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SAGRE.Data;
using SAGRE.Models;
using SAGRE.Models.AnaliseAmbiente;

namespace SAGRE.Controllers
{
    [Authorize]
    public class RelatorioSetorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RelatorioSetorController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var Setor = _context.SetorModel.Where(x => x.Inativo != true).ToList();
            var Atividade = _context.AtividadesModel.Where(x => x.Inativo != true).ToList();

            List<SelectListItem> itemsSetor = new List<SelectListItem>();
            itemsSetor.Add(new SelectListItem { Text = "", Value = "0" });

            //Setor
            foreach (var setor in Setor)
                itemsSetor.Add(new SelectListItem { Text = setor.Nome, Value = setor.ID.ToString() });

            ViewBag.Setor = itemsSetor;

            List<SelectListItem> itemsAtividade = new List<SelectListItem>();
            itemsAtividade.Add(new SelectListItem { Text = "", Value = "0" });

            //Atividade
            foreach (var atividade in Atividade)
                itemsAtividade.Add(new SelectListItem { Text = atividade.NomeAtividade, Value = atividade.ID.ToString() });

            ViewBag.Atividade = itemsAtividade;

            List<SelectListItem> itemsLocal = new List<SelectListItem>();
            itemsLocal.Add(new SelectListItem { Text = "", Value = "0" });

            //Local
            var CodigoPrimeiro = itemsSetor.Select(x => x.Value).FirstOrDefault();

            var Local = _context.LocalModel.Where(x => x.Inativo != true).ToList();

            foreach (var local in Local)
                itemsLocal.Add(new SelectListItem { Text = local.Nome, Value = local.ID_Local.ToString() });

            ViewBag.Local = itemsLocal;


            return View();
        }

        public IActionResult BuscarBoletins(Filtro filtros)
        {
            List<BoletimModel> Lista = new List<BoletimModel>();
            List<BoletimModel> ListaAux = new List<BoletimModel>();

            Lista = _context.BoletimModel.Include("ListaAnalisePostura").Include("listanasa").Where(x => x.ID > 0).ToList();

            if (Equals(filtros, null))
                return Json(Lista);

            if (!Equals(Lista, null) || !Equals(Lista.Count, 0))
                ListaAux = BuscaBoletinsFiltro(Lista, filtros);

            string HTML_Pesquisa = MontaHTMLPesquisa(ListaAux, filtros);

            return Json(HTML_Pesquisa);
            //return Json(ListaAux);
        }

        [HttpGet]
        public IActionResult BuscaLocal(int CodSetor)
        {
            var NomeSetor = string.Empty;

            if (CodSetor == 0)
            {
                var _listaLocal = _context.LocalModel.Include("Setor").Where(x => x.Inativo != true).ToList();

                return Json(_listaLocal);
            }

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

        private List<BoletimModel> BuscaBoletinsFiltro(List<BoletimModel> lista, Filtro filtros)
        {
            var ListaAux = lista;

            // Código
            if (!Equals(filtros.codigo, null))
                ListaAux = ListaAux.Where(x => x.ID == Convert.ToInt32(filtros.codigo)).ToList();

            // Data Inicial
            if (!Equals(filtros.datainicial, null) && Equals(filtros.datafinal, null))
                ListaAux = ListaAux.Where(x => x.Data >= Convert.ToDateTime(filtros.datainicial)).ToList();

            // Data Final
            if (Equals(filtros.datainicial, null) && !Equals(filtros.datafinal, null))
                ListaAux = ListaAux.Where(x => x.Data <= Convert.ToDateTime(filtros.datafinal)).ToList();

            // Duas Datas
            if (!Equals(filtros.datainicial, null) && !Equals(filtros.datafinal, null))
                ListaAux = ListaAux.Where(x => x.Data >= Convert.ToDateTime(filtros.datainicial) && x.Data <= Convert.ToDateTime(filtros.datafinal)).ToList();

            //Nome Avaliador
            if (!Equals(filtros.nomeavaliador, null))
                ListaAux = ListaAux.Where(x => x.NomeFiscal.ToString().ToUpper() == filtros.nomeavaliador.ToString().ToUpper()).ToList();

            // Setor
            if (!Equals(filtros.setor, "0"))
                ListaAux = ListaAux.Where(x => x.Setor == filtros.setor).ToList();

            // Local
            if (!Equals(filtros.local, "0"))
            {
                var Setor = _context.LocalModel.Where(x => x.ID_Local == Convert.ToInt32(filtros.local) && x.Nome == filtros.nomelocal).Select(x => x.Setor.ID).FirstOrDefault();

                ListaAux = ListaAux.Where(x => x.Setor == Setor.ToString() && x.Local == filtros.local).ToList();

                filtros.setor = Setor.ToString();
            }

            // Atividade
            if (!Equals(filtros.atividade, "0"))
                ListaAux = ListaAux.Where(x => x.Atividade == filtros.atividade).ToList();

            return ListaAux;
        }

        private string MontaHTMLPesquisa(List<BoletimModel> listaBoletim, Filtro filtros)
        {
            if (!Equals(listaBoletim.Count, 0))
            {
                #region Busca Setor/Atividade/Local
                var Setor = _context.SetorModel.Where(x => x.ID > 0).ToList();
                var Atividade = _context.AtividadesModel.Where(x => x.ID > 0).ToList();
                var Local = _context.LocalModel.Where(x => x.ID > 0).ToList();

                var CheckListAnaliseCondBio = _context.CheckListAnaliseCondBio.Where(x => x.ID > 0).ToList();
                var CheckListAnaliseCondErg = _context.CheckListAnaliseCondErg.Where(x => x.ID > 0).ToList();
                #endregion

                #region HTML para Editar

                StringBuilder sbTotalizador = new StringBuilder();
                sbTotalizador.AppendLine("<div class='border bg-white pb-3 pl-3 pr-3 mt-2 mb-2' data-toggle='collapse' href='##ID_Card_Collapse#' role='button' aria-expanded='false' aria-controls='##ID_Card_Collapse#'>");
                sbTotalizador.AppendLine("     <h5 class='mt-3'>Totalizadores</h5>                                                                                 ");
                sbTotalizador.AppendLine("     <hr class='mt-1 mb-2' />                                                                                            ");
                sbTotalizador.AppendLine("     <div class='row mb-1'>                                                                                              ");
                sbTotalizador.AppendLine("          <div class='col'>                                                                                              ");
                sbTotalizador.AppendLine("              <span class='small mb-0'><span class='small font-weight-bold'>Total de Boletins</span></span>              ");
                sbTotalizador.AppendLine("              <br class='mt-0'>#Qnt_Total_Boletim#</br>                                                                               ");
                sbTotalizador.AppendLine("          </div>                                                                                                         ");
                sbTotalizador.AppendLine("          <div class='col'>                                                                                              ");
                sbTotalizador.AppendLine("              <span class='small mb-0'><span class='small font-weight-bold'>Ultimo Boletim</span></span>                 ");
                sbTotalizador.AppendLine("              <br class='mt-0'>#ID_Ultimo_Boletim#</br>                                                                               ");
                sbTotalizador.AppendLine("          </div>                                                                                                         ");
                sbTotalizador.AppendLine("          <div class='col'>                                                                                              ");
                sbTotalizador.AppendLine("              <span class='small mb-0'><span class='small font-weight-bold'>Setor com Mais Apontamento</span></span>     ");
                sbTotalizador.AppendLine("              <br class='mt-0'>#Setor_Apontamento#</br>                                                                  ");
                sbTotalizador.AppendLine("          </div>                                                                                                         ");
                sbTotalizador.AppendLine("          <div class='col'>                                                                                              ");
                sbTotalizador.AppendLine("              <span class='small mb-0'><span class='small font-weight-bold'>Local com Mais Apontamento</span></span>     ");
                sbTotalizador.AppendLine("              <br class='mt-0'>#Local_Apontamento#</br>                                                                  ");
                sbTotalizador.AppendLine("          </div>                                                                                                         ");
                sbTotalizador.AppendLine("     </div>                                                                                                              ");
                sbTotalizador.AppendLine("     <div class='row mb-1'>                                                                                              ");
                sbTotalizador.AppendLine("          <div class='col'>                                                                                              ");
                sbTotalizador.AppendLine("              <span class='small mb-0'><span class='small font-weight-bold'>Análise de Postura</span></span>             ");
                sbTotalizador.AppendLine("              <br class='mt-0'>#Analise_Postura#</br>                                                                    ");
                sbTotalizador.AppendLine("          </div>                                                                                                         ");
                sbTotalizador.AppendLine("          <div class='col'>                                                                                              ");
                sbTotalizador.AppendLine("              <span class='small mb-0'><span class='small font-weight-bold'>Análise de Cognitiva </span></span>          ");
                sbTotalizador.AppendLine("              <br class='mt-0'>#Analise_Cognitiva#</br>                                                                  ");
                sbTotalizador.AppendLine("          </div>                                                                                                         ");
                sbTotalizador.AppendLine("          <div class='col'>                                                                                              ");
                sbTotalizador.AppendLine("              <span class='small mb-0'><span class='small font-weight-bold'>Check List Análise Ergonomia</span></span>   ");
                sbTotalizador.AppendLine("              <br class='mt-0'>#Check_Erg#</br>                                                                          ");
                sbTotalizador.AppendLine("          </div>                                                                                                         ");
                sbTotalizador.AppendLine("          <div class='col'>                                                                                              ");
                sbTotalizador.AppendLine("              <span class='small mb-0'><span class='small font-weight-bold'>Check List Análise Biomecânica </span></span>");
                sbTotalizador.AppendLine("              <br class='mt-0'>#Check_Bio#</br>                                                                          ");
                sbTotalizador.AppendLine("          </div>                                                                                                         ");
                sbTotalizador.AppendLine("     </div>                                                                                                              ");
                sbTotalizador.AppendLine("</div>                                                                                                                   ");

                var HtmlBaseTotalizador = sbTotalizador.ToString();
                HtmlBaseTotalizador = HtmlBaseTotalizador.Replace("\r\n", "").Replace("\r", "").Replace("\n", "").Replace("\"", "");

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<div class='border bg-white pb-3 pl-3 pr-3 mt-2 mb-2' data-toggle='collapse' href='##ID_Card_Collapse#' role='button' aria-expanded='false' aria-controls='##ID_Card_Collapse#'>");
                sb.AppendLine("     <h5 class='mt-3'>#Nome_Setor#</h5>                                                                        ");
                sb.AppendLine("     <div class='collapse mt-4' id='#ID_Card_Collapse#'>                                                       ");
                sb.AppendLine("         <div class='row'>                                                                                     ");
                sb.AppendLine("             <div class='col'>                                                                                 ");
                sb.AppendLine("                 <div class='table-responsive'>                                                                ");
                sb.AppendLine("                     <table class='table table-sm'>                                                            ");
                sb.AppendLine("                         <thead class='thead-dark small'>                                                      ");
                sb.AppendLine("                             <tr class='text-light bg-dark'>                                                   ");
                sb.AppendLine("                                 <td>N°</td>                                                                   ");
                sb.AppendLine("                                 <td>Data</td>                                                                 ");
                sb.AppendLine("                                 <td>Avaliador</td>                                                            ");
                sb.AppendLine("                                 <td>Local</td>                                                                ");
                sb.AppendLine("                                 <td>Atividade</td>                                                            ");
                sb.AppendLine("                             </tr>                                                                             ");
                sb.AppendLine("                         </thead>                                                                              ");
                sb.AppendLine("                         <tbody class='small'>                                                                 ");
                sb.AppendLine("                             #Dados_Boletins#                                                                  ");
                sb.AppendLine("                         </tbody>                                                                              ");
                sb.AppendLine("                     </table>                                                                                  ");
                sb.AppendLine("                 </div>                                                                                        ");
                sb.AppendLine("             </div>                                                                                            ");
                sb.AppendLine("         </div>                                                                                                ");
                sb.AppendLine("         <div class='row'>                                                                                     ");
                sb.AppendLine("             <div class='col-12'>                                                                              ");
                sb.AppendLine("                 <div class='table-responsive'>                                                                ");
                sb.AppendLine("                     <table class='table table-sm'>                                                            ");
                sb.AppendLine("                         <thead class='thead-dark small'>                                                      ");
                sb.AppendLine("                             <tr class='text-light bg-dark'>                                                   ");
                sb.AppendLine("                                 <td class='align-middle' rowspan='2'>N° Boletim</td>                          ");
                sb.AppendLine("                                 <td class='align-middle' rowspan='2'>Atividade Realizada</td>                 ");
                sb.AppendLine("                                 <td class='align-middle' rowspan='2' class='text-center'>Análise Postura</td> ");
                sb.AppendLine("                                 <td class='align-middle' rowspan='2'>Análise Cognitiva</td>                   ");
                sb.AppendLine("                                 <td class='align-middle text-center' colspan='2'>Análise Ambiente</td>        ");
                sb.AppendLine("                             </tr>                                                                             ");
                sb.AppendLine("                             <tr class='text-light bg-dark'>                                                   ");
                sb.AppendLine("                                 <td class='small border-top-0'>Check List Análise Biomecânica</td>            ");
                sb.AppendLine("                                 <td class='small border-top-0'>Check List Análise Ergonomico</td>             ");
                sb.AppendLine("                             </tr>                                                                             ");
                sb.AppendLine("                         </thead>                                                                              ");
                sb.AppendLine("                         <tbody class='small'>                                                                 ");
                sb.AppendLine("                             #Dados_Boletins_Analise#                                                          ");
                sb.AppendLine("                         </tbody>                                                                              ");
                sb.AppendLine("                     </table>                                                                                  ");
                sb.AppendLine("                 </div>                                                                                        ");
                sb.AppendLine("             </div>                                                                                            ");
                sb.AppendLine("         </div>                                                                                                ");
                sb.AppendLine("     </div>                                                                                                    ");
                sb.AppendLine("</div>");

                var HtmlBase = sb.ToString();
                HtmlBase = HtmlBase.Replace("\r\n", "").Replace("\r", "").Replace("\n", "").Replace("\"", "");

                StringBuilder Tabela_Dados_Boletins = new StringBuilder();
                Tabela_Dados_Boletins.AppendLine("<tr>                                                                   ");
                Tabela_Dados_Boletins.AppendLine("  <td>#Numero_Boletim#</td>                                            ");
                Tabela_Dados_Boletins.AppendLine("  <td>#Data_Boletim#</td>                                              ");
                Tabela_Dados_Boletins.AppendLine("  <td>#Avaliador_Boletim#</td>                                         ");
                Tabela_Dados_Boletins.AppendLine("  <td>#Local_Boletim#</td>                                             ");
                Tabela_Dados_Boletins.AppendLine("  <td>#Atividade_Boletim#</td>                                         ");
                Tabela_Dados_Boletins.AppendLine("</tr>                                                                  ");

                StringBuilder Tabela_DadosAnalise_Boletins = new StringBuilder();
                Tabela_DadosAnalise_Boletins.AppendLine("<tr>                                                            ");
                Tabela_DadosAnalise_Boletins.AppendLine("  <td>#Numero_Boletim#</td>                                     ");
                Tabela_DadosAnalise_Boletins.AppendLine("  <td>#Atividade_Boletim#</td>                                  ");
                Tabela_DadosAnalise_Boletins.AppendLine("  <td>#Analise_Postura#</td>                                    ");
                Tabela_DadosAnalise_Boletins.AppendLine("  <td>#Analise_Cognitiva#</td>                                  ");
                Tabela_DadosAnalise_Boletins.AppendLine("  <td>#Analise_AmbienteBio#</td>                                ");
                Tabela_DadosAnalise_Boletins.AppendLine("  <td>#Analise_AmbienteErg#</td>                                ");
                Tabela_DadosAnalise_Boletins.AppendLine("</tr>                                                           ");

                int Indice = 0;

                var HtmlRetorno = string.Empty;

                #endregion

                var lista = listaBoletim.GroupBy(x => x.Setor).ToList();

                foreach (var listaAgrupada in lista)
                {
                    var HtmlEditado = HtmlBase;
                    var SetorNome = Setor.Where(x => x.ID == Convert.ToInt32(listaAgrupada.Key)).Select(x => x.Nome).FirstOrDefault();

                    HtmlEditado = HtmlEditado.Replace("#ID_Card_Collapse#", "ID_Card_Collapse_" + Indice);
                    HtmlEditado = HtmlEditado.Replace("#Nome_Setor#", SetorNome);
                    var HtmlEditadoTabelaDadosBoletins = string.Empty;
                    var HtmlEditadoTabelaDadosBoletinsAnalise = string.Empty;

                    foreach (var item in listaAgrupada)
                    {

                        var SetorBoletim = Setor.Where(x => x.ID == Convert.ToInt32(item.Setor)).Select(x => x.Nome).FirstOrDefault();
                        var LocalBoletim = Local.Where(x => x.ID_Local == Convert.ToInt32(item.Local) && x.ID == Convert.ToInt32(item.Setor)).Select(x => x.Nome).FirstOrDefault();
                        var AtividadeBoletim = Atividade.Where(x => x.ID == Convert.ToInt32(item.Atividade)).Select(x => x.NomeAtividade).FirstOrDefault();

                        var HtmlTabelaDadosBoletins = Tabela_Dados_Boletins.ToString();
                        HtmlTabelaDadosBoletins = HtmlTabelaDadosBoletins.Replace("\r\n", "").Replace("\r", "").Replace("\n", "").Replace("\"", "");

                        var HtmlTabelaDadosAnaliseBoletins = Tabela_DadosAnalise_Boletins.ToString();
                        HtmlTabelaDadosAnaliseBoletins = HtmlTabelaDadosAnaliseBoletins.Replace("\r\n", "").Replace("\r", "").Replace("\n", "").Replace("\"", "");

                        HtmlTabelaDadosBoletins = HtmlTabelaDadosBoletins.Replace("#Numero_Boletim#", item.ID.ToString());
                        HtmlTabelaDadosBoletins = HtmlTabelaDadosBoletins.Replace("#Data_Boletim#", Convert.ToDateTime(item.Data).ToShortDateString());
                        HtmlTabelaDadosBoletins = HtmlTabelaDadosBoletins.Replace("#Avaliador_Boletim#", item.NomeFiscal.ToString());
                        HtmlTabelaDadosBoletins = HtmlTabelaDadosBoletins.Replace("#Local_Boletim#", LocalBoletim.ToString());
                        HtmlTabelaDadosBoletins = HtmlTabelaDadosBoletins.Replace("#Atividade_Boletim#", AtividadeBoletim.ToString());

                        //
                        HtmlTabelaDadosAnaliseBoletins = HtmlTabelaDadosAnaliseBoletins.Replace("#Numero_Boletim#", item.ID.ToString());

                        HtmlEditadoTabelaDadosBoletins += HtmlTabelaDadosBoletins;
                        //

                        if (Equals(item.ListaAnalisePostura.Count, 0))
                            HtmlTabelaDadosAnaliseBoletins = HtmlTabelaDadosAnaliseBoletins.Replace("#Analise_Postura#", "<span class='font-italic'>Sem Análise !</span>");

                        int IndiceAnalise = 0;

                        foreach (var itemPostura in item.ListaAnalisePostura)
                        {
                            if (item.ListaAnalisePostura.Count == 1)
                            {
                                HtmlTabelaDadosAnaliseBoletins = HtmlTabelaDadosAnaliseBoletins.Replace("#Numero_Boletim#", item.ID.ToString());
                                HtmlTabelaDadosAnaliseBoletins = HtmlTabelaDadosAnaliseBoletins.Replace("#Analise_Postura#", itemPostura.AcaoDescricao.ToString());
                            }
                            else if (item.ListaAnalisePostura.Count >= 2)
                            {
                                if (IndiceAnalise == 0)
                                {
                                    HtmlTabelaDadosAnaliseBoletins = HtmlTabelaDadosAnaliseBoletins.Replace("#Numero_Boletim#", item.ID.ToString());
                                    HtmlTabelaDadosAnaliseBoletins = HtmlTabelaDadosAnaliseBoletins.Replace("#Analise_Postura#", itemPostura.AcaoDescricao.ToString() + "<br>#Continuação_Analise#</br>");
                                    IndiceAnalise++;
                                }
                                else
                                {
                                    HtmlTabelaDadosAnaliseBoletins = HtmlTabelaDadosAnaliseBoletins.Replace("#Continuação_Analise#", itemPostura.AcaoDescricao.ToString() + "<br>#Continuação_Analise#</br>");
                                }
                            }
                        }

                        HtmlTabelaDadosAnaliseBoletins = HtmlTabelaDadosAnaliseBoletins.Replace("#Atividade_Boletim#", AtividadeBoletim.ToString());

                        if (!Equals(item.listanasa.Resultado, "Sem Análise !"))
                            HtmlTabelaDadosAnaliseBoletins = HtmlTabelaDadosAnaliseBoletins.Replace("#Analise_Cognitiva#", item.listanasa.Resultado.ToString());
                        else
                            HtmlTabelaDadosAnaliseBoletins = HtmlTabelaDadosAnaliseBoletins.Replace("#Analise_Cognitiva#", "<span class='font-italic'>Sem Análise !</span>");

                        var CheckBio = CheckListAnaliseCondBio.Where(x => x.ID_Boletim == Convert.ToInt32(item.ID)).FirstOrDefault();
                        var CheckErg = CheckListAnaliseCondErg.Where(x => x.ID_Boletim == Convert.ToInt32(item.ID)).FirstOrDefault();

                        if (!Equals(CheckBio, null))
                            HtmlTabelaDadosAnaliseBoletins = HtmlTabelaDadosAnaliseBoletins.Replace("#Analise_AmbienteBio#", ContaResultadoBio(CheckBio));
                        else
                            HtmlTabelaDadosAnaliseBoletins = HtmlTabelaDadosAnaliseBoletins.Replace("#Analise_AmbienteBio#", "<span class='font-italic'>Sem Análise !</span>");

                        if (!Equals(CheckErg, null))
                            HtmlTabelaDadosAnaliseBoletins = HtmlTabelaDadosAnaliseBoletins.Replace("#Analise_AmbienteErg#", ContaResultadoErg(CheckErg));
                        else
                            HtmlTabelaDadosAnaliseBoletins = HtmlTabelaDadosAnaliseBoletins.Replace("#Analise_AmbienteErg#", "<span class='font-italic'>Sem Análise !</span>");

                        HtmlTabelaDadosAnaliseBoletins = HtmlTabelaDadosAnaliseBoletins.Replace("<br>#Continuação_Analise#</br>", "");

                        HtmlEditadoTabelaDadosBoletinsAnalise += HtmlTabelaDadosAnaliseBoletins;

                    }
                    Indice++;

                    HtmlEditado = HtmlEditado.Replace("#Dados_Boletins#", HtmlEditadoTabelaDadosBoletins);
                    HtmlEditado = HtmlEditado.Replace("#Dados_Boletins_Analise#", HtmlEditadoTabelaDadosBoletinsAnalise);

                    HtmlRetorno += HtmlEditado;
                }

                // Variaveis de Totalizador
                var ListaFiltro = new List<FiltroBoletim>();

                var SetorMaisApontado = listaBoletim.GroupBy(x => x.Setor).ToList();
                var descSetor = string.Empty;
                var qntSetor = 0;
                foreach (var itemSetorMaisApontado in SetorMaisApontado)
                {
                    foreach (var item in itemSetorMaisApontado)
                    {
                        descSetor = item.Setor;
                        qntSetor = itemSetorMaisApontado.Count();
                    }
                    ListaFiltro.Add(new FiltroBoletim(descSetor, qntSetor));
                }

                for (var i = 0; i < ListaFiltro.Count; i++)
                {
                    if (ListaFiltro[i].Qnt > qntSetor)
                    {
                        qntSetor = ListaFiltro[i].Qnt;
                        descSetor = ListaFiltro[i].NomeSetor;
                    }
                }

                ListaFiltro.Clear();

                var LocalMaisApontado = listaBoletim.GroupBy(x => x.Local).ToList();
                var descLocal = string.Empty;
                var qntLocal = 0;

                foreach (var itemLocalMaisApontado in LocalMaisApontado)
                {
                    foreach (var item in itemLocalMaisApontado)
                    {
                        descLocal = item.Setor;
                        qntLocal = itemLocalMaisApontado.Count();
                    }
                    ListaFiltro.Add(new FiltroBoletim(descSetor, qntSetor));
                }

                for (var j = 0; j < ListaFiltro.Count; j++)
                {
                    if (ListaFiltro[j].Qnt > qntSetor)
                    {
                        qntLocal = ListaFiltro[j].Qnt;
                        descLocal = ListaFiltro[j].NomeSetor;
                    }
                }

                var ContadorAnalisePostura = 0;
                var ContadorAnaliseCognitiva = 0;

                foreach (var item in listaBoletim)
                {
                    ContadorAnalisePostura += item.ListaAnalisePostura.Count();

                    if (item.listanasa.ID_Analise > 0)
                        ContadorAnaliseCognitiva++;
                }

                var QntTotalBoletim = listaBoletim.Count.ToString();
                var UltimoBoletim = listaBoletim.Select(x => x.ID).LastOrDefault().ToString();
                if (ListaFiltro.Count > 0)
                {
                    var SetorMaisApontadoReplace = Setor.Where(x => x.ID == Convert.ToInt32(descSetor)).Select(x => x.Nome).FirstOrDefault().ToString();
                    var LocalMaisApontadoReplace = Local.Where(x => x.ID == Convert.ToInt32(descLocal)).Select(x => x.Nome).FirstOrDefault().ToString();
                    HtmlBaseTotalizador = HtmlBaseTotalizador.Replace("#Setor_Apontamento#", SetorMaisApontadoReplace);
                    HtmlBaseTotalizador = HtmlBaseTotalizador.Replace("#Local_Apontamento#", LocalMaisApontadoReplace);

                }
                else
                {
                    var SetorMaisApontadoReplace = Setor.Where(x => x.ID == Convert.ToInt32(filtros.setor)).Select(x => x.Nome).FirstOrDefault();
                    var LocalMaisApontadoReplace = Local.Where(x => x.ID == Convert.ToInt32(filtros.local)).Select(x => x.Nome).FirstOrDefault();

                    if (!Equals(SetorMaisApontadoReplace, null))
                        HtmlBaseTotalizador = HtmlBaseTotalizador.Replace("#Setor_Apontamento#", SetorMaisApontadoReplace.ToString());
                    else
                        HtmlBaseTotalizador = HtmlBaseTotalizador.Replace("#Setor_Apontamento#", "");

                    if (!Equals(LocalMaisApontadoReplace, null))
                        HtmlBaseTotalizador = HtmlBaseTotalizador.Replace("#Local_Apontamento#", LocalMaisApontadoReplace.ToString());
                    else
                        HtmlBaseTotalizador = HtmlBaseTotalizador.Replace("#Local_Apontamento#", "");
                }

                var AnalisePostura = ContadorAnalisePostura;
                var AnaliseCognitiva = ContadorAnaliseCognitiva;

                HtmlBaseTotalizador = HtmlBaseTotalizador.Replace("#Qnt_Total_Boletim#", QntTotalBoletim);
                HtmlBaseTotalizador = HtmlBaseTotalizador.Replace("#ID_Ultimo_Boletim#", UltimoBoletim);
                HtmlBaseTotalizador = HtmlBaseTotalizador.Replace("#Analise_Postura#", AnalisePostura.ToString());
                HtmlBaseTotalizador = HtmlBaseTotalizador.Replace("#Analise_Cognitiva#", AnaliseCognitiva.ToString());
                HtmlBaseTotalizador = HtmlBaseTotalizador.Replace("#Check_Erg#", CheckListAnaliseCondErg.Where(x => x.ID_Boletim > 0).Count().ToString());
                HtmlBaseTotalizador = HtmlBaseTotalizador.Replace("#Check_Bio#", CheckListAnaliseCondBio.Where(x => x.ID_Boletim > 0).Count().ToString());

                return HtmlBaseTotalizador + HtmlRetorno;
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<div class='alert alert-primary text-center small' role='alert'>                                                                                                              ");
                sb.AppendLine("     Não foi localizado nenhum Boletim com esses Parâmetros de busca!                                                                                                               ");
                sb.AppendLine("</div>                                                                                                                   ");

                var HtmlBase = sb.ToString();
                HtmlBase = HtmlBase.Replace("\r\n", "").Replace("\r", "").Replace("\n", "").Replace("\"", "");

                return HtmlBase;
            }
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

            string resultado = string.Empty;

            var QntErg = ((TotalErg * 100) / 24);

            if (QntErg >= 91 && QntErg <= 100)
                resultado = "Condição Ergonômica Excelente !";
            else if (QntErg >= 71 && QntErg <= 90)
                resultado = "Boa Condição Ergonômica !";
            else if (QntErg >= 51 && QntErg <= 70)
                resultado = "Condição Ergonômica Razoável !";
            else if (QntErg >= 31 && QntErg <= 50)
                resultado = "Condição Ergonômica Ruim !";
            else if (QntErg <= 30)
                resultado = "Condição Ergonômica Péssima !";

            return resultado;
        }

        private string ContaResultadoBio(CheckListAnaliseCondBio checkListBio)
        {
            int TotalBio = 0;

            if (!Equals(checkListBio, null))
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

            string resultado = string.Empty;

            if (TotalBio == 14 || TotalBio == 13)
                resultado = "Condição Biomecânica Excelente !";
            else if (TotalBio >= 10 && TotalBio <= 12)
                resultado = "Boa Condição Biomecânica !";
            else if (TotalBio >= 7 && TotalBio <= 9)
                resultado = "Condição Biomecânica Razoável !";
            else if (TotalBio >= 4 && TotalBio <= 6)
                resultado = "Condição Biomecânica Ruim !";
            else if (TotalBio <= 3)
                resultado = "Condição Biomecânica Péssima !";

            return resultado;
        }
    }


}