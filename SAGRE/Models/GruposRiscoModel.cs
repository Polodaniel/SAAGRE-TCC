﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SAGRE.Models
{
    public class GruposRiscoModel
    {
        public int ID { get; set; }

        [Required , Display(Name="Nome")]
        public string Nome { get; set; }

        [Required , Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public bool Inativo { get; set; }

        [NotMapped]
        public string Status {
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
