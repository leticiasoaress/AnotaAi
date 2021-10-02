using AnotaAi.Dominio.Entidades.Comandas;
using AnotaAi.Dominio.Interface.Respositorios.Comandas;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Linq;

namespace AnotaAi.Web.Controllers.Comandas
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : Controller
    {
        private readonly IStatusRepositorio _statusRepositorio;

        public StatusController(IStatusRepositorio statusRepositorio)
        {
            _statusRepositorio = statusRepositorio;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Status), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get()
        {
            try
            {
                var status = _statusRepositorio.ObterTodos();

                if (!status.Any())
                {
                    return NotFound("Nenhum status localizado.");
                }

                return Ok(status);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Status), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get(int id)
        {
            try
            {
                var status = _statusRepositorio.ObterPorId(id);

                if (status == null)
                {
                    return NotFound($"Nenhum status localizado com código: {id}.");
                }

                return Ok(status);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Status), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Put(int id, Status status)
        {
            try
            {
                if (id != status.Id)
                {
                    return BadRequest("Não é permitido alterar o código do status.");
                }

                var statusExistente = _statusRepositorio.ObterPorId(id);
                if (statusExistente is null)
                {
                    return NotFound($"Nenhum status localizado com código: {id}.");
                }

                status.Id = id;
                _statusRepositorio.Atualizar(status);

                return Ok(status);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(Status), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody] Status status)
        {
            try
            {
                _statusRepositorio.Adicionar(status);
                return Created("api/status", status);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int id)
        {
            try
            {
                var status = _statusRepositorio.ObterPorId(id);
                if (status == null)
                {
                    return NotFound($"Nenhum status localizado com código: {id}.");
                }

                _statusRepositorio.Excluir(status);

                return Ok("Status deletado com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }
    }
}