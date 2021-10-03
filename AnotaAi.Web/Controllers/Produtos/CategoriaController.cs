using AnotaAi.Dominio.Entidades.Produtos;
using AnotaAi.Dominio.Interface.Respositorios.Produtos;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Linq;

namespace AnotaAi.Web.Controllers.Produtos
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : Controller
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public CategoriaController(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Categoria), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get()
        {
            try
            {
                var categorias = _categoriaRepositorio.ObterTodos();

                if (!categorias.Any())
                {
                    return NotFound("Nenhuma categoria localizada.");
                }

                return Ok(categorias);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Categoria), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get(int id)
        {
            try
            {
                var categoria = _categoriaRepositorio.ObterPorId(id);

                if (categoria == null)
                {
                    return NotFound($"Nenhuma categoria localizada com código: {id}.");
                }

                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Categoria), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Put(int id, Categoria categoria)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Código da categoria não é válido.");
                }

                var categoriaExistente = _categoriaRepositorio.ObterPorId(id);
                if (categoriaExistente is null)
                {
                    return NotFound($"Nenhuma categoria localizada com código: {id}.");
                }

                categoriaExistente.Atualizar(categoria.Nome, categoria.Descricao);

                _categoriaRepositorio.Atualizar(categoriaExistente);

                return Ok(categoriaExistente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(Categoria), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody] Categoria categoria)
        {
            try
            {
                _categoriaRepositorio.Adicionar(categoria);
                return Created("api/categoria", categoria);
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
                var categoria = _categoriaRepositorio.ObterPorId(id);
                if (categoria == null)
                {
                    return NotFound($"Nenhuma categoria localizada com código: {id}.");
                }

                _categoriaRepositorio.Excluir(categoria);

                return Ok("Categoria deletada com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }
    }
}