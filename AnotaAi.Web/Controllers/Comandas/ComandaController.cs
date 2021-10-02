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
    public class ComandaController : Controller
    {
        private readonly IComandaRepositorio _comandaRepositorio;

        public ComandaController(IComandaRepositorio comandaRepositorio)
        {
            _comandaRepositorio = comandaRepositorio;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Comanda), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get()
        {
            try
            {
                var comandas = _comandaRepositorio.ObterTodos();

                if (!comandas.Any())
                {
                    return NotFound("Nenhuma comanda localizada.");
                }

                return Ok(comandas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Comanda), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get(int id)
        {
            try
            {
                var comanda = _comandaRepositorio.ObterPorId(id);

                if (comanda == null)
                {
                    return NotFound($"Nenhuma comanda localizada com código: {id}.");
                }

                return Ok(comanda);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Comanda), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Put(int id, Comanda comanda)
        {
            try
            {
                if (id != comanda.Id)
                {
                    return BadRequest("Não é permitido alterar o código da comanda.");
                }

                var comandaExistente = _comandaRepositorio.ObterPorId(id);
                if (comandaExistente is null)
                {
                    return NotFound($"Nenhuma comanda localizada com código: {id}.");
                }

                comanda.Id = id;
                _comandaRepositorio.Atualizar(comanda);

                return Ok(comanda);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(Comanda), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody] Comanda comanda)
        {
            try
            {
                _comandaRepositorio.Adicionar(comanda);
                return Created("api/comanda", comanda);
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
                var comanda = _comandaRepositorio.ObterPorId(id);
                if (comanda == null)
                {
                    return NotFound($"Nenhuma comanda localizada com código: {id}.");
                }

                _comandaRepositorio.Excluir(comanda);

                return Ok("Comanda deletada com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }
    }
}
