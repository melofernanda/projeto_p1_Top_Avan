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
        public ActionResult<Contratacao> CreateContratacao(int idSetor, int idFuncionario)
        {
            Contratacao contratacaoIdSaved = _contratacaoRepository.InsertContratacao(idSetor, idFuncionario);
            return CreatedAtAction(nameof(GetById), new { id = contratacaoIdSaved.ContratacaoId }, contratacaoIdSaved);
        }

        

    }
}
