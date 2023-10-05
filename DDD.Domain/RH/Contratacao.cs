using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.RH
{
    public class Contratacao
    {
        public int ContratacaoId { get; set; }

        public Funcionario Funcionario { get; set; }


        public Setor Setor { get; set; }      

        public DateTime DataContratacao { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Salario { get; set; }
    }
}
