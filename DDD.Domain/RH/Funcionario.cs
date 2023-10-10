using DDD.Domain.UserManagementContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.RH
{
    public class Funcionario : User
    {

        public List<Setor>? Setores { get; set; }
       
    }
}
