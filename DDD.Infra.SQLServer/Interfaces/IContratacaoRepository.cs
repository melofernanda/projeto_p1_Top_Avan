using DDD.Domain.RH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interfaces
{
    public interface IContratacaoRepository
    {
        public List<Contratacao> GetContratacoes();

        public Contratacao GetContratacaoById(int id);

        public Contratacao InsertContratacao(int idSetor, int idFuncionario);

        public void UpdateContratacao(Contratacao contratacao);

        public void DeleteContratacao(Contratacao contratacao);


    }
}
