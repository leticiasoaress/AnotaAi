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
    public class ItemComandaController : ControllerBase
    {
        private readonly IItemComandaRepositorio _itemComandaRepositorio;

        public ItemComandaController(IItemComandaRepositorio itemComandaRepositorio) 
        {
            _itemComandaRepositorio = itemComandaRepositorio;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ItemComanda), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get()
        {
            try
            {
                var itensComanda = _itemComandaRepositorio.ObterTodos();

                if (!itensComanda.Any())
                {
                    return NotFound("Nenhum item de comanda localizado.");
                }

                return Ok(itensComanda);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ItemComanda), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get(int id)
        {
            try
            {
                var itemComanda = _itemComandaRepositorio.ObterPorId(id);

                if (itemComanda == null)
                {
                    return NotFound($"Nenhum item de comanda localizado com código: {id}.");
                }

                return Ok(itemComanda);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ItemComanda), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Put(int id, ItemComanda itemComanda)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Não é permitido alterar o código do produto.");
                }

                var itemComandaExistente = _itemComandaRepositorio.ObterPorId(id);
                if (itemComandaExistente is null)
                {
                    return NotFound($"Nenhum item de comanda localizado com código: {id}.");
                }

                itemComandaExistente.Atualizar(itemComanda.Quantidade);

                _itemComandaRepositorio.Atualizar(itemComandaExistente);

                return Ok(itemComandaExistente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ItemComanda), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody] ItemComanda itemComanda)
        {
            try
            {
                _itemComandaRepositorio.Adicionar(itemComanda);
                return Created("api/itemComanda", itemComanda);
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
                var itemComanda = _itemComandaRepositorio.ObterPorId(id);
                if (itemComanda == null)
                {
                    return NotFound($"Nenhum item de comanda localizado com código: {id}.");
                }

                _itemComandaRepositorio.Excluir(itemComanda);

                return Ok("Item da comanda deletado com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        [HttpGet]
        [Route("ObterPorComanda/{comandaId}")]
        [ProducesResponseType(typeof(ItemComanda), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ObterPorComanda(int comandaId)
        {
            try
            {
                var itemComanda = _itemComandaRepositorio.ObterPorComandaId(comandaId);

                if (itemComanda == null)
                {
                    return NotFound($"Nenhum item localizado na comanda de código: {comandaId}.");
                }

                return Ok(itemComanda);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }
    }
}
