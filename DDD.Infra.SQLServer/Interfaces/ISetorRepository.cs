using DDD.Domain.RH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interfaces
{
    public interface ISetorRepository
    {
        public List<Setor> GetSetores();

        public Setor GetSetorById(int id);

        public void InsertSetor(Setor setor);

        public void UpdateSetor(Setor setor);   

        public void DeleteSetor(Setor setor);
    }
}
