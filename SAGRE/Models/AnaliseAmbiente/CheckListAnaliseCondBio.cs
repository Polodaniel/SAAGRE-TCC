using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SAGRE.Models.AnaliseAmbiente
{
    public class CheckListAnaliseCondBio
    {
        public CheckListAnaliseCondBio(){}

        public CheckListAnaliseCondBio(CheckListAnaliseCondBio x)
        {
            ID = x.ID;
            TipoCheckList = x.TipoCheckList;
            ID_Boletim = x.ID_Boletim;
            Questao01 = x.Questao01;
            Questao02 = x.Questao02;
            Questao03 = x.Questao03;
            Questao04 = x.Questao04;
            Questao05 = x.Questao05;
            Questao06 = x.Questao06;
            Questao07 = x.Questao07;
            Questao08 = x.Questao08;
            Questao09 = x.Questao09;
            Questao10 = x.Questao10;
            Questao11 = x.Questao11;
            Questao12 = x.Questao12;
            Questao13 = x.Questao13;
            Questao14 = x.Questao14;
            Questao15 = x.Questao15;
            Questao16 = x.Questao16;
            Questao17 = x.Questao17;
            Questao18 = x.Questao18;
            Questao19 = x.Questao19;
            Questao20 = x.Questao20;
            Questao21 = x.Questao21;
            Questao22 = x.Questao22;
            Questao23 = x.Questao23;
            Questao24 = x.Questao24;
            Questao25 = x.Questao25;
            Questao26 = x.Questao26;
            Questao27 = x.Questao27;
            Questao28 = x.Questao28;
            Questao29 = x.Questao29;
            Questao30 = x.Questao30;
        }

        [Key]
        public int ID { get; set; }

        #region Tipos de CheckList
        public int TipoCheckList { get; set; }
        #endregion

        public int ID_Boletim { get; set; }

        [StringLength(3)]
        public string Questao01 { get; set; }

        [StringLength(3)]
        public string Questao02 { get; set; }

        [StringLength(3)]
        public string Questao03 { get; set; }

        [StringLength(3)]
        public string Questao04 { get; set; }

        [StringLength(3)]
        public string Questao05 { get; set; }

        [StringLength(3)]
        public string Questao06 { get; set; }

        [StringLength(3)]
        public string Questao07 { get; set; }

        [StringLength(3)]
        public string Questao08 { get; set; }

        [StringLength(3)]
        public string Questao09 { get; set; }

        [StringLength(3)]
        public string Questao10 { get; set; }

        [StringLength(3)]
        public string Questao11 { get; set; }

        [StringLength(3)]
        public string Questao12 { get; set; }

        [StringLength(3)]
        public string Questao13 { get; set; }

        [StringLength(3)]
        public string Questao14 { get; set; }

        [StringLength(3)]
        public string Questao15 { get; set; }

        [StringLength(3)]
        public string Questao16 { get; set; }

        [StringLength(3)]
        public string Questao17 { get; set; }

        [StringLength(3)]
        public string Questao18 { get; set; }

        [StringLength(3)]
        public string Questao19 { get; set; }

        [StringLength(3)]
        public string Questao20 { get; set; }

        [StringLength(3)]
        public string Questao21 { get; set; }

        [StringLength(3)]
        public string Questao22 { get; set; }

        [StringLength(3)]
        public string Questao23 { get; set; }

        [StringLength(3)]
        public string Questao24 { get; set; }

        [StringLength(3)]
        public string Questao25 { get; set; }

        [StringLength(3)]
        public string Questao26 { get; set; }

        [StringLength(3)]
        public string Questao27 { get; set; }

        [StringLength(3)]
        public string Questao28 { get; set; }

        [StringLength(3)]
        public string Questao29 { get; set; }

        [StringLength(3)]
        public string Questao30 { get; set; }
    }
}
