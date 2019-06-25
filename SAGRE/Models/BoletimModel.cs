using Microsoft.AspNetCore.Authorization;
using SAGRE.Models.MetodosAnalise;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SAGRE.Models
{
    [Authorize]
    public class BoletimModel
    {
        public BoletimModel()
        {
            ListaAnalisePostura = new List<AnalisePosturaModel>();
            listanasa = new AnaliseNASATLXModel();

        }

        public enum status { Aberto, Análise, Fechado }

        [Key]
        public int ID { get; set; }

        [Required]
        public string NomeFiscal { get; set; }

        [Required]
        public DateTime? Data { get; set; }

        [Required]
        public string Setor { get; set; }

        [Required,Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required]
        public string Atividade { get; set; }

        public status Status { get; set; }

        public int Flag { get; set; }

        public List<AnalisePosturaModel> ListaAnalisePostura { get; set; }

        public AnaliseNASATLXModel listanasa { get; set; }

    }
}
