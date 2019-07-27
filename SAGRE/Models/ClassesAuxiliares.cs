using SAGRE.Models.MetodosAnalise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAGRE.Models
{
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
