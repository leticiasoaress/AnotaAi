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
    public class FuncionarioController : Controller
    {
        private readonly IFuncionarioRepositorio _funcionarioRepositorio;

        public FuncionarioController(IFuncionarioRepositorio funcionarioRepositorio)
        {
            _funcionarioRepositorio = funcionarioRepositorio;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Funcionario), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get()
        {
            try
            {
                var funcionarios = _funcionarioRepositorio.ObterTodos();

                if (!funcionarios.Any())
                {
                    return NotFound("Nenhum cargo localizado.");
                }

                return Ok(funcionarios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Funcionario), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get(int id)
        {
            try
            {
                var funcionario = _funcionarioRepositorio.ObterPorId(id);

                if (funcionario == null)
                {
                    return NotFound($"Nenhum funcionario localizado com código: {id}.");
                }

                return Ok(funcionario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Funcionario), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Put(int id, Funcionario funcionario)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Código do funcionario não é válido.");
                }

                var funcionarioExistente = _funcionarioRepositorio.ObterPorId(id);
                if (funcionarioExistente is null)
                {
                    return NotFound($"Nenhum funcionario localizado com código: {id}.");
                }

                funcionarioExistente.Atualizar(funcionario.DataContratacao, funcionario.CargoId);

                _funcionarioRepositorio.Atualizar(funcionarioExistente);

                return Ok(funcionarioExistente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(Funcionario), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody] Funcionario funcionario)
        {
            try
            {
                _funcionarioRepositorio.Adicionar(funcionario);
                return Created("api/funcionario", funcionario);
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
                var funcionario = _funcionarioRepositorio.ObterPorId(id);
                if (funcionario == null)
                {
                    return NotFound($"Nenhum funcionario localizado com código: {id}.");
                }

                _funcionarioRepositorio.Excluir(funcionario);

                return Ok("Funcionario deletado com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }
    }
}