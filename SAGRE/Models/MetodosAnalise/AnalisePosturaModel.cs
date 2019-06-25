using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SAGRE.Models.MetodosAnalise
{
    public class AnalisePosturaModel
    {
        [Key]
        public int ID_Analise { get; set; }

        public int ID { get; set; }

        [ForeignKey("ID")]
        public BoletimModel BoletimModel { get; set; }

        public string IB { get; set; }
        public string IP { get; set; }
        public string IE { get; set; }
        public string IC { get; set; }
        public int Index { get; set; }
        public string IBDescricao { get; set; }
        public string IPDescricao { get; set; }
        public string IEDescricao { get; set; }
        public string ICDescricao { get; set; }
        public string AcaoDescricao { get; set; }
    }
}
