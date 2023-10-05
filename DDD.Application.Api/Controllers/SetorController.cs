using DDD.Domain.RH;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetorController : ControllerBase
    {
        readonly ISetorRepository _setorRepository;

        public SetorController(ISetorRepository setorRepository)
        {
            _setorRepository = setorRepository;
        }

        // GET: api/<FuncionarioController>
        [HttpGet]
        public ActionResult<List<Setor>> Get()
        {
            return Ok(_setorRepository.GetSetores());
        }

        [HttpGet("{id}")]
        public ActionResult<Setor> GetById(int id)
        {
            return Ok(_setorRepository.GetSetorById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Funcionario> CreateSetor(Setor setor)
        {
            _setorRepository.InsertSetor(setor);
            return CreatedAtAction(nameof(GetById), new { id = setor.SetorId }, setor);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Setor setor)
        {
            try
            {
                if (setor == null)
                    return NotFound();

                _setorRepository.UpdateSetor(setor);
                return Ok("Setor atualizado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/values/5
        [HttpDelete()]
        public ActionResult Delete([FromBody] Setor setor)
        {
            try
            {
                if (setor == null)
                    return NotFound();

                _setorRepository.DeleteSetor(setor);
                return Ok("Setor removido com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
