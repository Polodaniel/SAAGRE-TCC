
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

        [NotMapped]
        public string Resultado
        {
            get
            {
                var Resultado = string.Empty;

                var ValorMental = Convert.ToInt32(escalaMental) * Convert.ToInt32(rangeDM);
                var ValorFisico = Convert.ToInt32(escalaFisica) * Convert.ToInt32(rangeDF);
                var ValorTemporal = Convert.ToInt32(escalaTemporal) * Convert.ToInt32(rangeDT);
                var ValorPerformace = Convert.ToInt32(escalaPerformace) * Convert.ToInt32(rangePE);
                var ValorEsforco = Convert.ToInt32(escalaEsforco) * Convert.ToInt32(rangeDE);
                var ValorFrustracao = Convert.ToInt32(escalaFrustacao) * Convert.ToInt32(rangeFR);
                var ValorTotal = (ValorMental + ValorFisico + ValorTemporal + ValorPerformace + ValorEsforco + ValorFrustracao) / 15;

                if(ValorTotal == 0 )
                    Resultado = "Sem Análise !";
                else if (ValorTotal >= 1 && ValorTotal <= 20)
                    Resultado = "Intensidade da Carga Mental: Mínimo";
                else if (ValorTotal >= 21 && ValorTotal <= 40)
                    Resultado = "Intensidade da Carga Mental: Baixa";
                else if (ValorTotal >= 41 && ValorTotal <= 60)
                    Resultado = "Intensidade da Carga Mental: Moderada";
                else if (ValorTotal >= 61 && ValorTotal <= 80)
                    Resultado = "Intensidade da Carga Mental: Alta";
                else if (ValorTotal >= 81 && ValorTotal <= 100)
                    Resultado = "Intensidade da Carga Mental: Intolerável";

                return Resultado;
            }
        }
    }
}
