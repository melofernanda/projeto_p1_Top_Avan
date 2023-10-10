using DDD.Domain.RH;
using DDD.Infra.SQLServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Repositories
{
    public class ContratacaoRepositorySqlServer : IContratacaoRepository
    {
        private readonly SqlContext _context;

        public ContratacaoRepositorySqlServer(SqlContext context)
        {
            _context = context;
        }
        
        public void DeleteContratacao(Contratacao contratacao)
        {
            throw new NotImplementedException();
        }

        public Contratacao GetContratacaoById(int id)
        {
            return _context.Contratacoes.Find(id);
        }

        public List<Contratacao> GetContratacoes()
        {
            return _context.Contratacoes.ToList();
        }

        public Contratacao InsertContratacao(int idSetor, int idFuncionario)
        {
            var funcionario = _context.Funcionarios.First(i => i.UserId == idFuncionario);
            var setor = _context.Setores.First(i => i.SetorId == idSetor);

            var contratacao = new Contratacao
            {
                Funcionario = funcionario,
                Setor = setor
            };

            try
            {

                _context.Add(contratacao);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                var msg = ex.InnerException;
                throw;
            }

            return contratacao;
        }

        public void UpdateContratacao(Contratacao contratacao)
        {
            throw new NotImplementedException();
        }
    }
}
