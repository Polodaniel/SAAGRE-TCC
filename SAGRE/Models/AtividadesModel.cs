using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SAGRE.Models
{
    public class AtividadesModel
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Nome")]
        public string NomeAtividade { get; set; }


        [Display(Name = "Descrição")]
        public string DescricaoAtividade { get; set; }

        public bool Inativo { get; set; }

        [NotMapped, Display(Name = "Descrição")]
        public string Status
        {
            get
            {
                if (Inativo == false)
                    return "Ativo";
                else
                    return "Inativo";
            }
        }

    }
}
