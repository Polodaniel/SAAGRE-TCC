
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SAGRE.Models.MetodosAnalise
{
    public class AnaliseNASATLXModel
    {
        [Key]
        public int ID_Analise { get; set; }
        public int ID { get; set; }
        [ForeignKey("ID")]
        public BoletimModel BoletimModel { get; set; }
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
}
