using DDD.Domain.RH;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetorController : ControllerBase
    {
        private readonly ISetorRepository _setorRepository;

        public SetorController(ISetorRepository setorRepository)
        {
            _setorRepository = setorRepository;
        }

        [HttpGet]
        public ActionResult<List<Setor>> Get()
        {
            var setores = _setorRepository.GetSetores();
            return Ok(setores);
        }

        [HttpGet("{id}")]
        public ActionResult<Setor> GetById(int id)
        {
            var setor = _setorRepository.GetSetorById(id);
            if (setor == null)
            {
                return NotFound();
            }
            return Ok(setor);
        }

        [HttpPost]
        public ActionResult<Setor> CreateSetor([FromBody] Setor setor)
        {
            
           _setorRepository.InsertSetor(setor);
           return CreatedAtAction(nameof(GetById), new { id = setor.SetorId }, setor);
           
        }

        [HttpPut]
        public ActionResult UpdateSetor([FromBody] Setor setor)
        {
            try
            {
                if (setor == null)
                    return NotFound();

                _setorRepository.UpdateSetor(setor);
                return Ok("setor atualizado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }
    

        [HttpDelete("{id}")]
        public ActionResult DeleteSetor(int id)
        {
            var setor = _setorRepository.GetSetorById(id);
            if (setor == null)
            {
                return NotFound();
            }

            try
            {
                _setorRepository.DeleteSetor(setor);
                return Ok("Setor removido com sucesso!");
            }
            catch (Exception ex)
            {
                // Log de erro ou tratamento de exceção
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }
    }
}