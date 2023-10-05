using DDD.Domain.RH;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratacaoController : ControllerBase
    {
        readonly IContratacaoRepository _contratacaoRepository;

        public ContratacaoController(IContratacaoRepository contratacaoRepository)
        {
            _contratacaoRepository = contratacaoRepository; 
        }

        [HttpGet]
        public ActionResult<List<Contratacao>> Get()
        {
            return Ok(_contratacaoRepository.GetContratacoes());
        }

        [HttpGet("{id}")]
        public ActionResult<Funcionario> GetById(int id)
        {
            return Ok(_contratacaoRepository.GetContratacaoById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Contratacao> CreateContratacao(int idFuncionario, int idSetor)
        {
            Contratacao contratacaoIdSaved = _contratacaoRepository.InsertContratacao(idFuncionario, idSetor);
            return CreatedAtAction(nameof(GetById), new { id = contratacaoIdSaved.ContratacaoId }, contratacaoIdSaved);
        }

        //[HttpPut]
        //public ActionResult Put([FromBody] Aluno aluno)
        //{
        //    try
        //    {
        //        if (aluno == null)
        //            return NotFound();

        //        _alunoRepository.UpdateAluno(aluno);
        //        return Ok("Cliente Atualizado com sucesso!");
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //// DELETE api/values/5
        //[HttpDelete()]
        //public ActionResult Delete([FromBody] Aluno aluno)
        //{
        //    try
        //    {
        //        if (aluno == null)
        //            return NotFound();

        //        _alunoRepository.DeleteAluno(aluno);
        //        return Ok("Cliente Removido com sucesso!");
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }

        //}

    }
}
