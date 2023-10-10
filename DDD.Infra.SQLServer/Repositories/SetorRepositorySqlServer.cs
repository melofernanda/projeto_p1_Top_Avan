using DDD.Domain.RH;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DDD.Infra.SQLServer.Repositories
{
    public class SetorRepositorySqlServer : ISetorRepository
    {
        private readonly SqlContext _context;

        public SetorRepositorySqlServer(SqlContext context)
        {
            _context = context;
        }

        public List<Setor> GetSetores()
        {
            return _context.Setores.ToList();
        }

        public Setor GetSetorById(int id)
        {
            return _context.Setores.Find(id);
        }

        public void InsertSetor(Setor setor)
        {
            _context.Setores.Add(setor);
            _context.SaveChanges();
        }

        public void UpdateSetor(Setor setor)
        {
            _context.Entry(setor).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteSetor(Setor setor)
        {
            _context.Setores.Remove(setor);
            _context.SaveChanges();
        }
    }
}