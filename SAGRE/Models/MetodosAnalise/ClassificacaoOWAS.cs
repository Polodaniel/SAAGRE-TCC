using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SAGRE.Models.MetodosAnalise
{
    public class ClassificaoOWAS
    {

        [Key]
        public int ID { get; set; }

        public int NumCosta { get; set; }

        public int NumBraco { get; set; }

        public int NumPernas { get; set; }

        public int NumForca { get; set; }

        public int NumCategoria { get; set; }


        [NotMapped]
        public string Categoria
        {
            get
            {
                string DescricaoCategoria = String.Empty;

                switch (NumCategoria)
                {
                    case 1:
                        DescricaoCategoria = "Não são necessarias medidas corretivas.";
                        break;
                    case 2:
                        DescricaoCategoria = "São necessarias correções em um futuro próximo.";
                        break;
                    case 3:
                        DescricaoCategoria = "São necessárias correções tão logo quanto possível.";
                        break;
                    case 4:
                        DescricaoCategoria = "São necessárias correções imediatas.";
                        break;
                    default:
                        DescricaoCategoria = "";
                        break;
                }

                return DescricaoCategoria;
            }
            set => NumCategoria = Convert.ToInt32(value);
        }

    }
}
