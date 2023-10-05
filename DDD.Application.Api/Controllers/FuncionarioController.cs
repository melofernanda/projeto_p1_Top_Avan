using DDD.Domain.RH;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioController(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        // GET: api/<FuncionariosController>
        [HttpGet]
        public ActionResult<List<Funcionario>> Get()
        {
            return Ok(_funcionarioRepository.GetFuncionarios());
        }

        [HttpGet("{id}")]
        public ActionResult<Funcionario> GetById(int id)
        {
            return Ok(_funcionarioRepository.GetFuncionarioById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Funcionario> CreateFuncionario(Funcionario funcionario)
        {
            if (funcionario.Nome.Length < 3 || funcionario.Nome.Length > 30)
            {
                return BadRequest("Nome deve ser maior que 3 e menor que 30 caracteres.");
            }
            _funcionarioRepository.InsertFuncionario(funcionario);
            return CreatedAtAction(nameof(GetById), new { id = funcionario.UserId }, funcionario);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Funcionario funcionario)
        {
            try
            {
                if (funcionario == null)
                    return NotFound();

                _funcionarioRepository.UpdateFuncionario(funcionario);
                return Ok("Funcion�rio atualizado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/values/5
        [HttpDelete()]
        public ActionResult Delete([FromBody] Funcionario funcionario)
        {
            try
            {
                if (funcionario == null)
                    return NotFound();

                _funcionarioRepository.DeleteFuncionario(funcionario);
                return Ok("Funcion�rio removido com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
