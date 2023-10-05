using DDD.Domain.RH;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Repositories
{
    public class SetorRepositorySqlServer : ISetorRepository
    {
        private readonly SqlContext _context;

        public SetorRepositorySqlServer(SqlContext context)
        {
            _context = context;
        }

        public void DeleteSetor(Setor setor)
        {
            try
            {
                _context.Set<Setor>().Remove(setor);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Setor GetSetorById(int id)
        {
            return _context.Setores.Find(id);
        }

        public List<Setor> GetSetores()
        {
            return _context.Setores.ToList();
        }

        public void InsertSetor(Setor setor)
        {
            try
            {
                _context.Setores.Add(setor);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                //log
            }
        }

        public void UpdateSetor(Setor setor)
        {
            try
            {
                _context.Entry(setor).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
