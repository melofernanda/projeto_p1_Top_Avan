using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.RH
{
    
    public class Setor
    {
        public int SetorId { get; set; }
        public string Nome { get; set; }
        public int Bloco { get; set; }



        public List<Funcionario>? Funcionarios { get; set; }

       
    }
}
