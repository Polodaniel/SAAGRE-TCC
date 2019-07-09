using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SAGRE.Models.AnaliseAmbiente
{
    public class TmpCheckList
    {
        [Key]
        public int ID { get; set; }

        #region Tipos de CheckList

        // 1 - CHECKLIST PARA AVALIAÇÃO SIMPLIFICADA DAS CONDIÇÕES BIOMECÂNICAS DO POSTO DE TRABALHO
        // 2 - CHECKLIST PARA AVALIAÇÃO SIMPLIFICADA DE POSTOS DE TRABALHO COM TERMINAL OU COM COMPUTADOR


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
