using AnotaAi.Dominio.Entidades.Funcionarios;
using AnotaAi.Dominio.Interface.Respositorios.Funcionarios;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Linq;

namespace AnotaAi.Web.Controllers.Funcionarios
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : Controller
    {
        private readonly IPessoaRepositorio _pessoaRepositorio;

        public PessoaController(IPessoaRepositorio pessoaRepositorio)
        {
            _pessoaRepositorio = pessoaRepositorio;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Pessoa), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get()
        {
            try
            {
                var cargos = _pessoaRepositorio.ObterTodos();

                if (!cargos.Any())
                {
                    return NotFound("Nenhum cargo localizado.");
                }

                return Ok(cargos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Pessoa), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get(int id)
        {
            try
            {
                var pessoa = _pessoaRepositorio.ObterPorId(id);

                if (pessoa == null)
                {
                    return NotFound($"Nenhuma pessoa localizado com código: {id}.");
                }

                return Ok(pessoa);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Pessoa), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Put(int id, Pessoa pessoa)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Código da pessoa não é válido.");
                }

                var pessoaExistente = _pessoaRepositorio.ObterPorId(id);
                if (pessoaExistente is null)
                {
                    return NotFound($"Nenhuma pessoa localizada com código: {id}.");
                }

                pessoaExistente.Atualizar(pessoa);

                _pessoaRepositorio.Atualizar(pessoaExistente);

                return Ok(pessoaExistente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(Pessoa), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody] Pessoa pessoa)
        {
            try
            {
                _pessoaRepositorio.Adicionar(pessoa);
                return Created("api/pessoa", pessoa);
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
                var cargo = _pessoaRepositorio.ObterPorId(id);
                if (cargo == null)
                {
                    return NotFound($"Nenhuma pessoa localizada com código: {id}.");
                }

                _pessoaRepositorio.Excluir(cargo);

                return Ok("Pessoa deletado com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }
    }
}
